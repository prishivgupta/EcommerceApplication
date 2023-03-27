using Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Order.Commands;
using Order.Controllers;
using Order.Queries;
using Products.Commands.ProductCommands;
using Products.Controllers;


namespace Microservices.Tests.Order.Tests
{
    public class MockTestOnOrder
    {
        private readonly Mock<IMediator> _mockMediator;

        private readonly OrderController _orderController;

        public MockTestOnOrder()
        {
            _mockMediator = new Mock<IMediator>();
            _orderController = new OrderController(_mockMediator.Object);
        }

        [Fact]
        public async Task getAllOrders()
        {
            // Arrange
            var queryResult = new List<Torder>
        {
            new Torder { OrderId = 1, OrderStatus = "Pending", UserId = 1, CartId = 2,ShipmentAddress="Bangalore"},
            new Torder { OrderId = 2, OrderStatus = "Pending", UserId = 1, CartId = 2,ShipmentAddress="Manglore" },
            new Torder { OrderId = 3, OrderStatus = "Pending", UserId = 1, CartId = 2,ShipmentAddress="Chennai" }
        };

            //Act
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllOrdersQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _orderController.GetAllOrders();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Torder>>(actionResult.Value);
            Assert.Equal(3, model.Count());

        }

        [Fact]
        public async Task CreateNew_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<PlaceOrderCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Torder>());

            // Act
            var result = await _orderController.PlaceOrder(new Torder { OrderId = 1, OrderStatus = "Pending", UserId = 1, CartId = 2, ShipmentAddress = "Bangalore" });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task Update_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateOrderCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Torder>());
            // Act
            var result = await _orderController.UpdateOrder(new Torder
            {
                OrderId = 1,
                OrderStatus = "Pending",
                UserId = 1,
                CartId = 2,
                ShipmentAddress = "Bangalore"
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
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteOrderCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("order deleted successfully");

            // Act
            var result = await _orderController.DeleteOrder(2);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task GetOrderById_ReturnsProductResult()
        {
            // Arrange
            var queryResult = new Torder
            {
                OrderId = 1,
                OrderStatus = "Pending",
                UserId = 1,
                CartId = 2,
                ShipmentAddress = "Bangalore"

            };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetOrderByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _orderController.GetOrderById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Torder>(actionResult.Value);
            // Assert.Equal(1, model.Count());
            Assert.Equal(1, model.OrderId);
        }

    }
}

