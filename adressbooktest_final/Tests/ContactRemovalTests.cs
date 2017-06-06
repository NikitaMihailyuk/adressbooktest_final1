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

            if (app.Contacts.CheckContact(1))
            {
                ContactData contact = new ContactData("name");
                contact.Firstname = "Nickita2";
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.ContactRemove(1);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(1);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
