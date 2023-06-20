namespace Vculp.TransactionalOutbox.Models;

public abstract class OutboxMessage
{
    public Guid Id { get; private set; }

    public object Payload { get; private set; }

    public string PayloadType { get; private set; }

    public DateTime CreationTime { get; private set; }

    public bool Processed => ProcessedTime.HasValue;

    public DateTime? ProcessedTime { get; private set; }

    public OutboxMessage (object payload)
    {
        Id = Guid.NewGuid ();
        CreationTime = DateTime.UtcNow;
        Payload = payload ?? throw new ArgumentNullException ("payload");
        PayloadType = payload.GetType ().FullName;
    }

    public void MarkAsProcessed ()
    {
        if (!Processed) {
            ProcessedTime = DateTime.UtcNow;
        }
    }
}