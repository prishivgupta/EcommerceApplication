using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Products.Commands.CategoryCommands;
using Products.Controllers;
using Products.Models;
using Products.Queries.CategoryQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Tests.Categories.Tests
{
    public class MockTestOnCategories
    {
        private readonly Mock<IMediator> _mockMediator;

        private readonly CategoryController _categoryController;

        public MockTestOnCategories()
        {
            _mockMediator = new Mock<IMediator>();
            _categoryController = new CategoryController(_mockMediator.Object);
        }

        [Fact]
        public async Task getAllCategories()
        {
            // Arrange
            var queryResult = new List<Tcategory>
        {
            new Tcategory { CategoryId = 1, CategoryName = "Category 1"},
            new Tcategory { CategoryId = 2, CategoryName = "Category 2"},
            new Tcategory { CategoryId = 3, CategoryName = "Category 1"}
        };

            //Act
            _mockMediator.Setup(m => m.Send(It.IsAny<GetAllCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _categoryController.GetAllCategories();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Tcategory>>(actionResult.Value);
            Assert.Equal(3, model.Count());


        }

        [Fact]
        public async Task CreateNew_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<AddCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Tcategory>());

            // Act
            var result = await _categoryController.AddCategory(new Tcategory { CategoryId = 1, CategoryName = "Category 1" });

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task Update_ReturnsCreatedResult()
        {
            // Arrange
            _mockMediator.Setup(m => m.Send(It.IsAny<UpdateCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Tcategory>());
            // Act
            var result = await _categoryController.UpdateCategory(new Tcategory
            {
                CategoryId = 1,
                CategoryName = "Category 1 Updated"
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
            _mockMediator.Setup(m => m.Send(It.IsAny<DeleteCategoryCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync("Category deleted successfully");

            // Act
            var result = await _categoryController.DeleteCategory(2);

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var actionResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(201, actionResult.StatusCode);
        }

        [Fact]
        public async Task GetCategoryById_ReturnsProductResult()
        {
            // Arrange
            var queryResult = new Tcategory
            {
                CategoryId = 1,
                CategoryName = "Category1"

            };
            _mockMediator.Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(queryResult);

            // Act
            var result = await _categoryController.GetCategoryById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Tcategory>(actionResult.Value);
            Assert.Equal(1, model.CategoryId);
        }
    }
}
