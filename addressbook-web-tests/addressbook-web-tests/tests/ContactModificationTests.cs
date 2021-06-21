using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {


        [Test]
        public void ContactModificationTest()
        {

            ContactData newData = (new ContactData("name1"));
            newData.LastName = "name2";
            app.Contacts.Modify(1, newData);
            
        }
    }
}
