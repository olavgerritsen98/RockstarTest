using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TestRockstars;
using TestRockstars.Controllers;
using TestRockstars.DAL;
using TestRockstars.Models;
using TestRockstars.Repositories;

namespace TestRockstars.Tests.Controllers
{
    [TestClass]
    public class ArtistControllerTests
    {
        Artist testArtist = new Artist()
        {
            Id = 99999,
            Name = "TestArtist",
        };

        [TestMethod]
        public void AddArtist()
        {
            var mockSet = new Mock<DbSet<Artist>>();

            var mockContext = new Mock<DatabaseContext>();

            mockContext.Setup(m => m.Artists).Returns(mockSet.Object);

            var service = new ArtistsRepository(mockContext.Object);

            service.AddArtist(testArtist);

            mockSet.Verify(m => m.Add(testArtist), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetArtists()
        {
            var data = new List<Artist>
            {
                testArtist
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Artist>>();
            mockSet.As<IQueryable<Artist>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Artist>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(c => c.Artists).Returns(mockSet.Object);

            var service = new ArtistsRepository(mockContext.Object);
            var artists = service.GetArtists();

            Assert.AreEqual(1, artists.Count());
        }

        [TestMethod]
        public void RemoveArtist()
        {
            var mockSet = new Mock<DbSet<Artist>>();

            var mockContext = new Mock<DatabaseContext>();

            mockContext.Setup(m => m.Artists).Returns(mockSet.Object);

            var service = new ArtistsRepository(mockContext.Object);

            service.AddArtist(testArtist);
            service.RemoveArtist(testArtist);

            mockSet.Verify(m => m.Add(testArtist), Times.Once());

            mockSet.Verify(m => m.Remove(testArtist), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
