using Xunit;
using FluentAssertions;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SongLyrics.Controllers.Artists.Models;
using SongLyrics.IntegrationTests.Configuration;

namespace SongLyrics.IntegrationTests
{

    public class ControllerTest_Artists : IClassFixture<TestFixture<Startup>>
    {

        private readonly HttpClient FClient;

        public ControllerTest_Artists(TestFixture<Startup> ACustomFixture)
        {
            FClient = ACustomFixture.FClient;
        }

        [Fact]
        public async Task Should_GetArtists()
        {

            // Arrange
            var LRequest = "/api/v1/artists/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnBands = JsonConvert.DeserializeObject<ReturnArtistsDto>(LStringResponse);

            LReturnBands.Artists.Select(AArtist => AArtist.Name).ToList()[0].Should().Be("Queen");

        }

        [Theory]
        [InlineData(1)]
        public async Task Should_GetMembers(int AId)
        {

            // Arrange
            var LRequest = $"/api/v1/artists/{AId}/members/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnMembers = JsonConvert.DeserializeObject<ReturnMembersDto>(LStringResponse);

            LReturnMembers.Members.Should().HaveCount(4);

        }

        [Theory]
        [InlineData(1)]
        public async Task Should_GetArtistDetails(int AId)
        {

            // Arrange
            var LRequest = $"/api/v1/artists/{AId}/details/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnBandDetails = JsonConvert.DeserializeObject<ReturnArtistDetailsDto>(LStringResponse);

            LReturnBandDetails.Genere.Should().Be("Rock");
            LReturnBandDetails.Name.Should().Be("Queen");
            LReturnBandDetails.Members.Should().HaveCount(4);

        }

    }

}
