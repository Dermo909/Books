using books.Entities.Models;

namespace books.Entities.ViewModels
{
    public class GenreVM
    {
        public GenreVM(Genre genre)
        {
            Id = genre.Id;
            GenreName = genre.GenreName;
            IsActive = genre.IsActive;   
        }

        public int Id { get; set; }
        public string GenreName { get; set; }
        public bool IsActive { get; set; }
    }
}
