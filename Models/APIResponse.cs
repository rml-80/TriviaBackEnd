using Newtonsoft.Json;
using System.Collections.Generic;
using TriviaBackend.Interfaces;

namespace TriviaBackend.Models
{
    public class APIResponse : IAPIResponse
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        [JsonProperty("results")]
        public List<Questions> Result { get; set; }

    }
}
