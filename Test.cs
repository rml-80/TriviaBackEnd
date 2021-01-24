using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TriviaBackend.Models;

namespace TriviaBackend
{
    public class Test
    {
        public static async Task<Response> GetJson(int numberOfQuestions)
        {
            var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}";
            using (var client = new HttpClient())
            {
                var resp = await client.GetAsync(url);
                var response = resp.Content.ReadAsStringAsync().Result;
                dynamic obj = JsonConvert.DeserializeObject<Response>(response).Result;

                return obj;
            }

        }
    }
}
