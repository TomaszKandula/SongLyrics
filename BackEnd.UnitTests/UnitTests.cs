using Moq;
using Xunit;
using System.Linq;
using FluentAssertions;
using MockQueryable.Moq;
using BackEnd.Logic.Music;
using BackEnd.Logic.Bands;
using BackEnd.UnitTests.Mocks;

namespace SongLyricsBackEnd.UnitTests
{

    public class UnitTests
    {

        private readonly Mock<MainDbContext> FMockDbContext;

        private readonly IBands FBands;
        private readonly IMusic FMusic;

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
            FBands = new Bands(FMockDbContext.Object);
            FMusic = new Music(FMockDbContext.Object);

        }

        [Fact]
        public async void GetBands()
        {

            var LResult1 = await FBands.GetBands(null);
            var LResult2 = await FBands.GetBands(1);
            var LResult3 = await FBands.GetBands(100);

            LResult1.Should().NotBeEmpty();
            LResult2.Should().NotBeEmpty();
            LResult3.Should().BeEmpty();

        }

        [Fact]
        public async void GetMembers() 
        {

            var LResult1 = await FBands.GetMembers(2);
            var LResult2 = await FBands.GetMembers(45);

            LResult1.Should().NotBeEmpty();
            LResult2.Should().BeEmpty();
        
        }

        [Fact]
        public async void GetBandDetails() 
        {

            var LResult = await FBands.GetBandDetails(1);

            LResult.Name.Should().Be("Queen");
            LResult.Genere.Should().Be("Rock");
            LResult.Members.Should().HaveCount(4);

        }

        [Fact]
        public async void GetAlbums() 
        {

            var LResult1 = await FMusic.GetAlbums(null);
            var LResult2 = await FMusic.GetAlbums(1);
            var LResult3 = await FMusic.GetAlbums(45);

            LResult1.Should().HaveCount(4);
            LResult2.Should().HaveCount(2);
            LResult3.Should().BeEmpty();

        }

        [Fact]
        public async void GetAlbum() 
        {

            var LResult1 = await FMusic.GetAlbum(1);
            var LResult2 = await FMusic.GetAlbum(2);
            var LResult3 = await FMusic.GetAlbum(99);

            LResult1.Select(R => R.AlbumName).First().Should().Be("Queen");
            LResult2.Select(R => R.AlbumName).First().Should().Be("Queen II");
            LResult3.Should().BeEmpty();

        }

        [Fact]
        public async void GetAlbumSongs()
        {

            var LResult1 = await FMusic.GetAlbumSongs(1);
            var LResult2 = await FMusic.GetAlbumSongs(100);

            LResult1.Select(R => R.Name).ToList()[0].Should().Be("Keep Yourself Alive");
            LResult1.Select(R => R.Name).ToList()[1].Should().Be("Liar");
            LResult2.Should().BeEmpty();

        }

        [Fact]
        public async void GetSong() 
        {

            var LResult2 = await FMusic.GetSong(7);
            var LResult3 = await FMusic.GetSong(100);

            LResult2.Select(R => R.Name).First().Should().Be("Whole Lotta Love");
            LResult3.Should().BeEmpty();

        }

    }

}
