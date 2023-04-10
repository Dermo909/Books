using books.Entities.Models;

namespace books.Entities.ViewModels
{
    public class AuthorVM
    {
        public AuthorVM(Author author) 
        {
            Id = author.Id;
            FirstName = author.FirstName;
            SecondName = author.SecondName;
            MiddleName = author.MiddleName;
            FullName = !string.IsNullOrEmpty(author.MiddleName)
            ? $"{author.FirstName} {author.MiddleName} {author.SecondName}"
                : $"{author.FirstName} {author.SecondName}";
            IsActive = author.IsActive;
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string SecondName { get; set; }
        public string FullName { get; set; }
        public bool IsActive { get; set; }
    }
}
