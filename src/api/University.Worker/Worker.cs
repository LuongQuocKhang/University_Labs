using University.Worker.Exceptions;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace University.Worker
{
    /*
     * Original source code at https://docs.microsoft.com/en-us/azure/azure-monitor/app/worker-service#net-core-30-worker-service-application
     */
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private TelemetryClient _telemetryClient;
        private readonly WorkerOptions _workerOptions;
        private readonly IService _service;

        public Worker(ILogger<Worker> logger, TelemetryClient tc, WorkerOptions workerOptions, IService service)
        {
            _logger = logger;
            _telemetryClient = tc;
            _workerOptions = workerOptions;
            _service = service;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consecutiveException = 0;
            bool result = false;
            int slowness = 0;

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                // TODO Make sure the Worker class name make sense
                // It will ease the tracking of operations on Azure Monitor
                using (_telemetryClient.StartOperation<RequestTelemetry>(nameof(Worker)))
                {
                    _logger.LogWarning("A sample warning message.");
                    _logger.LogInformation("Doing stuff");

                    try
                    {
                        result = await _service.RunAsync();

                        _telemetryClient.TrackEvent("Stuff done with success");
                        consecutiveException = 0;

                    }
                    catch (Exception e)
                    {
                        consecutiveException++;
                        _logger.LogError(e, "WorkerExecutionException {consecutiveFailure}", consecutiveException);

                        if (consecutiveException >= _workerOptions.MaxNbConsecutiveException)
                        {
                            _logger.LogCritical("");
                            throw new WorkerConsecutiveException(consecutiveException, e);
                        }
                    }
                }

                slowness = result
                    ? _workerOptions.ServiceTimer
                    : _workerOptions.ServiceTimer + _workerOptions.SlowServiceTimer + slowness;
                _logger.LogTrace("SlowingTimer {slowness}", slowness);
                await Task.Delay(slowness, stoppingToken);
            }
        }
    }
}
