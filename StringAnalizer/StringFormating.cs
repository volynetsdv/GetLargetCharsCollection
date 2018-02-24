using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalizer
{
    public class StringFormating: EventArgs
    {
        public StringFormating(char[] response, int count)
        {
            Response = response;
            Count = count;
        }
        public char[] Response { get; private set; }
        public int Count { get; private set; }
    }
}
