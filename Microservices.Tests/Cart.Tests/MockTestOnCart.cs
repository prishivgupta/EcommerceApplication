using Cart.Commands;
using Cart.Controllers;
using Products.Models;
using Cart.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Order.Commands;
using Order.Controllers;
using Products.Controllers;
using Products.Queries.ProductQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Tests.Cart.Tests
{
    public class MockOnCart
    {
        private readonly Mock<IMediator> _mockMediator;

        private readonly CartController _cartController;

        public MockOnCart()
        {
            _mockMediator = new Mock<IMediator>();
            _cartController = new CartController(_mockMediator.Object);
        }

        [Fact]
        public async Task ClearCart()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<ClearCartCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("Cart Cleared successfully");

            // Act
            var result = await _cartController.ClearCart(2);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }


        [Fact]
        public async Task getAllCartItems()
        {
            // Arrange
            var queryResult = new List<TcartItem>
        {
            new TcartItem { Id = 1, CartId = 1, ProductId=1, ProductQuantity=1},
            new TcartItem { Id = 2, CartId = 1, ProductId=2, ProductQuantity=1},
            new TcartItem { Id = 3, CartId = 1, ProductId=3, ProductQuantity=1}
        };

            //Act
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllCartItemsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _cartController.GetAllCartItems(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<TcartItem>>(actionResult.Value);
            Assert.Equal(3, model.Count());


        }


        //[Fact]
        //public async Task AddToCart()
        //{
        //    // Arrange
        //    _mockMediator.Setup(m => m.Send(It.IsAny<AddToCartCommand>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(new TcartItem());

        //    // Act
        //    var result = await _cartController.AddToCart(new TcartItem { Id=1,CartId=1,ProductId=1, ProductQuantity=2 });

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    var actionResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<TcartItem>(actionResult.Value);
        //    Assert.Equal( 1,model.Id);
        //}



        //---------------------FAILED TEST CASE(Id inserted-> id=2, assert Equals comparison-> for 1,2 so FAILED)--------------
        //[Fact]
        //public async Task CreateNew_ReturnsCreatedResult()
        //{
        //    // Arrange
        //    _mockMediator.Setup(m => m.Send(It.IsAny<AddToCartCommand>(), It.IsAny<CancellationToken>()))
        //        .ReturnsAsync(new TcartItem());

        //    // Act
        //    var result = await _cartController.AddToCart(new TcartItem { Id=2,CartId=1,ProductId=1, ProductQuantity=2 });

        //    // Assert
        //    Assert.IsType<OkObjectResult>(result);
        //    var actionResult = Assert.IsType<OkObjectResult>(result);
        //    var model = Assert.IsAssignableFrom<TcartItem>(actionResult.Value);
        //    Assert.Equal(1, model.Id);
        //}



    }
}
