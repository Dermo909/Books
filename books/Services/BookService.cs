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
        public List<BookVM> GetAll()
        {
            return new List<BookVM>();
        }
        public BookVM GetbyId(int id)
        {
            return new BookVM() { Id = id };
        }
        public int Create(BookVM book)
        {
            return book.Id;
        }
        public int Update(BookVM book)
        {
            return book.Id;
        }
        public int Delete(int id)
        {
            return id;
        }
    }
}
