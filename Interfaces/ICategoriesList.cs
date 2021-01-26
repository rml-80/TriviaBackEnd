using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaBackend.Models;

namespace TriviaBackend.Interfaces
{
    interface ICategoriesList
    {
        public List<Categories> TriviaCategory { get; set; }
    }
}
