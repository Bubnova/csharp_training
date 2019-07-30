using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
       

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.InitNewContactCreation();
            ContactData contact = new ContactData("Ivan");
            contact.Lastname = "Ivanov";
            contact.Company = "SomeComp";
            contact.Address = "SomeAdr";
            contact.Mobile = "1111";
            contact.Email = "SomeEmail";
            contact.Bday = "1";
            contact.Bmonth = "January";
            contact.Byear = "2000";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Contacts.ReturnHomePage();
         
        }

      

      

     

      

     
    

     

   

       

       
    }
}
