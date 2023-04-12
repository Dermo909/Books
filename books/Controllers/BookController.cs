using books.Entities.Models;
using books.Entities.ViewModels;
using books.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    /// <summary>
    /// Controller to allow access to BookService methods
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_allowAllOrigins")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Get all Books
        /// </summary>
        /// <returns>List of BookVM</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAll());
        }

        /// <summary>
        /// Get book by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>BookVM</returns>
        [HttpGet("GetbyId")]
        public IActionResult GetbyId(int id)
        {
            return Ok(_bookService.GetbyId(id));
        }

        /// <summary>
        /// Create a new Book object in database
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Id of newly created book</returns>
        [HttpPost("Create")]
        public IActionResult Create([FromBody] BookVM book)
        {
            return Ok(_bookService.Create(book));
        }

        /// <summary>
        /// Update Book object in database
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Id of updated book</returns>
        [HttpPut("Update")]
        public IActionResult Update([FromBody] BookVM book)
        {
            return Ok(_bookService.Update(book));
        }

        /// <summary>
        /// Mark a book as IsActive=false
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of updated book</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_bookService.Delete(id));
        }
    }
}