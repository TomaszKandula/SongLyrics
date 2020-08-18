using Xunit;
using FluentAssertions;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BackEnd.Models.Json;
using BackEnd.IntegrationTests;

namespace SongLyricsBackEnd.IntegrationTests
{

    public class IntegrationTests : IClassFixture<TestFixture<SongLyrics.Startup>>
    {

        private readonly HttpClient FClient;

        public IntegrationTests(TestFixture<SongLyrics.Startup> ACustomFixture)
        {
            FClient = ACustomFixture.FClient;
        }

        [Fact]
        public async Task GetBands() 
        {

            // Arrange
            var LRequest = "/api/v1/artists/bands/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnBands = JsonConvert.DeserializeObject<ReturnBands>(LStringResponse);

            LReturnBands.Bands.Select(R => R.Name).ToList()[0].Should().Be("Queen");

        }

        [Theory]
        [InlineData(1)]
        public async Task GetMembers(int Id)
        {

            // Arrange
            var LRequest = $"/api/v1/artists/bands/{Id}/members/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnMembers = JsonConvert.DeserializeObject<ReturnMembers>(LStringResponse);

            LReturnMembers.Members.Should().HaveCount(4);

        }

        [Theory]
        [InlineData(1)]
        public async Task GetBandDetails(int Id) 
        {

            // Arrange
            var LRequest = $"/api/v1/artists/bands/{Id}/details/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnBandDetails = JsonConvert.DeserializeObject<ReturnBandDetails>(LStringResponse);

            LReturnBandDetails.Genere.Should().Be("Rock");
            LReturnBandDetails.Name.Should().Be("Queen");
            LReturnBandDetails.Members.Should().HaveCount(4);

        }

        [Fact]
        public async Task GetAlbums() 
        {

            // Arrange
            var LRequest = $"/api/v1/music/albums/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnAlbums = JsonConvert.DeserializeObject<ReturnAlbums>(LStringResponse);

            LReturnAlbums.Albums.Select(R => R.AlbumName).ToList()[3].Should().Be("A Night at the Opera");
            LReturnAlbums.Albums.Select(R => R.AlbumName).ToList()[5].Should().Be("News of the World");
            LReturnAlbums.Albums.Select(R => R.AlbumName).ToList()[13].Should().Be("Innuendo");
            LReturnAlbums.Albums.Should().HaveCount(15);

        }

    }

}
