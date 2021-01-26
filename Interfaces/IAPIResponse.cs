using System.Collections.Generic;
using TriviaBackend.Models;

namespace TriviaBackend.Interfaces
{
    interface IAPIResponse
    {
        public int ResponseCode { get; set; }
        public List<Questions> Result { get; set; }
    }
}
