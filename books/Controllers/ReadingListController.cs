using books.Entities.Models;
using books.Entities.ViewModels;
using books.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace books.Controllers
{
    /// <summary>
    /// Controller to allow access to ReadingListService methods
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [EnableCors("_allowAllOrigins")]
    public class ReadingListController : ControllerBase
    {
        private readonly ILogger<ReadingListController> _logger;
        private readonly IReadingListService _readingListService;
        public ReadingListController(ILogger<ReadingListController> logger, IReadingListService readingListService)
        {
            _logger = logger;
            _readingListService = readingListService;
        }

        /// <summary>
        /// Get all books on ReadingList
        /// </summary>
        /// <returns>List of ReadingListVM</returns>
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_readingListService.GetAll());
        }

        /// <summary>
        /// Get ReadingList by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ReadingListVM</returns>
        [HttpGet("GetbyId")]
        public IActionResult GetbyId(int id)
        {
            return Ok(_readingListService.GetbyId(id));
        }

        /// <summary>
        /// Create new ReadingList entry
        /// </summary>
        /// <param name="readinglistItem"></param>
        /// <returns>Id of newly created ReadingList entry</returns>
        [HttpPost("Create")]
        public IActionResult Create([FromBody] ReadingListVM readinglistItem)
        {
            return Ok(_readingListService.Create(readinglistItem));
        }

        /// <summary>
        /// Update ReadingList in database
        /// </summary>
        /// <param name="readinglistItem"></param>
        /// <returns>Id of updated ReadingList</returns>
        [HttpPut("Update")]
        public IActionResult Update([FromBody] ReadingListVM readinglistItem)
        {
            return Ok(_readingListService.Update(readinglistItem));
        }

        /// <summary>
        /// Mark ReadingList as IsActive=false in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Id of updated ReadingList</returns>
        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            return Ok(_readingListService.Delete(id));
        }
    }
}