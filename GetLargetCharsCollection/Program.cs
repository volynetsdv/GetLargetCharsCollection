using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StringAnalizer;

namespace GetLargestCharsCollection
{
    internal class Program
    {
        static void ConsoleUI()
        {
            try
            {
                for (;;)
                {
                    List<string> requests = new List<string>();
                    requests.Add("aasddssssddaaaffffeeeeee,,aad");
                    requests.Add("ааа bbb с");
                    requests.Add("а, b");
                    requests.Add("а");
                    requests.Add("а, b, с");
                    requests.Add("а b с");
                    requests.Add("аaaaaaaaaaaaaaaaaaaaa bbbbbbbbbb,с");

                    ICharCollection result = new GetCharCollection();

                    Console.WriteLine("Please, enter \"test\" and press \"Enter\" if your wont ot see test demo");
                    Console.WriteLine("or enter your custom string like \"ааа bbb с\", press \"Enter\" and see result");
                    Console.WriteLine("For clousing program enter \"exit\"");
                    Console.WriteLine();
                    Console.Write("You request: ");
                    string customString = Console.ReadLine();
                    if (customString != null && customString.Equals("test"))
                    {
                        for (int i = 0; i < requests.Count; i++)
                        {
                            result.GetCharsCollection += Result_GetCharsCollection;
                            Console.WriteLine("Request: " + requests[i]);
                            result.GetCollection(requests[i]);
                            result.GetCharsCollection -= Result_GetCharsCollection;
                        }
                    }
                    else if (customString != null && customString.Equals("exit"))
                    {
                        break;
                    }
                    else if (customString != null)
                    {
                        result.GetCharsCollection += Result_GetCharsCollection;
                        Console.WriteLine("Request: " + customString);
                        result.GetCollection(customString);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect string");
                        Console.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private static void Result_GetCharsCollection(object sender, StringFormating e)
        {    
            string print = new string(e.Response);
            Console.WriteLine("Result: " + print);
            Console.WriteLine("iteration count:" + e.Count);
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            ConsoleUI();
        }
    }

    
}
