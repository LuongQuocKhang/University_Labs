using Erp.Api.Statistics;
using University.Controllers;
using Erp.Framework.Modules.Dna.Extensions;
using Erp.Framework.Modules.OpenApi;
using Erp.Framework.Modules.Authentication.Extensions;
using Erp.Framework.Modules.Observability;
using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Erp.Guardian.Authentication.AspNetCore.Api;
using Erp.Guardian.Bouncer.Access.AspNetCore;
using Erp.Guardian.Core;
using Erp.Guardian.Core.AspNetCore;
using Erp.Guardian.Grant.Access.AspNetCore;
using Erp.Framework.Modules.Guardian.Extensions;
using Erp.Guardian.WhoAmI.Users.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using University.Persistence;
using University.Infrastructure;
using University.Application;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowErpDefault",
        builder => builder.WithOrigins(configuration["ErpBaseUrl"], "https://127.0.0.1:5173")
                           //.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowCredentials()
        );
});

// HTTP Api Practices Examples
builder.Services.AddSingleton<IResourceService, ResourceService>();

//ERP Framework specific
builder.Services.AddAuthenticationModule();
builder.Services.AddDnaUserModule();
builder.Services.AddHttpContextAccessor();

//Guardian related
builder.Services.AddGuardianUserModule();
builder.Services.AddErpAuthentication();
builder.Services.AddGuardian(new GuardianOptions { ApplicationGroupName = configuration["ApplicationName"] })
        .AddBouncer()
        .AddGrant()
        .AddWhoAmIUsers();

builder.Services.AddControllers(o =>
{
    var policy = new AuthorizationPolicyBuilder()
            .RequireAuthenticatedUser()
            .Build();
    o.Filters.Add(new AuthorizeFilter(policy));
    o.Filters.Add<BouncerAuthorizationFilter>();
    if (!builder.Environment.IsDevelopment())
    {
        o.Filters.Add(new ApiUsageCounterFilter(configuration["ApplicationName"],
                                configuration.GetConnectionString("SMARTAmaris")));
    }
});


builder.Services.AddDapperConfiguration();
builder.Services.AddEntityFramworkInfrastructure(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.AddApplicationDependencies();

if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddObservability(new ObservabilityOptions
    {
        ApplicationInsightsServiceOptions = new ApplicationInsightsServiceOptions()
        {
            EnableEventCounterCollectionModule = false,
            InstrumentationKey = configuration["ApplicationInsights:InstrumentationKey"]
        },
        ApplicationName = configuration["ApplicationName"],
        EnableShortDependencyTelemetryFilter = true
    });
}
builder.Services.AddOpenApi(configuration);

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
//This method should be called before other middleware piplines.
app.UseUrlRewrite();
app.UseCors("AllowErpDefault");
app.UseHttpsRedirection();
app.UseRouting();
app.UseErpAuthentication();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
app.UseOpenApi(configuration, apiVersionDescriptionProvider);
if (!builder.Environment.IsDevelopment())
{
    var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
    app.UseObservability(httpContextAccessor);
}

app.MapControllers();
app.Run();