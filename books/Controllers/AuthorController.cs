using books.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_allowAllOrigins")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IAuthorService _authorService;
        public AuthorController(ILogger<BookController> logger, IAuthorService authorService)
        {
            _logger = logger;
            _authorService = authorService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_authorService.GetAll());
        }
    }
}
