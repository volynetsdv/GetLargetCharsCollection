using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StringAnalizer;

namespace SimpleStringAnalizer
{
    public class StringAnalizer: ICharCollection
    {
        public event EventHandler<StringFormating> GetCharsCollection;

        public void GetCollection(string request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request))
                {
                    string clearString = Regex.Replace(request, @"[^\w]", "", RegexOptions.Compiled);
                    string largestCollection = string.Empty;
                    Dictionary<char, int> dic = new Dictionary<char, int>();
                    int count = 0;
                    for (; count < clearString.Length; count++)
                    {
                        if (dic.ContainsKey(clearString[count]))
                        {
                            int temp = 0;
                            dic.TryGetValue(clearString[count], out temp);
                            temp++;
                            dic[clearString[count]] = temp;
                        }
                        else
                        {
                            dic.Add(clearString[count], 1);
                        }
                    }
                    if (dic.Any())
                    {
                        //dic.GroupBy()
                        int maxLengthUniqCharCollection = dic.Max().Value;
                        //получить список всех ключей с таким велю
                    }
                    GetCharsCollection(this, new StringFormating(largestCollection.ToCharArray(), count));
                }
                throw new NotFiniteNumberException();
            }
            catch (Exception e)
            {
                //в идеале можем подключить NLog и писать ексепшн в лог
                Console.WriteLine(e);
                
            }
        }
    }
}
