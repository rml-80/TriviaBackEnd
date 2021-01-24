using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaBackend.Models
{
    public class Response
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        [JsonProperty("results")]
        public List<Results> Result { get; set; }

    }
}
