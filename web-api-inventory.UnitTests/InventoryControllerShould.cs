using System;
using System.Security.Claims;
using System.Threading.Tasks;
using api_inventory.Controllers;
using api_inventory.Model;
using api_inventory.Models;
using api_inventory.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NSubstitute;
using Xunit;

namespace api_inventory.UnitTests
{
    public class InventoryControllerShould
    {
        [Fact]
        public async Task ReturnGoodRequest_Version()
        {
            // Arrange
            var mockInventoryService = Substitute.For<IRepository>();

             var controller = new InventoryController(mockInventoryService);

             // Act
             var result =  controller.Version();
             
             var statusCodeResult = result as StatusCodeResult;

             // Assert
             Assert.NotNull(statusCodeResult);
             Assert.Equal(200, statusCodeResult.StatusCode);
        }
        
        [Fact]
        public async Task ReturnGoodRequest_Store()
        {
            // Arrange
            var mockInventoryService = Substitute.For<IRepository>();

             var controller = new InventoryController(mockInventoryService);

             // Act
             var result =  controller.Store();
             
             var statusCodeResult = result as StatusCodeResult;

             // Assert
             Assert.NotNull(statusCodeResult);
             Assert.Equal(200, statusCodeResult.StatusCode);
        }
        

        [Fact]
        public async Task ReturnSuccess_Inventories()
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
        [Fact]
        public async Task ReturnSuccess_Inventory_ByID()
        {
            // Arrange
            var mockInventoryService = Substitute.For<IRepository>();
        }
    }
}
