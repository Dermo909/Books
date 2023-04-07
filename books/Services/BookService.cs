using books.Data;
using books.Entities.Models;
using books.Entities.ViewModels;

namespace books.Services
{
    public interface IBookService
    {
        List<BookVM> GetAll();
        BookVM GetbyId(int id);
        int Create(BookVM book);
        int Update(BookVM book);
        int Delete(int id);
    }
    public class BookService : IBookService
    {
        private readonly BookContext _bookContext;

        public BookService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public List<BookVM> GetAll()
        {
            var books = _bookContext.Books.Select(x => new BookVM(x)).ToList(); 
            return books;
        }
        public BookVM GetbyId(int id)
        {
            var bookDB = _bookContext.Books.FirstOrDefault(x => x.Id == id);

            if(bookDB == null)
            {
                throw new Exception($"Book with id {id} not found");
            }

            return new BookVM(bookDB);
        }
        public int Create(BookVM book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                ISBN = book.ISBN,
                AuthorId = book.AuthorId,
                ReadingStatus = book.ReadingStatus,
                IsActive = true
            };
            _bookContext.Books.Add(newBook);

            _bookContext.SaveChanges(); 

            return book.Id;
        }
        public int Update(BookVM book)
        {
            var bookDB = _bookContext.Books.FirstOrDefault(x => x.Id == book.Id);

            if (bookDB == null)
            {
                throw new Exception($"Book with id {book.Id} not found");
            }

            bookDB.ISBN = book.ISBN;
            bookDB.Title = book.Title;
            bookDB.AuthorId = book.AuthorId;
            bookDB.ReadingStatus = book.ReadingStatus;

            _bookContext.SaveChanges();

            return book.Id;
        }
        public int Delete(int id)
        {
            var bookDB = _bookContext.Books.FirstOrDefault(x => x.Id == id);

            if (bookDB == null)
            {
                throw new Exception($"Book with id {id} not found");
            }

            bookDB.IsActive = false;

            _bookContext.SaveChanges();

            return id;
        }
    }
}
