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
    public class GroupRemovalTests : AuthTestBase
    {
       

    [Test]
    public void GroupRemovalTest()
        {
            //prepare
            if (!app.Groups.IsGroupExists())
            {
                GroupData group = new GroupData("NewGroup");
                app.Groups.Create(group);
            }
            //action
            app.Groups.Remove(1);           
        }
           
    }
}
