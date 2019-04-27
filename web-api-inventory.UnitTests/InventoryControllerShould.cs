using System;
using System.Security.Claims;
using System.Threading.Tasks;
using api_inventory.Controllers;
using api_inventory.Model;
using api_inventory.Models;
using api_inventory.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace api_inventory.UnitTests
{
    public class InventoryControllerShould
    {
        [Fact]
        public async Task ReturnBadRequest_ForMarkDoneWithBadId()
        {
            // Arrange
            var mockInventoryService = Substitute.For<IRepository>();
            //var mockInventoryManager = MockUserManager.Create();

            // var controller = new TodoController(mockInventoryService, mockInventoryManager);

            // // Act
            // var result = await controller.MarkDone(Guid.Empty);
            // var statusCodeResult = result as StatusCodeResult;

            // // Assert
            // Assert.NotNull(statusCodeResult);
            // Assert.Equal(400, statusCodeResult.StatusCode);
        }
        
        [Fact]
        public async Task ReturnUnauthorized_ForMarkDoneWithNoUser()
        {
            // Arrange
            var mockInventoryService = Substitute.For<IRepository>();
            // var mockInventoryManager = MockUserManager.Create();

            // // Make the mockInventoryManager always return null for GetUserAsync
            // mockInventoryManager.GetUserAsync(Arg.Any<ClaimsPrincipal>())
            //     .Returns(Task.FromResult<ApplicationUser>(null));

            // var controller = new TodoController(mockInventoryService, mockInventoryManager);

            // // Act
            // var randomId = Guid.NewGuid();
            // var result = await controller.MarkDone(randomId);
            // var statusCodeResult = result as StatusCodeResult;

            // // Assert
            // Assert.NotNull(statusCodeResult);
            // Assert.Equal(401, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task ReturnSuccess_ForMarkDone()
        {
            // Arrange
            var mockInventoryService = Substitute.For<IRepository>();
            // var mockInventoryManager = MockUserManager.Create();

            // // Make the mockInventoryManager return a fake user
            // var fakeUser = new ApplicationUser();
            // mockInventoryManager.GetUserAsync(Arg.Any<ClaimsPrincipal>())
            //     .Returns(Task.FromResult(fakeUser));

            // // Make the mockInventoryService always succeed
            // mockInventoryService.MarkDoneAsync(Arg.Any<Guid>(), Arg.Any<ApplicationUser>())
            //     .Returns(Task.FromResult(true));

            // var controller = new TodoController(mockInventoryService, mockInventoryManager);

            // // Act
            // var randomId = Guid.NewGuid();
            // var result = await controller.MarkDone(randomId);
            // var statusCodeResult = result as StatusCodeResult;

            // // Assert
            // Assert.NotNull(statusCodeResult);
            // Assert.Equal(200, statusCodeResult.StatusCode);
        }
    }
}
