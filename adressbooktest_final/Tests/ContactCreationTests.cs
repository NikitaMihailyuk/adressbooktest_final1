using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests 
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData contact = new ContactData("goonetime211321");
            contact.Lastname = "itwasme12323";
            app.Contacts.Create(contact);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort(); 
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
       
    }
}
