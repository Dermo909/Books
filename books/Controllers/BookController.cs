using books.Entities.Models;
using books.Entities.ViewModels;
using books.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
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

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAll());
        }
        [HttpGet("GetbyId")]
        public IActionResult GetbyId(int id)
        {
            return Ok(_bookService.GetbyId(id));
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] BookVM book)
        {
            return Ok(_bookService.Create(book));
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] BookVM book)
        {
            return Ok(_bookService.Update(book));
        }
        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_bookService.Delete(id));
        }
    }
}