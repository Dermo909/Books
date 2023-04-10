using books.Data;
using books.Entities.Models;
using books.Entities.ViewModels;

namespace books.Services
{
    public interface IAuthorService
    {
        List<AuthorVM> GetAll();
    }
    public class AuthorService : IAuthorService
    {
        private readonly BookContext _bookContext;

        public AuthorService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public List<AuthorVM> GetAll()
        {
            var authors = _bookContext.Authors.Select(x => new AuthorVM(x)).ToList();
            return authors;
        }
    }
}
