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
    public class ReadingListController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IReadingListService _readingListService;
        public ReadingListController(ILogger<BookController> logger, IReadingListService readingListService)
        {
            _logger = logger;
            _readingListService = readingListService;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_readingListService.GetAll());
        }
        [HttpGet("GetbyId")]
        public IActionResult GetbyId(int id)
        {
            return Ok(_readingListService.GetbyId(id));
        }
        [HttpPost("Create")]
        public IActionResult Create([FromBody] ReadingListVM readinglistItem)
        {
            return Ok(_readingListService.Create(readinglistItem));
        }
        [HttpPut("Update")]
        public IActionResult Update([FromBody] ReadingListVM readinglistItem)
        {
            return Ok(_readingListService.Update(readinglistItem));
        }
        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_readingListService.Delete(id));
        }
    }
}