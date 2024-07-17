using Moq.Protected;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StarWarsAPI.Services;
using StarWarsAPI.Model;

namespace StarWarsAPI.Tests
{
    public class ApiServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;
        private readonly Mock<IJsonSerializerService> _jsonSerializerServiceMock;
        private readonly ApiService _apiService;

        public ApiServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
            _jsonSerializerServiceMock = new Mock<IJsonSerializerService>();
            _apiService = new ApiService(_httpClient, _jsonSerializerServiceMock.Object);
        }

        [Fact]
        public async Task GetAsync_ValidResponse_ReturnsDeserializedObject()
        {
            // Arrange
            var endpoint = "https://swapi.dev/api/people/1/";
            var jsonResponse = "{\"name\": \"Luke Skywalker\"}";

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponse)
            };

            //Fake Http message saying it worked
            _httpMessageHandlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(httpResponse);


            _jsonSerializerServiceMock.Setup(s => s.Deserialize<Character>(jsonResponse))
                .Returns(new Character { Name = "Luke Skywalker" });

            // Act
            var result = await _apiService.GetAsync<Character>(endpoint);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Luke Skywalker", result.Name);
        }
    }
}
