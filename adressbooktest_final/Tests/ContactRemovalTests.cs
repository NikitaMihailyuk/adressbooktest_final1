using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
   public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {

            if (app.Contacts.CheckContact(2))
            {
                ContactData contact = new ContactData("name");
                contact.Firstname = "Nickita2";
                contact.Lastname = "Mihailyuk2";
                contact.Middlename = "all_ok";
                app.Contacts.Create(contact);
            }
            app.Contacts.ContactRemove(2);
        }
    }
}
