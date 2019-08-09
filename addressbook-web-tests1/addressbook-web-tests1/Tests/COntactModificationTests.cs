using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]

     public void ContactModificationTest()
        {
            //prepare
            if (!app.Contacts.IsContactExists())
            {
                ContactData contact = new ContactData("Ivan");
                app.Contacts.Create(contact);
            }
            //action
            ContactData newData = new ContactData("Humphrey");
            newData.Lastname = "Van Weiden";
            newData.Company = null;
            newData.Address = null;
            newData.Address = null;
            newData.Email = null;
            newData.Mobile = null;
            app.Contacts.Modify( 1, newData);
        }

    }
}
