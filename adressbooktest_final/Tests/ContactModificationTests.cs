﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
   public class ContactModificationTests : GroupTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            if (app.Contacts.CheckContact(0))
            {
                ContactData contact = new ContactData("name56");
                contact.Lastname = "Mihailyuk2";
                contact.Middlename = "all_ok";
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            ContactData newContact = new ContactData("name5222");
            newContact.Lastname = "434344";
            newContact.Middlename = null;

            app.Contacts.ModifyContact(0, newContact);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newContact.Firstname;
            oldContacts[0].Lastname  = newContact.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newContact.Firstname, contact.Firstname);
                    Assert.AreEqual(newContact.Lastname, contact.Lastname);
                }

            }

        }
    }
}
