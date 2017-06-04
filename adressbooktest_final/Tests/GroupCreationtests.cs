﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
      
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("gruppa1");
            group.Header = ("gh1");
            group.Footer = ("gf1");
            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = ("");
            group.Footer = ("");
            app.Groups.Create(group);
        }
    }
}
