using System;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Vculp.Api.Shared.Abstractions.Cqrs;

namespace Vculp.Api.Common.Location.Commands;

public class AddFavoriteLocationCommand : IRequest<Common.ICommandResult>, ICommand
{
    public AddFavoriteLocationCommand()
    {
        CommandId = Guid.NewGuid();
    }

    [BindNever] public Guid CommandId { get; }

    public Guid UserId { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string LocationType { get; set; }
}