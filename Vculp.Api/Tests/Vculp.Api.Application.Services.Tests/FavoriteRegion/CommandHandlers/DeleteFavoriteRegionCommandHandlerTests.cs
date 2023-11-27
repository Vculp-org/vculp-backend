using Microsoft.Extensions.Localization;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vculp.Api.Application.Services.Common;
using Vculp.Api.Application.Services.FavoriteRegion.CommandHandlers;
using Vculp.Api.Common.Common;
using Vculp.Api.Common.FavoriteRegion.Commands;
using Vculp.Api.Domain.Interfaces.Common;
using Vculp.Api.Domain.Interfaces.FavoriteRegion;

namespace Vculp.Api.Application.Services.Tests.FavoriteRegion.CommandHandlers
{
   
    public class DeleteFavoriteRegionCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> unitofWorkMock;
        private readonly Mock<IFavoriteRegionRepository> favRegionRepositoryMock;
        private readonly Mock<IStringLocalizer<CommandHandlerErrors>> stringLocalizerMock;

        public DeleteFavoriteRegionCommandHandlerTests()
        {
            unitofWorkMock = new();
            favRegionRepositoryMock = new();
            stringLocalizerMock = new();
        }
        [Fact]
        public async Task Handle_Should_ThrowException_WhenRequestIsNull()
        {
            //Arrange
            var command = new UpdateFavoriteRegionCommand();
            var handler = new UpdateFavoriteRegionCommandHandler(unitofWorkMock.Object, favRegionRepositoryMock.Object,stringLocalizerMock.Object);
            //Act and Assert
             await  Assert.ThrowsAsync<ArgumentNullException>(()=> handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenIdNotFound()
        {
            //Arrange
            Guid.TryParse("d79efa04-5d68-4eda-8541-83d21666c0a0", out var testGuid);
            var command = new DeleteFavoriteRegionCommand
            {
                FavoriteRegionId = testGuid,
            };

            favRegionRepositoryMock.Setup(x => x.ExistWithNameAsync(It.IsAny<string>())).ReturnsAsync(true);
            Domain.Core.FavoriteRegion.FavoriteRegion favoriteRegion = null;
            favRegionRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(favoriteRegion);
            var handler = new DeleteFavoriteRegionCommandHandler(unitofWorkMock.Object, favRegionRepositoryMock.Object, stringLocalizerMock.Object);
            //Act 
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.Equal(CommandResultType.NotFound, response.ResultType);

        }

        [Fact]
        public async Task Handle_Should_Delete()
        {
            //Arrange
            Guid.TryParse("d79efa04-5d68-4eda-8541-83d21666c0a0", out var testGuid);
            var command = new DeleteFavoriteRegionCommand
            {
                FavoriteRegionId = testGuid,
            };
           
            Mock<Domain.Core.FavoriteRegion.FavoriteRegion> mockRegion = new ("Test","TestArea",10,20,40,Guid.Empty);
            favRegionRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(mockRegion.Object);
            var handler = new DeleteFavoriteRegionCommandHandler(unitofWorkMock.Object, favRegionRepositoryMock.Object, stringLocalizerMock.Object);
            //Act 
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            unitofWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            Assert.Equal(CommandResultType.Success, response.ResultType);
        }
    }
}
