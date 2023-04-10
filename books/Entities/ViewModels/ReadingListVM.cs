using books.Entities.Models;

namespace books.Entities.ViewModels
{
    public class ReadingListVM
    {
        public ReadingListVM(ReadingList listItem) 
        { 
            Id = listItem.Id;
            BookId = listItem.BookId;
            Title = listItem.Book.Title;
            ReadingStatus = listItem.ReadingStatus;
            IsActive = listItem.IsActive;
        }
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public int ReadingStatus { get; set; }
        public bool IsActive { get; set; }

    }
}
