using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
using MockQueryable.Moq;
using BackEnd.Logic.Albums;
using BackEnd.UnitTests.Mocks;

namespace BackEnd.UnitTests
{

    public class AlbumsTests
    {
        private readonly IAlbums FAlbums;

        public AlbumsTests() 
        {

            // Create instances to mocked all dependencies           
            var LMockDbContext = new Mock<MainDbContext>();

            // Upload pre-fixed dummy data
            var LBandsDbSet        = DummyData.ReturnDummyArtists().AsQueryable().BuildMockDbSet();
            var LAlbumsDbSet       = DummyData.ReturnDummyAlbums().AsQueryable().BuildMockDbSet();
            var LGeneresDbSet      = DummyData.ReturnDummyGeneres().AsQueryable().BuildMockDbSet();
            var LBandsGeneresDbSet = DummyData.ReturnDummyBandsGeneres().AsQueryable().BuildMockDbSet();
            var LMembersDbSet      = DummyData.ReturnDummyMembers().AsQueryable().BuildMockDbSet();
            var LSongsDbSet        = DummyData.ReturnDummySongs().AsQueryable().BuildMockDbSet();

            // Populate database tables with dummy data
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Artists).Returns(LBandsDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Albums).Returns(LAlbumsDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Generes).Returns(LGeneresDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.ArtistsGeneres).Returns(LBandsGeneresDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Members).Returns(LMembersDbSet.Object);
            LMockDbContext.Setup(AMainDbContext => AMainDbContext.Songs).Returns(LSongsDbSet.Object);

            // Create test instance with mocked dependencies
            FAlbums = new Albums(LMockDbContext.Object);

        }

        [Fact]
        public async void GetAlbums()
        {

            var LResult1 = await FAlbums.GetAlbums(null);
            var LResult2 = await FAlbums.GetAlbums(1);
            var LResult3 = await FAlbums.GetAlbums(45);

            LResult1.Should().HaveCount(4);
            LResult2.Should().HaveCount(2);
            LResult3.Should().BeEmpty();

        }

        [Fact]
        public async void GetAlbum()
        {

            var LResult1 = await FAlbums.GetAlbum(1);
            var LResult2 = await FAlbums.GetAlbum(2);
            var LResult3 = await FAlbums.GetAlbum(99);

            LResult1.Select(AAlbum => AAlbum.AlbumName).First().Should().Be("Queen");
            LResult2.Select(AAlbum => AAlbum.AlbumName).First().Should().Be("Queen II");
            LResult3.Should().BeEmpty();

        }

    }

}
