using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TriviaBackend.Controllers;
using TriviaBackend.Models;

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
        // Get all categories as a alphabetically sorted list
        public static async Task<List<Categories>> GetJsonCategories()
        {
            var url = $"https://opentdb.com/api_category.php";
            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    if (!resp.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    else
                    {
                        var response = resp.Content.ReadAsStringAsync().Result;
                        var str = JsonConvert.DeserializeObject<CategoriesList>(response);
                        List<Categories> sorted = str.TriviaCategory;
                        sorted = sorted.OrderBy(n => n.Name).ToList();
                        return sorted;
                    }
                } 
            }
        }
        // Get requested amount of questions from all categories
        public static async Task<List<Questions>> GetJson(int numberOfQuestions)
        {
            var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}";
            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    if (!resp.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    else
                    {
                        var response = resp.Content.ReadAsStringAsync().Result;
                        var response1 = JsonConvert.DeserializeObject<APIResponse>(response);
                        if (response1.ResponseCode == 0)
                        {
                            questionList = response1.Result.ToList();
                            AddSort.AddAltAndSort(questionList);
                        }
                        else
                        {
                            questionList = null;
                        }
                        return questionList;
                    }
                } 
            }
        }
        // Get requested amount of questions from selected category
        public static async Task<List<Questions>> GetJsonCategory(int numberOfQuestions, int categoryId)
        {
            var url = $"https://opentdb.com/api.php?amount={numberOfQuestions}&category={categoryId}";
            using (var client = new HttpClient())
            {
                using (var resp = await client.GetAsync(url))
                {
                    if (!resp.IsSuccessStatusCode)
                    {
                        return null;
                    }
                    else
                    {
                        var response = resp.Content.ReadAsStringAsync().Result;
                        var response1 = JsonConvert.DeserializeObject<APIResponse>(response);
                        if (response1.ResponseCode == 0)
                        {
                            questionList = response1.Result.ToList();
                            AddSort.AddAltAndSort(questionList);
                        }
                        else
                        {
                            questionList = null;
                        }
                        return questionList;
                    }
                } 
            }
        }
    }
}
