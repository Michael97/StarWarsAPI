using Moq;
using StarWarsAPI.Model;
using StarWarsAPI.Services;

namespace StarWarsAPI.Tests
{
    public class JsonSerializerServiceTests
    {
        private readonly Mock<IJsonSerializerService> _jsonSerializerServiceMock;

        public JsonSerializerServiceTests()
        {
            _jsonSerializerServiceMock = new Mock<IJsonSerializerService>();
        }

        [Fact]
        public void Deserialize_ReturnsDeserializedObject()
        {
            // Arrange
            var json = "{\"name\": \"Luke Skywalker\"}";

            _jsonSerializerServiceMock.Setup(s => s.Deserialize<Character>(json))
                .Returns(new Character { Name = "Luke Skywalker" });

            // Act
            var result = _jsonSerializerServiceMock.Object.Deserialize<Character>(json);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Luke Skywalker", result.Name);
        }

        [Fact]
        public void Serialize_ReturnsSerializedObject()
        {
            // Arrange
            var character = new Character { Name = "Luke Skywalker" };

            _jsonSerializerServiceMock.Setup(s => s.Serialize(character))
                .Returns("{\"name\": \"Luke Skywalker\"}");

            // Act
            var result = _jsonSerializerServiceMock.Object.Serialize(character);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("{\"name\": \"Luke Skywalker\"}", result);
        }

    }
}
