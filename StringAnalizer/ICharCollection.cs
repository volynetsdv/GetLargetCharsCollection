using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAnalizer
{
    public interface ICharCollection
    {
        void GetCollection(string request);
        event EventHandler<StringFormating> GetCharsCollection;
    }
}
