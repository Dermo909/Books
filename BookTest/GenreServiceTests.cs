using books.Controllers;
using books.Data;
using books.Entities.Models;
using books.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookTest
{
    [TestClass]
    public class GenreServiceTests
    {
        private IGenreService _genreService;
        private ILogger<BookController> _logger;
        private GenreController _genreController;
        private BookContext context;

        [TestInitialize]
        public void Setup()
        {
            var _contextOptions = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase("GenreServiceTest")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            context = new BookContext(_contextOptions);
            _genreService = new GenreService(context);
            _genreController = new GenreController(_logger, _genreService);


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(
                new Genre { Id = 1, GenreName = "Fantasy", IsActive = true },
                new Genre { Id = 2, GenreName = "Science Fiction", IsActive = true },
                new Genre { Id = 3, GenreName = "Horror", IsActive = true });

            context.SaveChanges();
        }

        [TestMethod]
        public void TestSetup()
        {
            Assert.IsNotNull(_genreService);
            Assert.IsNotNull(_genreController);
        }

        [TestMethod]
        public void Read()
        {
            var genres = _genreService.GetAll();
            Assert.IsNotNull(genres);

            var genre1 = genres.FirstOrDefault(x => x.Id == 1);
            var genre2 = genres.FirstOrDefault(x => x.Id == 2);
            var genre3 = genres.FirstOrDefault(x => x.Id == 3);
            
            Assert.AreEqual(genres.Count, 3);
            Assert.IsNotNull(genre1);
            Assert.IsNotNull(genre2);
            // genre1 Asserts
            Assert.AreEqual(genre1.Id, 1);
            Assert.AreEqual(genre1.GenreName, "Fantasy");
            Assert.IsTrue(genre1.IsActive);
            // genre2 Asserts
            Assert.AreEqual(genre2.Id, 2);
            Assert.AreEqual(genre2.GenreName, "Science Fiction");
            Assert.IsTrue(genre2.IsActive);
            // genre3 Asserts
            Assert.AreEqual(genre3.Id, 3);
            Assert.AreEqual(genre3.GenreName, "Horror");
            Assert.IsTrue(genre3.IsActive);
        }
    }
}
