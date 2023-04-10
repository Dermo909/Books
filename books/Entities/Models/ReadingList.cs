using System.ComponentModel.DataAnnotations.Schema;

namespace books.Entities.Models
{
    public class ReadingList
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReadingStatus { get; set; }
        public bool IsActive { get; set; }
    }
}
