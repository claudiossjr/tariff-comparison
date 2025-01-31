using System.Threading.Channels;
using Tariff.Comparison.Domain.Interfaces;

namespace Tariff.Comparison.Provider.Queue.Local;

public class LocalQueue : ILocalQueue
{
    private readonly Channel<string> _channel; 
    public LocalQueue()
    {
        _channel = Channel.CreateUnbounded<string>();
    }

    public async Task<string> Consume(CancellationToken token)
    {
        return await _channel.Reader.ReadAsync(token);
    }

    public async Task Publish(string message)
    {
        await _channel.Writer.WriteAsync(message);
    }
}