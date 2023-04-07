using books.Entities.Models;

namespace books.Entities.ViewModels
{
    public class BookVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int AuthorId { get; set; }
        public int ReadingStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
