using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GetLargetCharsCollection;

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
            Console.WriteLine("Please, enter \"test\" and press \"Enter\" if your wont ot see test demo");
            Console.WriteLine("or enter your custom string like \"ааа bbb с\", press \"Enter\" and see result");
            string custom = Console.ReadLine();
            if (custom != null && custom.Equals("test"))
            {
                for (int i = 0; i < requests.Count; i++)
                {

                    Console.WriteLine("Request: " + requests[i]);
                    string print = new string(result.GetCollection(requests[i], out int iteration));
                    Console.WriteLine("Result: " + print);
                    Console.WriteLine("iteration count:" + iteration);
                    Console.WriteLine();
                }
            }
            else
            {

            }
            Console.ReadKey();
        }
    }

    sealed class GetCharCollection : ICharCollection
    {
        public char[] GetCollection(string request, out int count)
        {
            try
            {
                if (string.IsNullOrEmpty(request)) { count = 0; return null; }

                string foo = Regex.Replace(request, @"[^\w]", "", RegexOptions.Compiled);
                if (foo.Length <= 2) { count = 0; return foo.ToCharArray(); }

                int largestLength = 0;
                string result = string.Empty;
                count = 0;
                char[] bar = foo.ToCharArray();
                Array.Sort(bar); //на всякий случай, если вы захотите вводить данные беспорядочно
                foo = new string(bar); 
                
                for (int i = 0; i < foo.Length;)
                {
                    int lastIndex = foo.LastIndexOf(bar[i]);
                    int currentLength = lastIndex + 1 - i;
                    if (currentLength > (float)foo.Length / 2) return foo.Substring(i, currentLength).ToCharArray();
                    if (largestLength < currentLength)
                    {
                        largestLength = currentLength;
                        result = string.Empty;
                        result = foo.Substring(i, currentLength);
                    }
                    else if (largestLength == currentLength)
                    {
                        result += foo.Substring(i, currentLength);
                    }
                    i += currentLength;
                    if (largestLength == 1 && i == foo.Length-1) return foo.ToCharArray();
                    count++;
                }
                
                return result.ToCharArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
