using books.Controllers;
using books.Data;
using books.Entities.Models;
using books.Entities.ViewModels;
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
    public class ReadingListServiceTests
    {
        private IBookService _bookService;
        private IReadingListService _readingListService;
        private IAuthorService _authorService;
        private IGenreService _genreService;
        private ILogger<ReadingListController> _logger;
        private ReadingListController _readingListController;
        private BookContext context;

        [TestInitialize]
        public void Setup()
        {
            var _contextOptions = new DbContextOptionsBuilder<BookContext>()
            .UseInMemoryDatabase("BookServiceTest")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            context = new BookContext(_contextOptions);
            _bookService = new BookService(context);
            _readingListService = new ReadingListService(context);
            _authorService = new AuthorService(context);
            _genreService = new GenreService(context);
            _readingListController = new ReadingListController(_logger, _readingListService);


            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.AddRange(
                new Genre { Id = 1, GenreName = "Fantasy", IsActive = true },
                new Genre { Id = 2, GenreName = "Science Fiction", IsActive = true },
                new Genre { Id = 3, GenreName = "Horror", IsActive = true });

            context.AddRange(
                new Author { Id = 1, FirstName = "Stephen", MiddleName = null, SecondName = "King", IsActive = true },
                new Author { Id = 2, FirstName = "James", MiddleName = "RR", SecondName = "Tolkien", IsActive = true }
            );

            context.AddRange(
                new Book { Id = 1, AuthorId = 1, GenreId = 3, Title = "IT", ISBN = "12345", IsActive = true },
                new Book { Id = 2, AuthorId = 2, GenreId = 1, Title = "Lord of the Rings", ISBN = "67890", IsActive = true },
                new Book { Id = 3, AuthorId = 1, GenreId = 1, Title = "Misery", ISBN = "135813", IsActive = true }
                );

            context.AddRange(
                new ReadingList { Id = 1, BookId = 1, IsActive = true, ReadingStatus = 50 },
                new ReadingList { Id = 2, BookId = 2, IsActive = true, ReadingStatus = 100 }
                );

            context.SaveChanges();
        }

        [TestMethod]
        public void TestSetup()
        {
            Assert.IsNotNull(_bookService);
            Assert.IsNotNull(_authorService);
            Assert.IsNotNull(_genreService);
            Assert.IsNotNull(_readingListService);
            Assert.IsNotNull(_readingListController);
        }

        [TestMethod]
        public void Create()
        {
            var bookVM = _bookService.GetbyId(3);
            var book = new Book() { 
                Id = bookVM.Id, 
                AuthorId = bookVM.AuthorId, 
                GenreId = bookVM.GenreId, 
                Title = bookVM.Title, 
                ISBN = bookVM.ISBN, 
                IsActive = bookVM.IsActive};

            var newReadingListBook = new ReadingListVM(new ReadingList()
            { Id = 3, BookId = 3, Book = book, ReadingStatus = 75, IsActive = true });

            var result = _readingListService.Create(newReadingListBook);
            Assert.IsNotNull(result);

            var newReadingListentry = _readingListService.GetbyId(3);
            Assert.IsNotNull(newReadingListentry);

            Assert.AreEqual(newReadingListentry.Id, 3);
            Assert.AreEqual(newReadingListentry.BookId, 3);
            Assert.AreEqual(newReadingListentry.ReadingStatus, 75);
            Assert.IsTrue(newReadingListentry.IsActive);

        }

        [TestMethod]
        public void Read()
        {
            var readingLists = _readingListService.GetAll();
            Assert.IsNotNull(readingLists);   

            Assert.AreEqual(readingLists.Count, 2);

            var readingList1 = readingLists.FirstOrDefault(x => x.Id == 1);
            Assert.IsNotNull(readingList1);

            var readingList2 = readingLists.FirstOrDefault(x => x.Id == 2);
            Assert.IsNotNull(readingList2);

            Assert.AreEqual(readingList1.Id, 1);
            Assert.AreEqual(readingList1.BookId, 1);
            Assert.AreEqual(readingList1.ReadingStatus, 50);
            Assert.IsTrue(readingList1.IsActive);

            Assert.AreEqual(readingList2.Id, 2);
            Assert.AreEqual(readingList2.BookId, 2);
            Assert.AreEqual(readingList2.ReadingStatus, 100);
            Assert.IsTrue(readingList2.IsActive);
        }

        [TestMethod]
        public void Update()
        {
            var readingListEntry = _readingListService.GetbyId(1);
            Assert.IsNotNull(readingListEntry);

            Assert.AreEqual(readingListEntry.Id, 1);
            Assert.AreEqual(readingListEntry.BookId, 1);
            Assert.AreEqual(readingListEntry.ReadingStatus, 50);
            Assert.IsTrue(readingListEntry.IsActive);

            readingListEntry.BookId = 3;
            readingListEntry.ReadingStatus = 75;

            var result = _readingListService.Update(readingListEntry);

            var readingListEntryUpdated = _readingListService.GetbyId(1);
            Assert.IsNotNull(readingListEntryUpdated);

            Assert.AreEqual(readingListEntryUpdated.Id, 1);
            Assert.AreEqual(readingListEntryUpdated.BookId, 3);
            Assert.AreEqual(readingListEntryUpdated.ReadingStatus, 75);
            Assert.IsTrue(readingListEntryUpdated.IsActive);

        }
        [TestMethod]
        public void Delete()
        {
            var readingListEntry = _readingListService.GetbyId(1);
            Assert.IsNotNull(readingListEntry);

            readingListEntry.IsActive = false;
            var result = _readingListService.Update(readingListEntry);

            var readingListEntryUpdated = _readingListService.GetbyId(1);
            Assert.IsNotNull(readingListEntryUpdated);
            Assert.IsFalse(readingListEntryUpdated.IsActive);

        }
    }
}
