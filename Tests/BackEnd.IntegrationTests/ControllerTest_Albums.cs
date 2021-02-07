using Xunit;
using FluentAssertions;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SongLyrics.Shared.Dto;
using SongLyrics.IntegrationTests.Configuration;

namespace SongLyrics.IntegrationTests
{
    public class ControllerTest_Albums : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient FClient;

        public ControllerTest_Albums(TestFixture<Startup> ACustomFixture)
        {
            FClient = ACustomFixture.FClient;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        public async Task Should_GetAlbums(int? AArtistId)
        {
            // Arrange
            var LRequest = $"/api/v1/albums/?ArtistId={AArtistId}";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Assert
            LResponse.EnsureSuccessStatusCode();
            LResponse.Should().NotBeNull();

            var LContent = await LResponse.Content.ReadAsStringAsync();
            LContent.Should().NotBeNullOrEmpty();

            var LDeserialized = JsonConvert.DeserializeObject<ReturnAlbumsDto>(LContent);
            if (AArtistId != null)
            {
                LDeserialized.Albums.Should().HaveCount(15);
            }
            else
            {
                LDeserialized.Albums.Select(AAlbum => AAlbum.AlbumName).ToList()[3].Should().Be("A Night at the Opera");
                LDeserialized.Albums.Select(AAlbum => AAlbum.AlbumName).ToList()[5].Should().Be("News of the World");
                LDeserialized.Albums.Select(AAlbum => AAlbum.AlbumName).ToList()[13].Should().Be("Innuendo");
            }
        }
    }
}
