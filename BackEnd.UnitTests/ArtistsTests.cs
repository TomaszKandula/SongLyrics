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
        private readonly IArtists FArtists;

        public ArtistsTests() 
        {

            // Create instances to mocked all dependencies           
            var LMockDbContext = new Mock<MainDbContext>();

            // Upload pre-fixed dummy data
            var LArtistsDbSet      = DummyData.ReturnDummyArtists().AsQueryable().BuildMockDbSet();
            var LAlbumsDbSet       = DummyData.ReturnDummyAlbums().AsQueryable().BuildMockDbSet();
            var LGeneresDbSet      = DummyData.ReturnDummyGeneres().AsQueryable().BuildMockDbSet();
            var LBandsGeneresDbSet = DummyData.ReturnDummyBandsGeneres().AsQueryable().BuildMockDbSet();
            var LMembersDbSet      = DummyData.ReturnDummyMembers().AsQueryable().BuildMockDbSet();
            var LSongsDbSet        = DummyData.ReturnDummySongs().AsQueryable().BuildMockDbSet();

            // Populate database tables with dummy data
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Artists).Returns(LArtistsDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Albums).Returns(LAlbumsDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Generes).Returns(LGeneresDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.ArtistsGeneres).Returns(LBandsGeneresDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Members).Returns(LMembersDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Songs).Returns(LSongsDbSet.Object);

            // Create test instance with mocked dependencies
            FArtists = new Artists(LMockDbContext.Object);

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

            var LResult1 = await FArtists.GetArtistDetails(1);
            var LResult2 = await FArtists.GetArtistDetails(100);

            LResult1.Name.Should().Be("Queen");
            LResult1.Genere.Should().Be("Rock");
            LResult1.Members.Should().HaveCount(4);
            LResult2.Name.Should().Be("n/a");

        }

    }

}
