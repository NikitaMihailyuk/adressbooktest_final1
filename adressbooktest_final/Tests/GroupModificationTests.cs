using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.CheckGroup(1))
            {
                GroupData group = new GroupData("gruppa1");
                group.Header = ("gh1");
                group.Footer = ("gf1");
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData newData = new GroupData("zzz");
            newData.Header = null;
            newData.Footer = null;
            app.Groups.Modify(1, newData);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[1].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }
    }
}
