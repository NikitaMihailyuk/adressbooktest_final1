using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
namespace WebAdressbookTests 
{
    [TestFixture]
   public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            if (app.Groups.CheckGroup(2))
            {
                GroupData group = new GroupData("gruppa1");
                group.Header = ("gh1");
                group.Footer = ("gf1");
                app.Groups.Create(group);
            }

            app.Groups.Remove(2);

        }
    }
}
