namespace Vculp.DDD.Shared;
public interface IDomainEvent
{
    Guid EventId { get; }

    DateTime EventTime { get; }
}