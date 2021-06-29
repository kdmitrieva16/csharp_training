using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactInformationTest: AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

      //  [Test]

        //public void TestContactDetailsInformation()
       // {
        //    ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
        //    ContactData fromDetails = app.Contacts.GetContactInformationFromDetals(0);

            //verification
        //    Assert.AreEqual(fromTable, fromForm);
         //   Assert.AreEqual(fromTable.Address, fromForm.Address);
         //   Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
         //   Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
       // }

       
    }

    
}
