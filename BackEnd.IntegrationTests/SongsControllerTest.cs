using Xunit;
using FluentAssertions;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BackEnd.Models.Json;
using BackEnd.IntegrationTests.Configuration;

namespace BackEnd.IntegrationTests
{

    public class SongsControllerTest : IClassFixture<TestFixture<SongLyrics.Startup>>
    {

        private readonly HttpClient FClient;

        public SongsControllerTest(TestFixture<SongLyrics.Startup> ACustomFixture)
        {
            FClient = ACustomFixture.FClient;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        public async Task GetSongs(int? AlbumId)
        {

            // Arrange
            var LRequest = $"/api/v1/songs/?AlbumId={AlbumId}";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnSongs = JsonConvert.DeserializeObject<ReturnSongs>(LStringResponse);

            if (AlbumId != null)
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
        public async Task GetSong(int Id)
        {

            // Arrange
            var LRequest = $"/api/v1/songs/{Id}";

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
