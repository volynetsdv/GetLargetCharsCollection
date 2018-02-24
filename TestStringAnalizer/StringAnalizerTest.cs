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
            collection.GetCharsCollection += Collection_GetCharsCollection;
            collection.GetCollection("aaa, ./ddddwww");
        }

        private void Collection_GetCharsCollection(object sender, StringFormating e)
        {
            string result = new string(e.Response);
            Assert.That(result, Is.EqualTo("dddd"));
        }
    }
}
