using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests 
{
    [TestFixture]
   public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.CheckGroup(1))
            {
                GroupData group = new GroupData("gruppa1");
                group.Header = ("gh1");
                group.Footer = ("gf1");
                app.Groups.Create(group);
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(1);
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(1);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
