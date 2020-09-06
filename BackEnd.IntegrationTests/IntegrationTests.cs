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
            var LRequest = "/api/v1/bands/";

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
            var LRequest = $"/api/v1/bands/{Id}/members/";

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
            var LRequest = $"/api/v1/bands/{Id}/details/";

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
            var LReturnSongs = JsonConvert.DeserializeObject<ReturnSongs>(LStringResponse);

            LReturnSongs.Songs.Select(R => R.Name).ToList().Single().Should().Be("The Night Comes Down");

        }

    }

}
