using global::RabbitMQ.Client;
using Microsoft.Extensions.Options;
using Shared.InterfacesConcrete.Queue.RabbitMQ;
using System.Collections.Concurrent;

namespace Shered.ConcretInterfaces.Queue.RabbitMQ;

public sealed class RabbitMqConnectionManager : IDisposable
{
    private readonly RabbitMqOptions _options;

    private IConnection? _connection;
    private readonly SemaphoreSlim _connectionLock = new(1, 1);

    private readonly ConcurrentDictionary<string, IChannel> _channels = new();
    private readonly ConcurrentDictionary<string, SemaphoreSlim> _channelLocks = new();

    public RabbitMqConnectionManager(IOptions<RabbitMqOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IConnection> GetConnectionAsync(CancellationToken ct = default)
    {
        if (_connection != null && _connection.IsOpen)
            return _connection;

        await _connectionLock.WaitAsync(ct);
        try
        {
            if (_connection != null && _connection.IsOpen)
                return _connection;

            var factory = new ConnectionFactory
            {
                HostName = _options.HostName,
                Port = _options.Port,
                UserName = _options.UserName,
                Password = _options.Password,
                VirtualHost = _options.VirtualHost,
                AutomaticRecoveryEnabled = true,
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10)
            };

            _connection = await factory.CreateConnectionAsync(ct);
            return _connection;
        }
        finally
        {
            _connectionLock.Release();
        }
    }

    // pendencia implementar o confirmar RabbitMqConfirmListener
    /*ConnectionManager
    Channel
    ConfirmTracker
    Ack/Nack Listener
Publisher
    Register DeliveryTag
    Publish
    Await Confirm
Worker
    Update Outbox*/

    public async Task<IChannel> GetChannelAsync(string channelId, CancellationToken ct = default)
    {
        if (_channels.TryGetValue(channelId, out var existingChannel))
        {
            if (existingChannel.IsOpen)
                return existingChannel;
        }

        var channelLock = _channelLocks.GetOrAdd(channelId, _ => new SemaphoreSlim(1, 1));

        await channelLock.WaitAsync(ct);
        try
        {
            if (_channels.TryGetValue(channelId, out existingChannel))
            {
                if (existingChannel.IsOpen)
                    return existingChannel;

                existingChannel.Dispose();
            }

            var connection = await GetConnectionAsync(ct);

            var channel = await connection.CreateChannelAsync(null, ct);

            _channels[channelId] = channel;

            return channel;
        }
        finally
        {
            channelLock.Release();
        }
    }
    public void Dispose()
    {
        foreach (var ch in _channels.Values)
            ch.Dispose();

        _connection?.Dispose();
    }
}