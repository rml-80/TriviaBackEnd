using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Threading.Tasks;
using TriviaBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        public ResponseController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        // get X number of questions from all categories
        // GET: api/<ResponseController>
        [HttpGet("{numberOfQuestions}")]
        public async Task<IActionResult> Get(int numberOfQuestions)
        {
            var temp = await GetAPIData.GetJson(numberOfQuestions);
            if (temp == null)
            {
                return BadRequest();
            }
            return Ok(temp);
        }
        // get X number of questions from a category
        // GET: api/<ResponseController>
        [HttpGet("{categoryId}/{numberOfQuestions}")]
        public async Task<IActionResult> Get(int numberOfQuestions, int categoryId)
        {
            var temp = await GetAPIData.GetJsonCategory(numberOfQuestions, categoryId);
            if (temp == null)
            {
                return BadRequest();
            }
            return Ok(temp);
        }
        // get all categories
        // GET api/<ResponseController>/5
        [HttpGet("categories")]
        public async Task<IActionResult> Get()
        {
            var cacheKey = "CategoryList";
            var orderdJson = await GetAPIData.GetJsonCategories();
            if (orderdJson == null)
            {
                return BadRequest();
            }
            else
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<Categories> orderd))
                {
                    orderd = orderdJson;
                    _memoryCache.Set(cacheKey, orderd);
                }
                return Ok(orderd);
            }
        }
    }
}