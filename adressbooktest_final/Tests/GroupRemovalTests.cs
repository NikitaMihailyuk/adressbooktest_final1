using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests 
{
    [TestFixture]
   public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.CheckGroup(0))
            {
                GroupData group = new GroupData("gruppa1");
                group.Header = ("gh1");
                group.Footer = ("gf1");
                app.Groups.Create(group);
            }
  
            List<GroupData> oldGroups = GroupData.GetAll();
             GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count  - 1, app.Groups.GetGroupCount());

            // List<GroupData> newGroups = app.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();
            
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id); ;
            }
          
        }
    }
}
