﻿using Xunit;
using FluentAssertions;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BackEnd.Controllers.Artists.Models;
using BackEnd.IntegrationTests.Configuration;

namespace BackEnd.IntegrationTests
{

    public class ArtistsControllerTest : IClassFixture<TestFixture<Startup>>
    {

        private readonly HttpClient FClient;

        public ArtistsControllerTest(TestFixture<Startup> ACustomFixture)
        {
            FClient = ACustomFixture.FClient;
        }

        [Fact]
        public async Task GetArtists()
        {

            // Arrange
            var LRequest = "/api/v1/artists/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnBands = JsonConvert.DeserializeObject<ReturnArtists>(LStringResponse);

            LReturnBands.Artists.Select(AArtist => AArtist.Name).ToList()[0].Should().Be("Queen");

        }

        [Theory]
        [InlineData(1)]
        public async Task GetMembers(int AId)
        {

            // Arrange
            var LRequest = $"/api/v1/artists/{AId}/members/";

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
        public async Task GetArtistDetails(int AId)
        {

            // Arrange
            var LRequest = $"/api/v1/artists/{AId}/details/";

            // Act
            var LResponse = await FClient.GetAsync(LRequest);

            // Require success status code
            LResponse.EnsureSuccessStatusCode();

            // Deserialize response and check results            
            var LStringResponse = await LResponse.Content.ReadAsStringAsync();
            var LReturnBandDetails = JsonConvert.DeserializeObject<ReturnArtistDetails>(LStringResponse);

            LReturnBandDetails.Genere.Should().Be("Rock");
            LReturnBandDetails.Name.Should().Be("Queen");
            LReturnBandDetails.Members.Should().HaveCount(4);

        }

    }

}
