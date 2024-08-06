using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Tariff.Comparison.Domain.Interfaces.Worker;
using Tariff.Comparison.Domain.Model;

namespace Tariff.Comparison.Consumer.Worker.Background;

public class ProductConsumerBackgroundWorker(IServiceProvider serviceProvider,ILogger<ProductConsumerBackgroundWorker> logger) : BackgroundService
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly ILogger<ProductConsumerBackgroundWorker> _logger = logger;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (stoppingToken.IsCancellationRequested == false)
        {
            using IServiceScope scope = _serviceProvider.CreateScope();
            IQueueConsumerService queueConsumer = scope.ServiceProvider.GetRequiredService<IQueueConsumerService>();
            IProductConsumerWorker worker = scope.ServiceProvider.GetRequiredService<IProductConsumerWorker>();   
            Product? product = await queueConsumer.Consume();
            if (product == null)
            {
                int seconds = 5;
                _logger.LogInformation($"Wait {seconds} empty queue");
                await Task.Delay(TimeSpan.FromSeconds(seconds), stoppingToken);
            }
            else
            {
                try
                {
                    await worker.HandleProduct(product);
                }
                catch (Exception e)
                {
                    string message = $"Error ao tratar produto consumido. {e.Message}";
                    _logger.LogError(message);   
                }
            }

        }        
    }
}
