using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAdressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("name");
            contact.Firstname = "Nickita2";
            contact.Lastname = "Mihailyuk2";
            contact.Middlename = "all_ok";
            app.Contacts.Create(contact);
        }
       
    }
}
