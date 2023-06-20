namespace Vculp.Api.Shared.Abstractions.Cqrs;

public enum CommandResultType
{
    Success,
    BadRequest,
    Forbidden,
    NotFound,
    Conflict,
    InvalidResourceType,
    UnprocessableEntity
}
