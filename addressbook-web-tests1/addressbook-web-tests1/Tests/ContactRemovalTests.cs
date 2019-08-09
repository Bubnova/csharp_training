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
        public class ContactRemovalTests : AuthTestBase
    {


            [Test]
            public void ContactRemovalTest()
            {
            //prepare
            if (!app.Contacts.IsContactExists())
            {
                ContactData contact = new ContactData("Ivan");
                app.Contacts.Create(contact);               
            }
            //action
                app.Contacts.Remove();

            }

        }
    
}
