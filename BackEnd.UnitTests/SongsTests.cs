using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
using MockQueryable.Moq;
using BackEnd.Logic.Songs;
using BackEnd.UnitTests.Mocks;

namespace BackEnd.UnitTests
{

    public class SongsTests
    {
        private readonly ISongs FSongs;

        public SongsTests() 
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
            FSongs = new Songs(LMockDbContext.Object);

        }

        [Fact]
        public async void GetAlbumSongs()
        {

            var LResult1 = await FSongs.GetAlbumSongs(1);
            var LResult2 = await FSongs.GetAlbumSongs(100);

            LResult1.Select(ASong => ASong.Name).ToList()[0].Should().Be("Keep Yourself Alive");
            LResult1.Select(ASong => ASong.Name).ToList()[1].Should().Be("Liar");
            LResult2.Should().BeEmpty();

        }

        [Fact]
        public async void GetSong()
        {

            var LResult2 = await FSongs.GetSong(7);
            var LResult3 = await FSongs.GetSong(100);

            LResult2.Name.Should().Be("Whole Lotta Love");
            LResult3.Should().BeNull();

        }

    }

}
