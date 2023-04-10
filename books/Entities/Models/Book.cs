using System.ComponentModel.DataAnnotations.Schema;

namespace books.Entities.Models
{
    public class Book
    {
        public Book() 
        {
            ReadingLists = new HashSet<ReadingList>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ReadingList> ReadingLists { get; set; }
    }
}
