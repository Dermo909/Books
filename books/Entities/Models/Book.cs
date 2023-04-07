namespace books.Entities.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int ReadingStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
