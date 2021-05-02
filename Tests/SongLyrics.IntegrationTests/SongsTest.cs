using Xunit;
using FluentAssertions;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SongLyrics.Shared.Dto;
using SongLyrics.IntegrationTests.Configuration;

namespace SongLyrics.IntegrationTests
{
    public class SongsTest : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient FClient;

        public SongsTest(TestFixture<Startup> ACustomFixture)
            => FClient = ACustomFixture.Client;

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        public async Task Should_GetSongs(int? AAlbumId)
        {
            // Arrange
            var LRequest = $"/api/v1/songs/?AlbumId={AAlbumId}";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Assert
            LResponse.EnsureSuccessStatusCode();
            LResponse.Should().NotBeNull();

            var LContent = await LResponse.Content.ReadAsStringAsync();
            LContent.Should().NotBeNullOrEmpty();

            var LDeserialized = JsonConvert.DeserializeObject<ReturnSongsDto>(LContent);
            if (AAlbumId != null)
            {
                LDeserialized.Songs.Should().HaveCount(10);
            }
            else
            {
                LDeserialized.Songs.Should().HaveCount(10);
            }
        }

        [Theory]
        [InlineData(6)]
        public async Task Should_GetSong(int AId)
        {
            // Arrange
            var LRequest = $"/api/v1/songs/{AId}";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Assert
            LResponse.EnsureSuccessStatusCode();
            LResponse.Should().NotBeNull();

            var LContent = await LResponse.Content.ReadAsStringAsync();
            LContent.Should().NotBeNullOrEmpty();

            var LReturnSongs = JsonConvert.DeserializeObject<ReturnSongDto>(LContent);
            LReturnSongs.Song.Name.Should().Be("The Night Comes Down");
        }
    }
}
