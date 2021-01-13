using Newtonsoft.Json;
using System.Collections.Generic;

namespace TriviaBackend.Models
{
    public class Results
	{
		[JsonProperty("category")]
        public string Category { get; set; }
		[JsonProperty("type")]
		public string Type { get; set; }
		[JsonProperty("difficulty")]
		public string Difficulty { get; set; }
		[JsonProperty("question")]
		public string Question { get; set; }
		[JsonProperty("correct_answer")]
		public string CorrectAnswer { get; set; }
		[JsonProperty("incorrect_answers")]
		public IList<string> IncorrectAnswers { get; set; }
	}
}
