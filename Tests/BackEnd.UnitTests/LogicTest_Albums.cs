using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
using MockQueryable.Moq;
using SongLyrics.Logic.Albums;
using SongLyrics.UnitTests.Database;

namespace SongLyrics.UnitTests
{

    public class LogicTest_Albums
    {
        private readonly IAlbums FAlbums;

        public LogicTest_Albums() 
        {

            // Create instances to mocked all dependencies           
            var LMockDbContext = new Mock<SongLyrics.Database.MainDbContext>();

            // Upload pre-fixed dummy data
            var LBandsDbSet        = DummyLoad.ReturnDummyArtists().AsQueryable().BuildMockDbSet();
            var LAlbumsDbSet       = DummyLoad.ReturnDummyAlbums().AsQueryable().BuildMockDbSet();
            var LGeneresDbSet      = DummyLoad.ReturnDummyGeneres().AsQueryable().BuildMockDbSet();
            var LBandsGeneresDbSet = DummyLoad.ReturnDummyBandsGeneres().AsQueryable().BuildMockDbSet();
            var LMembersDbSet      = DummyLoad.ReturnDummyMembers().AsQueryable().BuildMockDbSet();
            var LSongsDbSet        = DummyLoad.ReturnDummySongs().AsQueryable().BuildMockDbSet();

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
        public async void Should_GetAlbums()
        {

            var LResult1 = await FAlbums.GetAlbums(null);
            var LResult2 = await FAlbums.GetAlbums(1);
            var LResult3 = await FAlbums.GetAlbums(45);

            LResult1.Should().HaveCount(4);
            LResult2.Should().HaveCount(2);
            LResult3.Should().BeEmpty();

        }

        [Fact]
        public async void Should_GetAlbum()
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
