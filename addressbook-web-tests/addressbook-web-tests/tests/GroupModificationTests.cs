using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests

{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeModified = oldGroups[0]; ;
            app.Groups.Modify(toBeModified, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            toBeModified.Name=newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == toBeModified.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }
    }
}
