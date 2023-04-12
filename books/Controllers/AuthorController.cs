using books.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    /// <summary>
    /// Controller to allow access to AuthorService methods
    /// </summary>
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
        /// <summary>
        /// Get all Authors
        /// </summary>
        /// <returns>List of Authors</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_authorService.GetAll());
        }
    }
}
