using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
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
        public async void GetBands()
        {

            var LResult1 = await FArtists.GetBands(null);
            var LResult2 = await FArtists.GetBands(1);
            var LResult3 = await FArtists.GetBands(100);

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
        public async void GetBandDetails() 
        {

            var LResult = await FArtists.GetBandDetails(1);

            LResult.Name.Should().Be("Queen");
            LResult.Genere.Should().Be("Rock");
            LResult.Members.Should().HaveCount(4);

        }

    }

}
