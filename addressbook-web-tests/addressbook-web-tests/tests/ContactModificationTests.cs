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
            if (app.Contacts.IsContactsEmpty())
            {
                ContactData contact = (new ContactData("if empty"));
                contact.LastName = "bbbb";
                app.Contacts.Create(contact);
            }
            ContactData newData = (new ContactData("name1"));
            newData.LastName = "name2";
            app.Contacts.Modify(1, newData);
            
        }
    }
}
