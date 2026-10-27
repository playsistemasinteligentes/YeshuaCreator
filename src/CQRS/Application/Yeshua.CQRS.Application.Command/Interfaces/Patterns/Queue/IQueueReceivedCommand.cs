namespace Command.Interfaces.Patterns.Queue;

// Assigned by the local transport, never taken from the message body.
public interface IQueueReceivedCommand
{
    string QueueName { get; set; }
}
