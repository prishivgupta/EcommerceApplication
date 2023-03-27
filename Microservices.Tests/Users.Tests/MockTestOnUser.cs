using Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Order.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Controllers;
using Users.Queries;
using Users.Commands.UserCommands;
using Products.Controllers;
using Products.Queries.ProductQueries;

namespace Microservices.Tests.Users.Tests
{
    public class MockTestOnUser
    {
        private readonly Mock<IMediator> _mockMediator;

        private readonly UserController _userController;

        public MockTestOnUser()
        {
            _mockMediator = new Mock<IMediator>();
            _userController = new UserController(_mockMediator.Object);
        }

        [Fact]
        public async Task getAllUsers()
        {
            // Arrange
            var queryResult = new List<Tuser>
        {
            new Tuser { UserId = 1, UserName = "Shraddha", UserAddress = "Bangalore", UserEmail = "Shraddha@gmail.com", UserPassword="1234",UserPhoneNumber="9928",UserRole="Admin"},
            new Tuser { UserId = 2, UserName = "Prishiv", UserAddress = "Bangalore", UserEmail = "Prishiv@gmail.com", UserPassword="1234",UserPhoneNumber="86",UserRole="User" },
            new Tuser { UserId = 3, UserName = "Ravi", UserAddress = "Bangalore", UserEmail = "Ravi@gmail.com", UserPassword="1234",UserPhoneNumber="527816",UserRole="User" }
        };

            //Act
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllUsersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            //Act
            var result = await _userController.GetAllUsers();

            //Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<Tuser>>(actionResult.Value);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task CreateNew_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<AddUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Tuser>());

            // Act
            var result = await _userController.AddUser(new Tuser
            {
                UserId = 1,
                UserName = "Shraddha",
                UserAddress = "Bangalore",
                UserEmail = "Shraddha@gmail.com",
                UserPassword = "1234",
                UserPhoneNumber = "7899876456",
                UserRole = "Admin "
            });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task Update_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Tuser>());
            // Act
            var result = await _userController.UpdateUser(new Tuser
            {
                UserId = 1,
                UserName = "Shraddha",
                UserAddress = "Bangalore",
                UserEmail = "Shraddha@gmail.com",
                UserPassword = "1234",
                UserPhoneNumber = "9972353318",
                UserRole = "Admin"
            });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task Delete_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("User deleted successfully");

            // Act
            var result = await _userController.DeleteUser(1);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task GetUserById_ReturnsUserResult()
        {
            // Arrange
            var queryResult = new Tuser
            {
                UserId = 1,
                UserName = "Shraddha",
                UserAddress = "Bangalore",
                UserEmail = "Shraddha@gmail.com",
                UserPassword = "1234",
                UserPhoneNumber = "9928",
                UserRole = "Admin"

            };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetUserByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _userController.GetuserById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Tuser>(actionResult.Value);
            // Assert.Equal(1, model.Count());
            Assert.Equal(1, model.UserId);
        }
    }
}
