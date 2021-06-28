using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class RemoveContactTests : AuthTestBase
    {


        [Test]
        public void RemoveContactTest()
        {
            app.Navigator.OpenHomePage();
            if (app.Contacts.IsContactsEmpty())
            {
                ContactData contact = (new ContactData("if empty"));
                contact.LastName = "bbbb";
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(0);
            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
