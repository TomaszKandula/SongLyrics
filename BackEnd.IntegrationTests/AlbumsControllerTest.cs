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

    public class AlbumsControllerTest : IClassFixture<TestFixture<SongLyrics.Startup>>
    {

        private readonly HttpClient FClient;

        public AlbumsControllerTest(TestFixture<SongLyrics.Startup> ACustomFixture)
        {
            FClient = ACustomFixture.FClient;
        }

        [Theory]
        [InlineData(1)]
        [InlineData(null)]
        public async Task GetAlbums(int? BandId)
        {

            // Arrange
            var LRequest = $"/api/v1/albums/?BandId={BandId}";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnAlbums = JsonConvert.DeserializeObject<ReturnAlbums>(LStringResponse);

            if (BandId != null)
            {
                LReturnAlbums.Albums.Should().HaveCount(15);
            }
            else
            {
                LReturnAlbums.Albums.Select(R => R.AlbumName).ToList()[3].Should().Be("A Night at the Opera");
                LReturnAlbums.Albums.Select(R => R.AlbumName).ToList()[5].Should().Be("News of the World");
                LReturnAlbums.Albums.Select(R => R.AlbumName).ToList()[13].Should().Be("Innuendo");
            }

        }

    }

}
