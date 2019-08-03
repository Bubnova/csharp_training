using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
   public class ContactHelper : HelperBase
    {
               public ContactHelper(ApplicationManager manager): base (manager)
        {
          
        }

        public ContactHelper Create(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnHomePage();
            return this;
        }

        public ContactHelper Modify( int v, ContactData newData)
        {
           // SelectContact();
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnHomePage();


            return this;
        }

        public ContactHelper Remove()
        {
            SelectContact( );
            RemoveContact();
            CloseAlertRemoveContact();
            //Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper SelectContact()
        {

             driver.FindElement(By.XPath("//td/input")).Click();
            return this;
        }

        public ContactHelper CloseAlertRemoveContact()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

       

        public ContactHelper InitNewContactCreation()

        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("email"), contact.Email);
           
            //  driver.FindElement(By.Name("bday")).Click();
            //  new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            //  driver.FindElement(By.XPath("//option[@value='1']")).Click();
            //  driver.FindElement(By.Name("bmonth")).Click();
            //  new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            //  driver.FindElement(By.XPath("//option[@value='January']")).Click();
            //  driver.FindElement(By.Name("byear")).Click();
            //  driver.FindElement(By.Name("byear")).Clear();
            //  driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
        public ContactHelper ReturnHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
