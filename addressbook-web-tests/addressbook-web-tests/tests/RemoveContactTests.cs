using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class RemoveContactTests : TestBase
    {


        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.Remove(1);
        }

    }
}
