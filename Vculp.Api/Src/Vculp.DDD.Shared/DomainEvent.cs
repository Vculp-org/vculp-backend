namespace Vculp.DDD.Shared;

public abstract class DomainEvent : IDomainEvent
{
    public Guid EventId { get; private set; }

    public DateTime EventTime { get; private set; }

    protected DomainEvent ()
    {
        EventId = Guid.NewGuid ();
        EventTime = DateTime.UtcNow;
    }
}