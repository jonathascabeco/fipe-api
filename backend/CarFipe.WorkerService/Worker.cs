using CarFipe.Jobs;
using Hangfire;

namespace CarFipe.WorkerService;

public class Worker : BackgroundService
{
    private readonly IRecurringJobManager _recurringJobManager;

    public Worker(IRecurringJobManager recurringJobManager)
    {
        _recurringJobManager = recurringJobManager;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _recurringJobManager.AddOrUpdate<CarFipeJob>("FetchCarFipeData", job => job.ExecuteAsync(), Cron.Hourly);
        return Task.CompletedTask;
    }
}
