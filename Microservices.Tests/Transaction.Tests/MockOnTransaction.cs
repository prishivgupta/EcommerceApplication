using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Payment.Commands;
using Payment.Controllers;
using Payment.Models;
using Payment.Queries;
using Products.Commands.CategoryCommands;
using Products.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Commands;

namespace Microservices.Tests.Transaction.Tests
{   
    public class MockOnTransaction
    {
        private readonly Mock<IMediator> _mockMediator;

        private readonly TransactionController _transactionController;

        public MockOnTransaction()
        {
            _mockMediator = new Mock<IMediator>();
            _transactionController = new TransactionController(_mockMediator.Object);
        }

        [Fact]
        public async Task getAllTransactions()
        {
            // Arrange
            var queryResult = new List<TransactionDetails>
        {
            new TransactionDetails { id="1",OrderId=1,UserName = "User1", UserEmail = "UserEmail 1",PaymentMethod="card",PaymentStatus="pending",ShipmentAddress="Bangalore"},
            new TransactionDetails { id="2",OrderId=2,UserName = "User2", UserEmail = "UserEmail 2",PaymentMethod="cash",PaymentStatus="completed",ShipmentAddress="Bangalore"},
            new TransactionDetails { id="3",OrderId=3,UserName = "User3", UserEmail = "UserEmail 3",PaymentMethod="card",PaymentStatus="pending",ShipmentAddress="Bangalore"}
        };

            //Act
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllTransactionsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _transactionController.GetTransactions();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<TransactionDetails>>(actionResult.Value);
            Assert.Equal(3, model.Count());


        }
        [Fact]
        public async Task CreateNew_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<AddTransactionCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("added");

            // Act
            var result = await _transactionController.CreateNew(new TransactionDetails { id="1", OrderId=1, UserName = "User1", UserEmail = "UserEmail 1", PaymentMethod="card", PaymentStatus="pending", ShipmentAddress="Bangalore" });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }



        [Fact]
        public async Task Update_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateTransactionCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("updated");
            // Act
            var result = await _transactionController.UpdateTransaction("User1", new TransactionDetails
            {
                id="1",
                OrderId=1,
                UserName = "User1",
                UserEmail = "UserEmail 1",
                PaymentMethod="card",
                PaymentStatus="pending",
                ShipmentAddress="Bangalore"
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
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteTransactionCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("deleted successfully");

            // Act
            var result = await _transactionController.DeleteTransaction("123");

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(200, actionResult.StatusCode);
        }

        [Fact]
        public async Task GetTransactionById_ReturnsProductResult()
        {
            // Arrange
            var queryResult = new TransactionDetails
            {
                id="1",
                OrderId=1,
                UserName = "User1",
                UserEmail = "UserEmail 1",
                PaymentMethod="card",
                PaymentStatus="pending",
                ShipmentAddress="Bangalore"
            };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetTransactionByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _transactionController.GetTransactionByid("User1");

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<TransactionDetails>(actionResult.Value);
            // Assert.Equal(1, model.Count());
            Assert.Equal("1", model.id);
        }
    }
}
