namespace books.Entities.Models
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string SecondName { get; set; }
        public ICollection<Book> Books { get; set; }
        public bool IsActive { get; set; }
    }
}
