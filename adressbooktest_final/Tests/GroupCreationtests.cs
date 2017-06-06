using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
      
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData group = new GroupData("gruppa2");
            group.Header = ("gh1");
            group.Footer = ("gf1");
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData group = new GroupData("");
            group.Header = ("");
            group.Footer = ("");
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void BadNameGroupCreationTest()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            GroupData group = new GroupData("a'a");
            group.Header = ("");
            group.Footer = ("");
            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
