using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FavoriteRegion.Commands;
using Vculp.Api.Common.FavoriteRegion.Mappers;
using Vculp.Api.Common.FavoriteRegion.Responses;
using Vculp.Api.Common.User.Commands;
using Vculp.Api.Common.User.Mappers;
using Vculp.Api.Common.User.Responses;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.FavoriteRegion;
using Vculp.Api.Domain.Interfaces.User;

namespace Vculp.Api.Application.Services.FavoriteRegion.CommandHandlers
{
    public class CreateFavoriteRegionCommandHandler : CommandHandler,
    IRequestHandler<CreateFavoriteRegionCommand, ICommandResult<FavoriteRegionResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFavoriteRegionRepository _favoriteRegionRepository;

        public CreateFavoriteRegionCommandHandler(
            IUnitOfWork unitOfWork,
            IFavoriteRegionRepository favoriteRegionRepository,
            IStringLocalizer<CommandHandlerErrors> stringLocalizer)
            : base(stringLocalizer)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _favoriteRegionRepository = favoriteRegionRepository ?? throw new ArgumentNullException(nameof(favoriteRegionRepository));
        }

        public async Task<ICommandResult<FavoriteRegionResponse>> Handle(CreateFavoriteRegionCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            //Check name already exist
            var isExists = await _favoriteRegionRepository.ExistWithNameAsync(request.Name);

            if (isExists)
            {
                var conflictResult = new ConflictCommandResult<FavoriteRegionResponse>();

                conflictResult.AddError(
                    new OperationError(
                        "NameIsInUse",
                        Localizer["CreateFavoriteRegionCommandHandler_NameIsInUse"]));

                return conflictResult;
            }

            var favoriteRegion = new Domain.Core.FavoriteRegion.FavoriteRegion(name:request.Name,areaName:request.AreaName,
                latitute:request.Latitude,longtitude:request.Longitude,radius:request.Radius, userId:request.UserId);
            favoriteRegion.Activate();
            _favoriteRegionRepository.Add(favoriteRegion);
            await _unitOfWork.SaveChangesAsync();

            var response = FavoriteRegionMapper.MapToFavoriteRegionResponse(favoriteRegion);

            var successResult = new SuccessCommandResult<FavoriteRegionResponse>();
            successResult.SetResult(response);

            return successResult;
        }
    }
}
