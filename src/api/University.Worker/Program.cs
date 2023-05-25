using University.Worker;
using University.Worker.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var config = new WorkerOptions();
        hostContext.Configuration.Bind("Service", config);
        services.AddSingleton(config);

        services.AddHostedService<Worker>();
        services.AddTransient<IService, SampleService>();

        services.AddSingleton<ITelemetryInitializer, AITelemetryInitializer>();
        services.AddApplicationInsightsTelemetryWorkerService();
    })
    .Build();

await host.RunAsync();
