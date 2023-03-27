using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Products.Commands.ProductCommands;
using Products.Controllers;
using Products.Models;
using Products.Queries.ProductQueries;

namespace Microservices.Tests.Products.Tests
{
    public class MockTestOnProducts
    {

        private readonly Mock<IMediator> _mockMediator;

        private readonly ProductController _productController;

        public MockTestOnProducts()
        {
            _mockMediator = new Mock<IMediator>();
            _productController = new ProductController(_mockMediator.Object);
        }

        [Fact]
        public async Task getAllProducts()
        {
            // Arrange
            var queryResult = new List<Tproduct>
        {
            new Tproduct { ProductId = 1, ProductName = "Product 1", ProductPrice = 1000, ProductDiscountedPrice = 200,ProductQuantity=10,ProductDescription="very good",ProductImages="img1",Rating=4 ,CategoryId=1},
            new Tproduct { ProductId = 2, ProductName = "Product 2", ProductPrice = 2000, ProductDiscountedPrice = 300,ProductQuantity=10 ,ProductDescription="very good",ProductImages="img2", Rating=5,CategoryId=1},
            new Tproduct { ProductId = 3, ProductName = "Product 3", ProductPrice = 2000, ProductDiscountedPrice = 200 ,ProductQuantity=10,ProductDescription="very good",ProductImages="img3",Rating=4, CategoryId=1}
        };

            //Act
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllProductsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _productController.GetAllProducts();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Tproduct>>(actionResult.Value);
            Assert.Equal(3, model.Count());


        }

        [Fact]
        public async Task CreateNew_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<AddProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Tproduct>());

            // Act
            var result = await _productController.AddProduct(new Tproduct { ProductId = 1, ProductName = "Product 1", ProductPrice = 1000, ProductDiscountedPrice = 200, ProductQuantity = 10, ProductDescription = "very good", ProductImages = "img1", Rating = 4, CategoryId = 1 });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task Update_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Tproduct>());
            // Act
            var result = await _productController.UpdateProduct(new Tproduct
            {
                ProductId = 1,
                ProductName = "Product Updated",
                ProductPrice = 1000,
                ProductDiscountedPrice = 500,
                ProductQuantity = 10,
                ProductDescription = "very good updated",
                ProductImages = "img updated",
                Rating = 4,
                CategoryId = 1
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
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("Product deleted successfully");

            // Act
            var result = await _productController.DeleteProduct(2);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task GetProductById_ReturnsProductResult()
        {
            // Arrange
            var queryResult = new Tproduct
            {
                ProductId = 1,
                ProductName = "Product 1",
                ProductPrice = 1000,
                ProductDiscountedPrice = 200,
                ProductQuantity = 10,
                ProductDescription = "very good",
                ProductImages = "img1",
                Rating = 4,
                CategoryId = 1

            };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _productController.GetProductById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Tproduct>(actionResult.Value);
            // Assert.Equal(1, model.Count());
            Assert.Equal(1, model.ProductId);
        }

    }
}