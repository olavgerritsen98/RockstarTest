using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestRockstars.Controllers;
using TestRockstars.Repositories;
using Moq;
using TestRockstars.Models;
using System.Data.Entity;
using TestRockstars.DAL;
using System.Collections.Generic;
using System.Linq;

namespace TestRockstars.Tests.Controllers
{
    [TestClass]
    public class SongRepositoryTest
    {
        Song testSong = new Song()
        {
            Id = 99999,
            Name = "TestSong",
            Album = "Testing",
            Year = 1998,
            Artist = "Rockstars",
            Shortname = "test",
            Duration = 1000,
            SpotifyId = "123456789",
            Genre = "Rockstar"
        };
        [TestMethod]
        public void AddSong()
        {
            var mockSet = new Mock<DbSet<Song>>();

            var mockContext = new Mock<DatabaseContext>();
            
            mockContext.Setup(m => m.Songs).Returns(mockSet.Object);

            var service = new SongsRepository(mockContext.Object);
            
            service.AddSong(testSong);

            mockSet.Verify(m => m.Add(testSong), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }

        [TestMethod]
        public void GetSongs()
        {
            var data = new List<Song>
            {
                testSong
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Song>>();
            mockSet.As<IQueryable<Song>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Song>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Song>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Song>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<DatabaseContext>();
            mockContext.Setup(c => c.Songs).Returns(mockSet.Object);

            var service = new SongsRepository(mockContext.Object);
            var blogs = service.GetSongs();

            Assert.AreEqual(1, blogs.Count());
        }

        [TestMethod]
        public void RemoveSong()
        {
            var mockSet = new Mock<DbSet<Song>>();

            var mockContext = new Mock<DatabaseContext>();
            
            mockContext.Setup(m => m.Songs).Returns(mockSet.Object);

            var service = new SongsRepository(mockContext.Object);

            service.AddSong(testSong);
            service.RemoveSong(testSong);

            mockSet.Verify(m => m.Add(testSong), Times.Once());

            mockSet.Verify(m => m.Remove(testSong), Times.Once());

            mockContext.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
