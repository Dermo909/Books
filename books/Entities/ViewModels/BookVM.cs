using books.Entities.Models;

namespace books.Entities.ViewModels
{
    public class BookVM
    {
        public BookVM() { }
        public BookVM(Book book) 
        { 
            Id = book.Id; 
            Title = book.Title;
            ISBN = book.ISBN;
            AuthorId = book.AuthorId;
            ReadingStatus = book.ReadingStatus;
            IsActive = book.IsActive;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int AuthorId { get; set; }
        public int ReadingStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
