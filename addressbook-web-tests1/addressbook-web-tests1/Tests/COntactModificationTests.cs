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
    public class ContactModificationTests : TestBase
    {
        [Test]

     public void ContactModificationTest()
        {

            ContactData newData = new ContactData("Humphrey");
            newData.Lastname = "Van Weiden";
            newData.Company = "AnotherComp";
            newData.Address = "AnotherAdr";
            newData.Email = "NewEmail";
            app.Contacts.Modify( 1, newData);
        }

    }
}
