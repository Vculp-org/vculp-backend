namespace Vculp.Api.Shared.Abstractions.Cqrs;

public interface ICommand
{
    Guid CommandId { get; }
}
