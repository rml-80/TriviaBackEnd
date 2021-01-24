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
            var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}";
            using (var client = new HttpClient())
            {
                var resp = await client.GetAsync(url);
                var response = resp.Content.ReadAsStringAsync().Result;
                var response1 = JsonConvert.DeserializeObject<Response>(response);
                List<Results> questionList = response1.Result.ToList();
                var i = 1;
                foreach (var item in questionList)
                {
                    item.QuestionNo = i;
                    item.Alternatives = new List<string>();
                    item.Alternatives.Add(item.CorrectAnswer);
                    foreach (var alt in item.IncorrectAnswers)
                    {
                        item.Alternatives.Add(alt);
                    }
                    i++;
                }
                return Ok(questionList);
            }
        }

        // get X number of questions from a category
        // GET: api/<ResponseController>
        [HttpGet("{categoryId}/{numberOfQuestions}")]
        public async Task<IActionResult> Get(int numberOfQuestions, int categoryId)
        {
            var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}&category={categoryId}";

            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    var response = await resp.Content.ReadAsStringAsync();
                    return Ok(response);
                }
            }
        }
        // get all categories
        // GET api/<ResponseController>/5
        [HttpGet("categories")]
        public async Task<IActionResult> Get()
        {
            var url = $"https://opentdb.com/api_category.php";
            var cacheKey = "CategoryList";

            if (!_memoryCache.TryGetValue(cacheKey, out List<TriviaCategories> orderd))
            {
                using (var client = new HttpClient())
                {
                    using (var resp = await client.GetAsync(url))
                    {
                        var response = resp.Content.ReadAsStringAsync().Result;
                        var str = JsonConvert.DeserializeObject<Categories>(response);
                        List<TriviaCategories> sorted = str.TriviaCategory.ToList();
                        orderd = sorted.OrderBy(n => n.Name.Substring(0)).ToList();
                    }
                }
                _memoryCache.Set(cacheKey, orderd);
            }
            return Ok(orderd);
        }

    }
}
