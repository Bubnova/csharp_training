using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests.Tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {

        [Test]
        public void GroupModificationTest()
        {
               //prepare
                if (!app.Groups.IsGroupExists())
                {
                    GroupData group = new GroupData("CreatedGroup");
                    app.Groups.Create(group);
                }
                //action
                GroupData newData = new GroupData("ModifiedGroup");
            newData.Header = null ;
            newData.Footer = null;
            app.Groups.Modify(1, newData);  

        }
    }
}
