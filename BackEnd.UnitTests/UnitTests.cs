using Moq;
using Xunit;
using System.Linq;
using MockQueryable.Moq;
using BackEnd.Logic.Music;
using BackEnd.Logic.Artists;
using BackEnd.UnitTests.Mocks;

namespace SongLyricsBackEnd.UnitTests
{

    public class Startup
    {
    }

    public class UnitTests
    {

        private readonly Mock<MainDbContext> FMockDbContext;

        private readonly IArtists FArtists;
        private readonly IMusic   FMusic;

        public UnitTests() 
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
            FArtists = new Artists(FMockDbContext.Object);
            FMusic = new Music(FMockDbContext.Object);

        }

        [Fact]
        public void Test1()
        {

        }

    }

}
