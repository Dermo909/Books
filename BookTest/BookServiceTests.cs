using books.Controllers;
using books.Data;
using books.Entities.Models;
using books.Entities.ViewModels;
using books.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace BookTest
{
    [TestClass]
    public class BookServiceTests
    {
        private IBookService _bookService;
        private IAuthorService _authorService;
        private IGenreService _genreService;
        private ILogger<BookController> _logger;
        private BookController _bookController;
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
            _authorService = new AuthorService(context);
            _genreService = new GenreService(context);
            _bookController = new BookController(_logger, _bookService);


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
                new Book { Id = 2, AuthorId = 2, GenreId = 1, Title = "Lord of the Rings", ISBN = "67890", IsActive = true }
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
            Assert.IsNotNull(_bookController);
        }

        [TestMethod]
        public void Create()
        {
            var authors = _authorService.GetAll();
            Assert.IsNotNull(authors);
            Assert.AreEqual(authors.Count, 2);

            var author = authors.Select(x =>
                            new Author() { Id = x.Id, FirstName = x.FirstName, MiddleName = x.MiddleName, SecondName = x.SecondName, IsActive = x.IsActive })
                            .FirstOrDefault(x => x.Id == 1);
            Assert.IsNotNull(author);

            var genres = _genreService.GetAll();
            Assert.IsNotNull(genres);
            Assert.AreEqual(genres.Count, 3);
            var genre = genres.Select(x =>
                new Genre() { Id = x.Id, GenreName = x.GenreName, IsActive = x.IsActive })
                .FirstOrDefault(x => x.Id == 1);
            Assert.IsNotNull(genre);

            var newBook = new BookVM(
                new Book()
                {
                    Id = 3,
                    AuthorId = author.Id,
                    Author = author,
                    GenreId = genre.Id,
                    Genre = genre,
                    Title = "New Book Title",
                    ISBN = "ABCD123",
                    IsActive = true
                }
                );

            _bookService.Create(newBook);

            var book = _bookService.GetbyId(3);
            Assert.IsNotNull(book);
            Assert.AreEqual(book.Id, 3);
            Assert.AreEqual(book.AuthorId, 1);
            Assert.AreEqual(book.GenreId, 1);
            Assert.AreEqual(book.Title, "New Book Title");
            Assert.AreEqual(book.ISBN, "ABCD123");
            Assert.IsTrue(book.IsActive);
        }
        [TestMethod]
        public void Read()
        {
            var books = _bookService.GetAll();

            var book1 = books.FirstOrDefault(x => x.Id == 1);
            var book2 = books.FirstOrDefault(x => x.Id == 2);
            // Id = 2, AuthorId = 2, GenreId = 1, Title = "Lord of the Rings", ISBN = "67890", IsActive = true
            Assert.AreEqual(books.Count, 2);
            Assert.IsNotNull(book1);
            Assert.IsNotNull(book2);
            // book1 Asserts
            Assert.AreEqual(book1.Id, 1);
            Assert.AreEqual(book1.AuthorId, 1);
            Assert.AreEqual(book1.GenreId, 3);
            Assert.AreEqual(book1.Title, "IT");
            Assert.AreEqual(book1.ISBN, "12345");
            // book2 Asserts
            Assert.AreEqual(book2.Id, 2);
            Assert.AreEqual(book2.AuthorId, 2);
            Assert.AreEqual(book2.GenreId, 1);
            Assert.AreEqual(book2.Title, "Lord of the Rings");
            Assert.AreEqual(book2.ISBN, "67890");
            Assert.IsTrue(book2.IsActive);
        }
        [TestMethod]
        public void Update()
        {
            var book = _bookService.GetbyId(1);
            Assert.IsNotNull(book);
            Assert.AreEqual(book.Id, 1);
            Assert.AreEqual(book.AuthorId, 1);
            Assert.AreEqual(book.GenreId, 3);
            Assert.AreEqual(book.Title, "IT");
            Assert.AreEqual(book.ISBN, "12345");

            book.AuthorId = 2;
            book.GenreId = 2;
            book.Title = "Tommyknockers";
            book.ISBN = "XYZ";

            var bookId = _bookService.Update(book);
            Assert.AreEqual(bookId, 1);

            var updatedBook = _bookService.GetbyId(1);
            Assert.IsNotNull(updatedBook);
            Assert.AreEqual(updatedBook.Id, 1);
            Assert.AreEqual(updatedBook.AuthorId, 2);
            Assert.AreEqual(updatedBook.GenreId, 3);
            Assert.AreEqual(updatedBook.Title, "Tommyknockers");
            Assert.AreEqual(updatedBook.ISBN, "XYZ");
        }
        [TestMethod]
        public void Delete()
        {
            var book = _bookService.GetbyId(1);
            Assert.IsTrue(book.IsActive);

            var bookId = _bookService.Delete(book.Id);
            Assert.AreEqual(bookId, 1);

            var updatedBook = _bookService.GetbyId(1);
            Assert.IsFalse(updatedBook.IsActive);
        }
    }
}