using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
using MockQueryable.Moq;
using BackEnd.Logic.Artists;
using BackEnd.UnitTests.Mocks;

namespace BackEnd.UnitTests
{

    public class ArtistsTests
    {

        private readonly Mock<MainDbContext> FMockDbContext;

        private readonly IArtists FArtists;

        public ArtistsTests() 
        {

            // Create instances to mocked all dependencies           
            FMockDbContext = new Mock<MainDbContext>();

            // Upload pre-fixed dummy data
            var ArtistsDbSet      = DummyData.ReturnDummyArtists().AsQueryable().BuildMockDbSet();
            var AlbumsDbSet       = DummyData.ReturnDummyAlbums().AsQueryable().BuildMockDbSet();
            var GeneresDbSet      = DummyData.ReturnDummyGeneres().AsQueryable().BuildMockDbSet();
            var BandsGeneresDbSet = DummyData.ReturnDummyBandsGeneres().AsQueryable().BuildMockDbSet();
            var MembersDbSet      = DummyData.ReturnDummyMembers().AsQueryable().BuildMockDbSet();
            var SongsDbSet        = DummyData.ReturnDummySongs().AsQueryable().BuildMockDbSet();

            // Populate database tables with dummy data
            FMockDbContext.Setup(R => R.Bands).Returns(ArtistsDbSet.Object);
            FMockDbContext.Setup(R => R.Albums).Returns(AlbumsDbSet.Object);
            FMockDbContext.Setup(R => R.Generes).Returns(GeneresDbSet.Object);
            FMockDbContext.Setup(R => R.BandsGeneres).Returns(BandsGeneresDbSet.Object);
            FMockDbContext.Setup(R => R.Members).Returns(MembersDbSet.Object);
            FMockDbContext.Setup(R => R.Songs).Returns(SongsDbSet.Object);

            // Create test instance with mocked depenencies
            FArtists = new Artists(FMockDbContext.Object);

        }

        [Fact]
        public async void GetArtists()
        {

            var LResult1 = await FArtists.GetArtists(null);
            var LResult2 = await FArtists.GetArtists(1);
            var LResult3 = await FArtists.GetArtists(100);

            LResult1.Should().NotBeEmpty();
            LResult2.Should().NotBeEmpty();
            LResult3.Should().BeEmpty();

        }

        [Fact]
        public async void GetMembers()
        {

            var LResult1 = await FArtists.GetMembers(2);
            var LResult2 = await FArtists.GetMembers(45);

            LResult1.Should().NotBeEmpty();
            LResult2.Should().BeEmpty();

        }

        [Fact]
        public async void GetArtistDetails()
        {

            var LResult = await FArtists.GetBandDetails(1);

            LResult.Name.Should().Be("Queen");
            LResult.Genere.Should().Be("Rock");
            LResult.Members.Should().HaveCount(4);

        }

    }

}
