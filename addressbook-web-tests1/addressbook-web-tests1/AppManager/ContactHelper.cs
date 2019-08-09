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
        public string baseURL;
        public ContactHelper(ApplicationManager manager, string baseURL) : base (manager)
        {
            this.baseURL = baseURL;
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
        
            InitContactModification(v);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnHomePage();
            return this;
        }

        public bool IsContactExists ()
        {
            return (driver.Url == baseURL
                 && IsElementPresent(By.XPath("//img[@alt='Details']")));

        }


        public ContactHelper Remove()
        {
            SelectContact();
            RemoveContact();
            CloseAlertRemoveContact();
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
