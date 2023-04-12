using books.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    /// <summary>
    /// Controller to allow access to GenreService methods
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_allowAllOrigins")]
    public class GenreController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IGenreService _genreService;
        public GenreController(ILogger<BookController> logger, IGenreService genreService)
        {
            _logger = logger;
            _genreService = genreService;
        }

        /// <summary>
        /// Get all Genres
        /// </summary>
        /// <returns>List of GenreVM</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_genreService.GetAll());
        }
    }
}
