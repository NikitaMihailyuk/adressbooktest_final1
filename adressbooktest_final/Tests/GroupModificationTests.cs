using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            if (app.Groups.CheckGroup(0))
            {
                GroupData group = new GroupData("gruppa1");
                group.Header = ("gh1");
                group.Footer = ("gf1");
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = GroupData.GetAll() ;
            GroupData oldData = oldGroups[0];

            GroupData newData = new GroupData("z2323z");
            newData.Header = "2fgfdgdfg3";
            newData.Footer = null;
            app.Groups.Modify(oldData, newData);


            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;


            oldGroups.Sort();
            newGroups.Sort();


            Assert.AreEqual(oldGroups, newGroups);

            foreach ( GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }
    }
}
