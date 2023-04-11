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
    public class AuthorServiceTests
    {
        private IAuthorService _authorService;
        private ILogger<BookController> _logger;
        private AuthorController _authorController;
        private BookContext context;

        [TestInitialize]
        public void Setup()
        {
            var _contextOptions = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase("GenreServiceTest")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            context = new BookContext(_contextOptions);
            _authorService = new AuthorService(context);
            _authorController = new AuthorController(_logger, _authorService);


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(
                new Author { Id = 1, FirstName = "Stephen", MiddleName = null, SecondName = "King", IsActive = true },
                new Author { Id = 2, FirstName = "James", MiddleName = "RR", SecondName = "Tolkien", IsActive = true }
            );

            context.SaveChanges();
        }

        [TestMethod]
        public void TestSetup()
        {
            Assert.IsNotNull(_authorService);
            Assert.IsNotNull(_authorController);
        }

        [TestMethod]
        public void Read()
        {
            var authors = _authorService.GetAll();
            Assert.IsNotNull(authors);

            Assert.AreEqual(authors.Count, 2);

            var author1 = authors.FirstOrDefault(x => x.Id == 1);
            var author2 = authors.FirstOrDefault(x => x.Id == 2);

            Assert.IsNotNull(author1);
            Assert.IsNotNull(author2);
            // author1 Asserts
            Assert.AreEqual(author1.Id, 1);
            Assert.AreEqual(author1.FirstName, "Stephen");
            Assert.IsNull(author1.MiddleName);
            Assert.AreEqual(author1.SecondName, "King");
            Assert.IsTrue(author1.IsActive);
            // author2 Asserts
            Assert.AreEqual(author2.Id, 2);
            Assert.AreEqual(author2.FirstName, "James");
            Assert.AreEqual(author2.MiddleName, "RR");
            Assert.AreEqual(author2.SecondName, "Tolkien");
            Assert.IsTrue(author2.IsActive);
        }
    }
}
