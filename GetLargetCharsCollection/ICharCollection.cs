using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLargetCharsCollection
{
    interface ICharCollection
    {
        char[] GetCollection(string request, out int count);
    }
}
