using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class RemoveContactTests : AuthTestBase
    {


        [Test]
        public void RemoveContactTest()
        {
            app.Contacts.Remove(1);
        }

    }
}
