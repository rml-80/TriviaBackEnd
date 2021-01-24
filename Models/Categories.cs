﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaBackend.Models
{
    public class Categories
    {
        [JsonProperty("trivia_categories")]
        public List<TriviaCategories> TriviaCategory { get; set; }
    }
}
