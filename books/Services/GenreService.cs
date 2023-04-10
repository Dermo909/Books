using books.Data;
using books.Entities.ViewModels;

namespace books.Services
{
    public interface IGenreService
    {
        List<GenreVM> GetAll();
    }
    public class GenreService : IGenreService
    {
        private readonly BookContext _bookContext;

        public GenreService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public List<GenreVM> GetAll()
        {
            var genres = _bookContext.Genres.Select(x => new GenreVM(x)).ToList();
            return genres;
        }
    }
}
