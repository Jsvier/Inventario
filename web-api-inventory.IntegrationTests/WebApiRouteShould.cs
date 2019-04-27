using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace WebApi.IntegrationTests
{
    public class WebApiRouteShould : IClassFixture<TestFixture>
    {
        private readonly HttpClient _client;

        public WebApiRouteShould(TestFixture fixture)
        {
            _client = fixture.Client;
        }

        [Fact]
        public async Task ChallengeAnonymousUser()
        {
            // Arrange
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/Version");

            // Act: request the /api route
            var response = await _client.SendAsync(request);

            // Assert: anonymous user
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.Equal("http://localhost:5001/api/Version",
                        response.Headers.Location.ToString());
        }
    }
}
