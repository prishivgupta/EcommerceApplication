using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users;
using Users.Commands.AuthCommands;
using Users.Controllers;

namespace Microservices.Tests.Auth.Tests
{
    public class MockTestOnLogin
    {
        private readonly Mock<IMediator> _mockMediator;

        private readonly AuthController _authController;

        public MockTestOnLogin()
        {
            _mockMediator = new Mock<IMediator>();
            _authController = new AuthController(_mockMediator.Object);
        }
        //[Fact]
        //public async Task getAllLoginUsers()
        //{

        //    //Arrange
        //    _mockMediator.Setup(m => m.Send(It.IsAny<LoginUserCommand>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(new UserDTO());

        //    // Act
        //    var result = await _authController.RegisterUser(new Tuser
        //    {

        //        UserEmail = "Shraddha@gmail.com",
        //        UserPassword="1234"


        //    });

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    var actionResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<IEnumerable<Tuser>>(actionResult.Value);
        //    Assert.Equal(1, model.Count());
        //}
    }
}
