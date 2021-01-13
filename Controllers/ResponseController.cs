using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TriviaBackend.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TriviaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        // GET: api/<ResponseController>
        [HttpGet("{numberOfQuestions}")]
        public async Task<IActionResult> Get(int numberOfQuestions)
        {
            var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}";

            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    var responseContent = await resp.Content.ReadAsStringAsync();
                    Response response = JsonConvert.DeserializeObject<Response>(responseContent);
                    return Ok(response);
                }

            }


        }

        //    // GET api/<ResponseController>/5
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = $"https://opentdb.com/api_category.php";

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(url))
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Categories categorys = JsonConvert.DeserializeObject<Categories>(responseContent);
                    return Ok(categorys);
                }
            }
        }

        //    // POST api/<ResponseController>
        //    [HttpPost]
        //    public void Post([FromBody] string value)
        //    {
        //    }

        //    // PUT api/<ResponseController>/5
        //    [HttpPut("{id}")]
        //    public void Put(int id, [FromBody] string value)
        //    {
        //    }

        //    // DELETE api/<ResponseController>/5
        //    [HttpDelete("{id}")]
        //    public void Delete(int id)
        //    {
        //    }
    }
}
