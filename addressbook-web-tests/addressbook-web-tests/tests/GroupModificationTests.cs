using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests

{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {


        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();
            if (app.Groups.IsGroupListEmpty())
            {
                GroupData group = new GroupData("if empty");
                group.Header = "";
                group.Footer = "";
                app.Groups.Create(group);
            }
            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(0,newData);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name=newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
