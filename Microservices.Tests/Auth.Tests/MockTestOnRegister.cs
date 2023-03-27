using Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Users.Commands.AuthCommands;
using Users.Controllers;
using Users;

namespace Microservices.Tests.Auth.Tests
{
    public class MockTestOnRegister
    {

        private readonly Mock<IMediator> _mockMediator;

        private readonly AuthController _authController;

        public MockTestOnRegister()
        {
            _mockMediator = new Mock<IMediator>();
            _authController = new AuthController(_mockMediator.Object);
        }

        [Fact]
        public async Task getAllRegisteredUsers()
        {

            //Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new UserDTO());

            // Act
            var result = await _authController.RegisterUser(new Tuser
            {
                UserId = 1,
                UserName = "Shraddha",
                UserAddress = "Bangalore",
                UserEmail = "Shraddha@gmail.com",
                UserPassword = "1234",
                UserPhoneNumber = "7899876456",
                UserRole = "Admin ",
                CartId = 1
            });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }


    }
}
