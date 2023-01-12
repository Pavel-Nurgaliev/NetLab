using System;
using System.Linq;

namespace FindWord
{
    public class StringProcessor
    {
        public static string GetFrequentWordInString(string inputMessage)
        {
            var inputToLowerCase = inputMessage.ToLower();

            var subMessages = inputToLowerCase.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var sortedSubMessages = subMessages
                .Distinct()
                .OrderBy(message => subMessages
                    .Count(sub => sub.Equals(message)))
                    .ToList();

            return sortedSubMessages.LastOrDefault();
        }
    }
}
