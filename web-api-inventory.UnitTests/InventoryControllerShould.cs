using System.Net;
using System.Threading.Tasks;
//using AngleSharp.Dom.Html;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
//using RazorPagesProject.Services;
//using RazorPagesProject.Tests.Helpers;

namespace api_inventory.UnitTests
{
    public class InventoryControllerShould : IClassFixture<WebApplicationFactory<api_inventory.Startup>>
    {
        private readonly WebApplicationFactory<api_inventory.Startup> _factory;

        public InventoryControllerShould(WebApplicationFactory<api_inventory.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ReturnGoodRequest_Version()
        {
               // Arrange
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync("/api/Version");

            // Assert
            Assert.NotNull(response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
        
        [Fact]
        public async Task ReturnGoodRequest_Store()
        {
            
               // Arrange
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync("/api/Store");

            // Assert
            Assert.NotNull(response.StatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        

        [Fact]
        public async Task ReturnSuccess_Inventories()
        {
            
        }
        [Fact]
        public async Task ReturnSuccess_Inventory_ByID()
        {

        }
    }
}
