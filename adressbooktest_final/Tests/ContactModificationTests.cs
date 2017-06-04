using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
   public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        { 
           if (app.Contacts.CheckContact(2))
            {
                ContactData contact = new ContactData("name");
                contact.Firstname = "Nickita2";
                contact.Lastname = "Mihailyuk2";
                contact.Middlename = "all_ok";
                app.Contacts.Create(contact);
            }
            ContactData newContact = new ContactData("name56");
            newContact.Firstname = "Nickita3212";
            newContact.Lastname = null;
            newContact.Middlename = null;
            app.Contacts.ModifyContact(2, newContact);
        }
    }
}
