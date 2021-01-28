using System.Collections.Generic;
using TriviaBackend.Models;

namespace TriviaBackend.Controllers
{
    public class AddSort
    {
        // Return a sorted list with a question id in form of a int, and a new List for alternatives
        // API returns Correct answer by it self, and the rest of alternatives as a list, so I want to 
        // combine these to a own list called alternatives for better displaying in frontend
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
