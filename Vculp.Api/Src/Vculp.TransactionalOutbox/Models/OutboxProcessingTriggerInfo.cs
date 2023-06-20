namespace Vculp.TransactionalOutbox.Models;

public class OutboxProcessingTriggerInfo
{
	public Guid TriggerId { get; set; }

	public DateTime TriggerTime { get; set; }

	public OutboxProcessingTriggerInfo ()
	{
		TriggerId = Guid.NewGuid ();
		TriggerTime = DateTime.UtcNow;
	}
}
