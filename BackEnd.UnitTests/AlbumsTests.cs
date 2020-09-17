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

        private readonly Mock<MainDbContext> FMockDbContext;

        private readonly IAlbums FAlbums;

        public AlbumsTests() 
        {

            // Create instances to mocked all dependencies           
            FMockDbContext = new Mock<MainDbContext>();

            // Upload pre-fixed dummy data
            var BandsDbSet        = DummyData.ReturnDummyArtists().AsQueryable().BuildMockDbSet();
            var AlbumsDbSet       = DummyData.ReturnDummyAlbums().AsQueryable().BuildMockDbSet();
            var GeneresDbSet      = DummyData.ReturnDummyGeneres().AsQueryable().BuildMockDbSet();
            var BandsGeneresDbSet = DummyData.ReturnDummyBandsGeneres().AsQueryable().BuildMockDbSet();
            var MembersDbSet      = DummyData.ReturnDummyMembers().AsQueryable().BuildMockDbSet();
            var SongsDbSet        = DummyData.ReturnDummySongs().AsQueryable().BuildMockDbSet();

            // Populate database tables with dummy data
            FMockDbContext.Setup(R => R.Artists).Returns(BandsDbSet.Object);
            FMockDbContext.Setup(R => R.Albums).Returns(AlbumsDbSet.Object);
            FMockDbContext.Setup(R => R.Generes).Returns(GeneresDbSet.Object);
            FMockDbContext.Setup(R => R.ArtistsGeneres).Returns(BandsGeneresDbSet.Object);
            FMockDbContext.Setup(R => R.Members).Returns(MembersDbSet.Object);
            FMockDbContext.Setup(R => R.Songs).Returns(SongsDbSet.Object);

            // Create test instance with mocked depenencies
            FAlbums = new Albums(FMockDbContext.Object);

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

            LResult1.Select(R => R.AlbumName).First().Should().Be("Queen");
            LResult2.Select(R => R.AlbumName).First().Should().Be("Queen II");
            LResult3.Should().BeEmpty();

        }

    }

}
