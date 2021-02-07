using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
using MockQueryable.Moq;
using SongLyrics.Logic.Songs;
using SongLyrics.UnitTests.Database;

namespace SongLyrics.UnitTests
{

    public class LogicTest_Songs
    {
        private readonly ISongs FSongs;

        public LogicTest_Songs() 
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
            FSongs = new Songs(LMockDbContext.Object);

        }

        [Fact]
        public async void Should_GetAlbumSongs()
        {

            var LResult1 = await FSongs.GetAlbumSongs(1);
            var LResult2 = await FSongs.GetAlbumSongs(100);

            LResult1.Select(ASong => ASong.Name).ToList()[0].Should().Be("Keep Yourself Alive");
            LResult1.Select(ASong => ASong.Name).ToList()[1].Should().Be("Liar");
            LResult2.Should().BeEmpty();

        }

        [Fact]
        public async void Should_GetSong()
        {

            var LResult2 = await FSongs.GetSong(7);
            var LResult3 = await FSongs.GetSong(100);

            LResult2.Name.Should().Be("Whole Lotta Love");
            LResult3.Should().BeNull();

        }

    }

}
