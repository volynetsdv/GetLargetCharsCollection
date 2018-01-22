using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StringAnalizer;

namespace TestStringAnalizer
{
    [TestFixture]
    public class StringAnalizerTest
    {
        [Test]
        public void GetCollection_CharArrayValidation()
        {
            ICharCollection collection = new GetCharCollection();
            //int count = 0;
            //char[] test = collection.GetCollection(Guid.NewGuid().ToString(),out count);
            //string testString = new string(test);
            //Assert.That(testString, Is.InRange('a','z')); //переписать на свежую голову
        }
    }
}
