﻿using System;
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
    public class GroupHelper:HelperBase
    {
        public string baseURL;
        public GroupHelper (ApplicationManager manager, string baseURL) : base (manager)
        {
            this.baseURL = baseURL;
        }

        public GroupHelper Remove (int p)
        {
            manager.Navigator.GoToGroupsPage();
            if (driver.Url == baseURL + "group.php"
                 && IsElementPresent(By.XPath("//input[@name='selected[]']")))
            {
                //если найден, то удалить
                SelectGroup(p);
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
            }
            //если не найден, то создать            
            GroupData group = new GroupData("ccc");
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();

            //удалить созданный           
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify (int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            if (driver.Url == baseURL + "group.php"
                 && IsElementPresent(By.XPath("//input[@name='selected[]']")))
            {
                //если найден, то изменить
                SelectGroup(p);
                InitGroupModification();
                FillGroupForm(newData);
                SubmitGroupModification();
                ReturnToGroupsPage();
                return this;
            }
            //если не найден, то создать
            GroupData group = new GroupData("ccc");
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();

            //изменить 
            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

      

        public GroupHelper Create(GroupData group)
        {
         manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
                FillGroupForm(group);
                SubmitGroupCreation();
               ReturnToGroupsPage();
            return this;
        }


        public GroupHelper InitNewGroupCreation()
        {

            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
           
            return this;
        }

       

        public GroupHelper SubmitGroupCreation()
        {

            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper ReturnToGroupsPage()
        {

            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
    }
}
