using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringAnalizer
{
    public class GetCharCollection : ICharCollection
    {
        public virtual char[] GetCollection(string request, out int count)
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
                    if (largestLength == 1 && i == foo.Length - 1) return foo.ToCharArray();
                    count++;
                }
                return result.ToCharArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                count = 0;
                return null;
            }
        }
    }
}
