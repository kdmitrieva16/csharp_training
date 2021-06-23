using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper:HelperBase 
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactData contact)
        {
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToHomePage();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("selected[]"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text));
            }
            return contacts;
        }

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            DeleteSelectedContact();
            SubmitContactDeletion();
            manager.Navigator.GotoHomePage();
            return this;
        }
        public ContactHelper Modify(int p, ContactData newData)
        {
            SelectContact(p);
            InitContactModification();
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToHomePage();
            return this;

        }

      

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("lastname"), contact.LastName);
            return this;
        }
        public ContactHelper InitContactCreation()
        {
           driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index + 1) + "]")).Click();
            return this;
        }

        public ContactHelper DeleteSelectedContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper SubmitContactDeletion()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            return this; 
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            return this;
        }

        public bool IsContactsEmpty()
        {
            manager.Navigator.OpenHomePage();
            return !IsElementPresent(By.XPath("//input[@name='selected[]']"));
        }

    }
}
