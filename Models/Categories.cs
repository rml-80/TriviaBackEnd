using Newtonsoft.Json;
using TriviaBackend.Interfaces;

namespace TriviaBackend.Models
{
    public class Categories : ICategories
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
