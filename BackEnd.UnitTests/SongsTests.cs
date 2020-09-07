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

        private readonly Mock<MainDbContext> FMockDbContext;

        private readonly ISongs FSongs;

        public SongsTests() 
        {

            // Create instances to mocked all dependencies           
            FMockDbContext = new Mock<MainDbContext>();

            // Upload pre-fixed dummy data
            var BandsDbSet        = DummyData.ReturnDummyBands().AsQueryable().BuildMockDbSet();
            var AlbumsDbSet       = DummyData.ReturnDummyAlbums().AsQueryable().BuildMockDbSet();
            var GeneresDbSet      = DummyData.ReturnDummyGeneres().AsQueryable().BuildMockDbSet();
            var BandsGeneresDbSet = DummyData.ReturnDummyBandsGeneres().AsQueryable().BuildMockDbSet();
            var MembersDbSet      = DummyData.ReturnDummyMembers().AsQueryable().BuildMockDbSet();
            var SongsDbSet        = DummyData.ReturnDummySongs().AsQueryable().BuildMockDbSet();

            // Populate database tables with dummy data
            FMockDbContext.Setup(R => R.Bands).Returns(BandsDbSet.Object);
            FMockDbContext.Setup(R => R.Albums).Returns(AlbumsDbSet.Object);
            FMockDbContext.Setup(R => R.Generes).Returns(GeneresDbSet.Object);
            FMockDbContext.Setup(R => R.BandsGeneres).Returns(BandsGeneresDbSet.Object);
            FMockDbContext.Setup(R => R.Members).Returns(MembersDbSet.Object);
            FMockDbContext.Setup(R => R.Songs).Returns(SongsDbSet.Object);

            // Create test instance with mocked depenencies
            FSongs = new Songs(FMockDbContext.Object);

        }

        [Fact]
        public async void GetAlbumSongs()
        {

            var LResult1 = await FSongs.GetAlbumSongs(1);
            var LResult2 = await FSongs.GetAlbumSongs(100);

            LResult1.Select(R => R.Name).ToList()[0].Should().Be("Keep Yourself Alive");
            LResult1.Select(R => R.Name).ToList()[1].Should().Be("Liar");
            LResult2.Should().BeEmpty();

        }

        [Fact]
        public async void GetSong()
        {

            var LResult2 = await FSongs.GetSong(7);
            var LResult3 = await FSongs.GetSong(100);

            LResult2.Select(R => R.Name).First().Should().Be("Whole Lotta Love");
            LResult3.Should().BeEmpty();

        }

    }

}
