namespace books.Entities.Models
{
    public class ReadingList
    {
        public int Id { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
