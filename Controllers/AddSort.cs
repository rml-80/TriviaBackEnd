using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TriviaBackend.Models;

namespace TriviaBackend.Controllers
{
    public class AddSort
    {
        public static List<Questions> AddAltAndSort(List<Questions> questionList)
        {
            var i = 1;
            foreach (var item in questionList)
            {
                item.QuestionNo = i;
                item.Alternatives = new List<string>
                {
                    item.CorrectAnswer
                };
                foreach (var alt in item.IncorrectAnswers)
                {
                    item.Alternatives.Add(alt);
                }
                item.Alternatives.Sort();
                i++;
            }
                return questionList;
        }
    }
}
