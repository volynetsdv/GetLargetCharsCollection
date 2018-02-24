using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StringAnalizer;
using SimpleStringAnalizer;

//using StringAnalizer = SimpleStringAnalizer.StringAnalizer;

namespace GetLargestCharsCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                Console.WriteLine("Please, write number of program version:");
                Console.WriteLine("1. Simple and affactive logic without LINQ");
                Console.WriteLine("2. Primitive logic without LINQ");
                Console.WriteLine("3. Primitive logic with LINQ");
                var version = Console.ReadKey();
                if (version.KeyChar.Equals('1'))
                {
                    Logic run = new Logic(new StringAnalizer.GetCharCollection());
                    run.ConsoleUI();
                }
                if (version.KeyChar.Equals('2'))
                {
                    Logic run = new Logic(new SimpleStringAnalizer.StringAnalizer());
                    run.ConsoleUI();
                }
                if (version.KeyChar.Equals('3'))
                {
                    //дописать
                    Logic run = new Logic(new GetCharCollection());
                    run.ConsoleUI();
                }
            }
        }
    }

    internal class Logic
    {
        private readonly ICharCollection result;
        public Logic(ICharCollection _result)
        {
            result = _result;
        }
        internal void ConsoleUI()
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

                    Console.WriteLine("Please, enter \"test\" and press \"Enter\" if your wont ot see test demo");
                    Console.WriteLine("or enter your custom string like \"ааа bbb с\", press \"Enter\" and see result");
                    Console.WriteLine("For clousing program enter \"exit\"");
                    Console.WriteLine();
                    Console.Write("You request: ");
                    string customString = Console.ReadLine();
                    if (customString != null && customString.Equals("test"))
                    {
                        result.GetCharsCollection += Result_GetCharsCollection;
                        for (int i = 0; i < requests.Count; i++)
                        {
                            Console.WriteLine("Request: " + requests[i]);
                            result.GetCollection(requests[i]);
                        }
                        result.GetCharsCollection -= Result_GetCharsCollection;
                    }
                    else if (customString != null && customString.Equals("exit"))
                    {
                        Environment.Exit(0);
                    }
                    else if (customString != null)
                    {
                        result.GetCharsCollection += Result_GetCharsCollection;
                        result.GetCollection(customString);
                        result.GetCharsCollection -= Result_GetCharsCollection;
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
    }
    
}
