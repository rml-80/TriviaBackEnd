using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TriviaBackend.Models;
using Microsoft.Extensions.Caching.Memory;
using TriviaBackend.Controllers;

namespace TriviaBackend
{
    public class GetAPIData
    {
        private readonly IMemoryCache _memoryCache;
        static List<Questions> questionList = new List<Questions>();
        public GetAPIData(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public static async Task<List<Questions>> GetJson(int numberOfQuestions)
        {
            var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}";

            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    var response = resp.Content.ReadAsStringAsync().Result;
                    var response1 = JsonConvert.DeserializeObject<APIResponse>(response);
                    questionList = response1.Result.ToList();
                    AddSort.AddAltAndSort(questionList);
                    return questionList;
                }
            }
        }

        public static async Task<List<Questions>> GetJsonCategory(int numberOfQuestions, int categoryId)
        {
            var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}&category={categoryId}";
            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    var response = resp.Content.ReadAsStringAsync().Result;
                    var response1 = JsonConvert.DeserializeObject<APIResponse>(response);
                    questionList = response1.Result.ToList();
                    AddSort.AddAltAndSort(questionList);
                    return questionList;
                }
            }
        }

        public static async Task<List<Categories>> GetJsonCategories()
        {
            var url = $"https://opentdb.com/api_category.php";
            try
            {
                using (var client = new HttpClient())
                {
                    using (var resp = await client.GetAsync(url))
                    {
                        var response = resp.Content.ReadAsStringAsync().Result;
                        var str = JsonConvert.DeserializeObject<CategoriesList>(response);
                        List<Categories> sorted = str.TriviaCategory;
                        sorted = sorted.OrderBy(n => n.Name).ToList();
                        return sorted;
                    }
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
