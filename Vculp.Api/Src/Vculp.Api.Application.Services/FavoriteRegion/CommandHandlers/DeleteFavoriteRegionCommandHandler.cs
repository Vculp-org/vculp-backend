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
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.FavoriteRegion;

namespace Vculp.Api.Application.Services.FavoriteRegion.CommandHandlers
{
    public class DeleteFavoriteRegionCommandHandler : CommandHandler,
    IRequestHandler<DeleteFavoriteRegionCommand, ICommandResult<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFavoriteRegionRepository _favoriteRegionRepository;

        public DeleteFavoriteRegionCommandHandler(IUnitOfWork unitOfWork, IFavoriteRegionRepository favoriteRegionRepository, IStringLocalizer<CommandHandlerErrors> stringLocalizer) : base(stringLocalizer)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _favoriteRegionRepository = favoriteRegionRepository ?? throw new ArgumentNullException(nameof(favoriteRegionRepository));
        }

        public async Task<ICommandResult<bool>> Handle(DeleteFavoriteRegionCommand request, CancellationToken cancellationToken)
        {
          
                if (request == null)
                {
                    throw new ArgumentNullException(nameof(request));
                }

                //Check favoriteRegion exist
                var favoriteRegion = await _favoriteRegionRepository.GetByIdAsync(request.FavoriteRegionId);

                if (favoriteRegion == null)
                {
                    return new NotFoundCommandResult<bool>();
                }

                favoriteRegion.Deleted();

                await _unitOfWork.SaveChangesAsync();
                var successResult = new SuccessCommandResult<bool>();
                successResult.SetResult(true);
                return successResult;
            
        }
    }
}
