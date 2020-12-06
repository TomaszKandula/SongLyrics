using Xunit;
using FluentAssertions;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SongLyrics.Controllers.Songs.Models;
using SongLyrics.IntegrationTests.Configuration;

namespace SongLyrics.IntegrationTests
{

    public class ControllerTest_Songs : IClassFixture<TestFixture<Startup>>
    {

        private readonly HttpClient FClient;

        public ControllerTest_Songs(TestFixture<Startup> ACustomFixture)
        {
            FClient = ACustomFixture.FClient;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        public async Task Should_GetSongs(int? AAlbumId)
        {

            // Arrange
            var LRequest = $"/api/v1/songs/?AlbumId={AAlbumId}";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnSongs = JsonConvert.DeserializeObject<ReturnSongs>(LStringResponse);

            if (AAlbumId != null)
            {
                LReturnSongs.Songs.Should().HaveCount(10);
            }
            else
            {
                LReturnSongs.Songs.Should().HaveCount(10);
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

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnSongs = JsonConvert.DeserializeObject<ReturnSong>(LStringResponse);

            LReturnSongs.Song.Name.Should().Be("The Night Comes Down");

        }

    }

}
