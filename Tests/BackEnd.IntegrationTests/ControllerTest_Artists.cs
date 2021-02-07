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

            // Assert
            LResponse.EnsureSuccessStatusCode();
            LResponse.Should().NotBeNull();

            var LContent = await LResponse.Content.ReadAsStringAsync();
            LContent.Should().NotBeNullOrEmpty();

            var LDeserialized = JsonConvert.DeserializeObject<ReturnArtistsDto>(LContent);
            LDeserialized.Artists.Select(AArtist => AArtist.Name).ToList()[0].Should().Be("Queen");
        }

        [Theory]
        [InlineData(1)]
        public async Task Should_GetMembers(int AId)
        {
            // Arrange
            var LRequest = $"/api/v1/artists/{AId}/members/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Assert
            LResponse.EnsureSuccessStatusCode();
            LResponse.Should().NotBeNull();

            var LContent = await LResponse.Content.ReadAsStringAsync();
            LContent.Should().NotBeNullOrEmpty();

            var LDeserialized = JsonConvert.DeserializeObject<ReturnMembersDto>(LContent);
            LDeserialized.Members.Should().HaveCount(4);
        }

        [Theory]
        [InlineData(1)]
        public async Task Should_GetArtistDetails(int AId)
        {
            // Arrange
            var LRequest = $"/api/v1/artists/{AId}/details/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Assert
            LResponse.EnsureSuccessStatusCode();
            LResponse.Should().NotBeNull();

            var LContent = await LResponse.Content.ReadAsStringAsync();
            LContent.Should().NotBeNullOrEmpty();

            var LDeserialized = JsonConvert.DeserializeObject<ReturnArtistDetailsDto>(LContent);
            LDeserialized.Genere.Should().Be("Rock");
            LDeserialized.Name.Should().Be("Queen");
            LDeserialized.Members.Should().HaveCount(4);
        }
    }
}
