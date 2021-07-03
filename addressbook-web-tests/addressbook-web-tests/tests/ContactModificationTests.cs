using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTests : ContactTestBase
    {


        [Test]
        public void ContactInformationTest()
        {
            if (app.Contacts.IsContactsEmpty())
            {
                ContactData contact = (new ContactData("if empty"));
                contact.LastName = "bbbb";
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeModified = oldContacts[0];
            ContactData newData = (new ContactData("name1"));
            newData.LastName = "name2";
            app.Contacts.Modify(toBeModified, newData);
            Assert.AreEqual(oldContacts.Count,app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            toBeModified.FirstName = newData.FirstName;
            toBeModified.LastName = newData.LastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.FirstName, contact.FirstName);
                    Assert.AreEqual(newData.LastName, contact.LastName);
                }
            }


        }
    }
}
