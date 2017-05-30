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
    public class ContactCreationTests : TestBase
    {
        
        
        [Test]
        public void ContactCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();
            ContactData contact = new ContactData("name");
            contact.Firstname = "Nickita2";
            contact.Lastname = "Mihailyuk2";
            contact.Middlename = "all_ok";
            FillNewContact(contact);
            SubmitNewContact();
            Clicktohome();
        }
       
    }
}
