using books.Entities.Models;
using books.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(new Book(){ Id = 123 });
        }
        [HttpGet("GetbyId")]
        public IActionResult Get(int id)
        {
            return Ok(new Book() { Id = id });
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] BookVM book)
        {
            return Ok("Create");
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] BookVM book)
        {
            return Ok("Update");
        }
        [HttpPut("Delete")]
        public IActionResult Delete()
        {
            return Ok("Delete");
        }
    }
}