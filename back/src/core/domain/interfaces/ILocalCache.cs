namespace Tariff.Comparison.Domain.Interfaces;

public interface ILocalQueue
{
    Task Publish(string message);
    Task<string> Consume();
}