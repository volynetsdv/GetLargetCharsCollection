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
        public event EventHandler<StringFormating> GetCharsCollection;
        public virtual void GetCollection(string request)
        {
            int count = 0;
            try
            {
                if (string.IsNullOrEmpty(request)) { GetCharsCollection(this, null); }
                
                string foo = Regex.Replace(request, @"[^\w]", "", RegexOptions.Compiled);
                if (foo.Length <= 2)
                {
                    count = 0;
                    GetCharsCollection(this, new StringFormating(foo.ToCharArray(), count));
                    return;
                }

                int largestLength = 0;
                string result = string.Empty;
                char[] bar = foo.ToCharArray();
                Array.Sort(bar); //на всякий случай, если вы захотите вводить данные беспорядочно
                foo = new string(bar);

                for (int i = 0; i < foo.Length;)
                {
                    int lastIndex = foo.LastIndexOf(bar[i]);
                    int currentLength = lastIndex + 1 - i;
                    if (currentLength > (float) foo.Length / 2)
                    {
                        GetCharsCollection(this, new StringFormating(foo.Substring(i, currentLength).ToCharArray(),count));
                        return;
                    }
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
                    if (largestLength == 1 && i == foo.Length - 1)
                    {
                        GetCharsCollection(this, new StringFormating(foo.ToCharArray(),count));
                        return;
                    }
                    count++;
                }
                GetCharsCollection(this, new StringFormating(result.ToCharArray(),count)); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                count = 0;
                GetCharsCollection(this, null);
            }
        }
        
    }
}
