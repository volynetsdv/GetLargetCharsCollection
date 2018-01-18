using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GetLargestCharsCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> requests = new List<string>();
            requests.Add("aasddssssddaaaffffeeeeee,,aad");
            requests.Add("ааа bbb с");
            requests.Add("а, b");
            requests.Add("а");
            requests.Add("а, b, с");
            requests.Add("а b с");
            requests.Add("аaaaaaaaaaaaaaaaaaaaa bbbbbbbbbb,с");

            GetCharCollection result = new GetCharCollection();
            for (int i = 0; i < requests.Count; i++)
            {

                Console.WriteLine("Request: " + requests[i]);
                string print = new string(result.GetCollection(requests[i], out int iteration));
                Console.WriteLine("Result: " + print);
                Console.WriteLine("iteration count:" + iteration);
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

    class GetCharCollection
    {
        protected internal char[] GetCollection(string request, out int count)
        {
            if (string.IsNullOrEmpty(request)) { count = 0; return null; }

            string foo = Regex.Replace(request, @"[^\w]", "", RegexOptions.Compiled);
            if (foo.Length <= 2) { count = 0; return foo.ToCharArray(); }


            int largestLength = 0;
            char[] bar = foo.ToCharArray();
            Array.Sort(bar); //на всякий случай, если вы захотите вводить данные беспорядочно

            string result = string.Empty;
            count = 0;
            for (int i = 0; i < foo.Length;)
            {
                int lastIndex = foo.LastIndexOf(bar[i]);
                int currentLength = lastIndex + 1 - i;
                if (currentLength > (float)foo.Length / 2) return foo.Substring(i, currentLength).ToCharArray();
                if (largestLength < currentLength)
                {
                    /*startIndexes.Clear();
                    startIndexes.Add(i);*/
                    largestLength = lastIndex - i + 1;
                    result = string.Empty;
                    result = foo.Substring(i, currentLength);
                }
                else if (largestLength == currentLength)
                {
                    /*startIndexes.Add(i);
                    largestLength = lastIndex - i + 1;*/
                    result += foo.Substring(i, currentLength);
                }
                i = i + lastIndex + 1;
                count++;
            }
            if (largestLength == 1) return foo.ToCharArray();
            return result.ToCharArray();
        }
    }
}
