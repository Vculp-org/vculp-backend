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
    public class UpdateFavoriteRegionCommandHandler : CommandHandler,
    IRequestHandler<UpdateFavoriteRegionCommand, ICommandResult<FavoriteRegionResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFavoriteRegionRepository _favoriteRegionRepository;

        public UpdateFavoriteRegionCommandHandler(IUnitOfWork unitOfWork, IFavoriteRegionRepository favoriteRegionRepository, IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _favoriteRegionRepository = favoriteRegionRepository ?? throw new ArgumentNullException(nameof(favoriteRegionRepository));
        }

        public async Task<ICommandResult<FavoriteRegionResponse>> Handle(UpdateFavoriteRegionCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            //Check favoriteRegion exist
            var favoriteRegion = await _favoriteRegionRepository.GetByIdAsync(request.FavoriteRegionId);

            if (favoriteRegion == null)
            {
                return new NotFoundCommandResult<FavoriteRegionResponse>();
            }

            if (!string.IsNullOrWhiteSpace(request.Body.Name))
            {
                var isExists = await _favoriteRegionRepository.ExistWithNameAsync(request.Body.Name);

                if (isExists)
                {
                    var conflictResult = new ConflictCommandResult<FavoriteRegionResponse>();

                    conflictResult.AddError(
                        new OperationError(
                            "NameIsInUse",
                            Localizer["UpdateFavoriteRegionCommandHandler_NameIsInUse"]));

                    return conflictResult;
                }
                favoriteRegion.ChangeName(request.Body.Name);
            }

            if (!string.IsNullOrWhiteSpace(request.Body.AreaName))
            {
                favoriteRegion.ChangeAreaName(request.Body.AreaName);
            }
            if(request.Body.Radius != 0)
            {
                favoriteRegion.ChangeRadius(request.Body.Radius);
            }
        
            if(request.Body.Latitude != 0)
            {
                favoriteRegion.ChangeLatitude(request.Body.Latitude);
            }
            if(request.Body.Longitude != 0)
            {
                favoriteRegion.ChangeLongitude(request.Body.Longitude);
            }
          
            if (request.Body.IsActive.HasValue)
                favoriteRegion.Activate();
            else
                favoriteRegion.Deactivate();

            await _unitOfWork.SaveChangesAsync();

            var response = FavoriteRegionMapper.MapToFavoriteRegionResponse(favoriteRegion);

            var successResult = new SuccessCommandResult<FavoriteRegionResponse>();
            successResult.SetResult(response);

            return successResult;
        }
    }
}
