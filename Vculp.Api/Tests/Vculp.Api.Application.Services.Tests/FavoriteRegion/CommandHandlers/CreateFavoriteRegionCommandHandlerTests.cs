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
   
    public class CreateFavoriteRegionCommandHandlerTests
    {
        private readonly Mock<IUnitOfWork> unitofWorkMock;
        private readonly Mock<IFavoriteRegionRepository> favRegionRepositoryMock;
        private readonly Mock<IStringLocalizer<CommandHandlerErrors>> stringLocalizerMock;

        public CreateFavoriteRegionCommandHandlerTests()
        {
            unitofWorkMock = new();
            favRegionRepositoryMock = new();
            stringLocalizerMock = new();
        }
        [Fact]
        public async Task Handle_Should_ThrowException_WhenRequestIsNull()
        {
            //Arrange
            var command = new CreateFavoriteRegionCommand();
            var handler = new CreateFavoriteRegionCommandHandler(unitofWorkMock.Object, favRegionRepositoryMock.Object,stringLocalizerMock.Object);
            //Act and Assert
             await  Assert.ThrowsAsync<ArgumentNullException>(()=> handler.Handle(null, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_Should_ReturnFailure_WhenNamenotUnique()
        {
            //Arrange
            var command = new CreateFavoriteRegionCommand
            {
                Name = "Test",
                AreaName = "TestArea",
                Latitude = 9,
                Longitude = 8,
                Radius = 20,
                UserId = Guid.Empty
            };
            
            string key = "CreateFavoriteRegionCommandHandler_NameIsInUse";
            var localizedString = new LocalizedString(key, "In use");
            stringLocalizerMock.Setup(_ => _[key]).Returns(localizedString);
            favRegionRepositoryMock.Setup(x => x.ExistWithNameAsync(It.IsAny<string>())).ReturnsAsync(true);

            var handler = new CreateFavoriteRegionCommandHandler(unitofWorkMock.Object, favRegionRepositoryMock.Object, stringLocalizerMock.Object);
            //Act 
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.Equal(CommandResultType.Conflict, response.ResultType);
            
        }

        [Fact]
        public async Task Handle_Should_Add_WhenNameisUnique()
        {
            //Arrange
            var command = new CreateFavoriteRegionCommand
            {
                Name = "Test",
                AreaName = "TestArea",
                Latitude = 9,
                Longitude = 8,
                Radius = 20,
                UserId = Guid.Empty
            };

            string key = "CreateFavoriteRegionCommandHandler_NameIsInUse";
            var localizedString = new LocalizedString(key, "In use");
            stringLocalizerMock.Setup(_ => _[key]).Returns(localizedString);
            favRegionRepositoryMock.Setup(x => x.ExistWithNameAsync(It.IsAny<string>())).ReturnsAsync(false);

            var handler = new CreateFavoriteRegionCommandHandler(unitofWorkMock.Object, favRegionRepositoryMock.Object, stringLocalizerMock.Object);
            //Act 
            var response = await handler.Handle(command, CancellationToken.None);

            //Assert
            favRegionRepositoryMock.Verify(x => x.Add(It.Is<Domain.Core.FavoriteRegion.FavoriteRegion>(x => x.Id == response.Result.FavoriteRegionId)), Times.Once);
        }
    }
}
