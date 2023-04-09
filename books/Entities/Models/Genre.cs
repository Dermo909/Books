using System.ComponentModel.DataAnnotations.Schema;

namespace books.Entities.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}
