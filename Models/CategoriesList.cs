using Newtonsoft.Json;
using System.Collections.Generic;
using TriviaBackend.Interfaces;

namespace TriviaBackend.Models
{
    public class CategoriesList : ICategoriesList
    {
        [JsonProperty("trivia_categories")]
        public List<Categories> TriviaCategory { get; set; }
    }
}
