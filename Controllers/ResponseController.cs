using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TriviaBackend.Models;
using Microsoft.Extensions.Caching.Memory;

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
            try
            {
                return Ok(await GetAPIData.GetJson(numberOfQuestions));
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        // get X number of questions from a category
        // GET: api/<ResponseController>
        [HttpGet("{categoryId}/{numberOfQuestions}")]
        public async Task<IActionResult> Get(int numberOfQuestions, int categoryId)
        {

            try
            {
                return Ok(await GetAPIData.GetJsonCategory(numberOfQuestions, categoryId));
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        // get all categories
        // GET api/<ResponseController>/5
        [HttpGet("categories")]
        public async Task<IActionResult> Get()
        {
            var cacheKey = "CategoryList";
            try
            {
                if (!_memoryCache.TryGetValue(cacheKey, out List<Categories> orderd))
                {
                    orderd = await GetAPIData.GetJsonCategories();
                    _memoryCache.Set(cacheKey, orderd);
                }
                return Ok(orderd);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}
