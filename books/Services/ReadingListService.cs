using books.Data;
using books.Entities.Models;
using books.Entities.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace books.Services
{
    public interface IReadingListService
    {
        List<ReadingListVM> GetAll();
        ReadingListVM GetbyId(int id);
        int Create(ReadingListVM book);
        int Update(ReadingListVM book);
        int Delete(int id);
    }
    public class ReadingListService : IReadingListService
    {
        private readonly BookContext _bookContext;

        public ReadingListService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public List<ReadingListVM> GetAll()
        {
            var books = _bookContext.ReadingLists
                            .Include(x => x.Book)
                            .Select(x => new ReadingListVM(x)).ToList();
            return books;
        }
        public ReadingListVM GetbyId(int id)
        {
            var readingListDB = _bookContext.ReadingLists.FirstOrDefault(x => x.Id == id);

            if (readingListDB == null)
            {
                throw new Exception($"Reading list item with id {id} not found");
            }

            return new ReadingListVM(readingListDB);
        }
        public int Create(ReadingListVM book)
        {
            var newReadingList = new ReadingList()
            {
                BookId = book.BookId,
                ReadingStatus = book.ReadingStatus,
                IsActive = true
            };
            _bookContext.ReadingLists.Add(newReadingList);

            _bookContext.SaveChanges();

            return newReadingList.Id;
        }
        public int Update(ReadingListVM book)
        {
            var readingListDB = _bookContext.ReadingLists.FirstOrDefault(x => x.Id == book.Id);

            if (readingListDB == null)
            {
                throw new Exception($"Reading list item with id {book.Id} not found");
            }

            readingListDB.ReadingStatus = book.ReadingStatus;
            readingListDB.IsActive= book.IsActive;

            _bookContext.SaveChanges();

            return readingListDB.Id;
        }
        public int Delete(int id)
        {
            var readingListDB = _bookContext.ReadingLists.FirstOrDefault(x => x.Id == id);

            if (readingListDB == null)
            {
                throw new Exception($"Reading list item with id {id} not found");
            }

            readingListDB.IsActive = false;

            _bookContext.SaveChanges();

            return readingListDB.Id;
        }
    }
}
