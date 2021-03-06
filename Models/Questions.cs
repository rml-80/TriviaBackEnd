﻿using Newtonsoft.Json;
using System.Collections.Generic;
using TriviaBackend.Interfaces;

namespace TriviaBackend.Models
{
    public class Questions : IQuestions
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
        public List<string> IncorrectAnswers { get; set; }
        [JsonProperty("alternatives")]
        public List<string> Alternatives { get; set; }
        [JsonProperty("questionNo")]
        public int QuestionNo { get; set; }
    }
}
