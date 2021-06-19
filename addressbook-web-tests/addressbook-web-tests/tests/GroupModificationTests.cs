using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests

{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {


        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = "xxx";
            newData.Footer = "yyy";
            app.Groups.Modify(1,newData);
            
        }
    }
}
