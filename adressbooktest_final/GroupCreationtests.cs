using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
      
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin","secret"));
            GoToGroupsPage();
            InitGroupcreation();
            GroupData group = new GroupData("gruppa1");
            group.Header = ("gh1");
            group.Footer = ("gf1");
            FillGroupForm(group);
            SubmitGroupCeation();
            ReturnToGroupsPage();
        }

        
    }
}
