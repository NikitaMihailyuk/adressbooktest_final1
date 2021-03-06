﻿using System;
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

            if (app.Contacts.CheckContact(0))
            {
                ContactData contact = new ContactData("name");
                contact.Firstname = "Nickita2";
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ///Даный тест нельзя изменить так как из бд контакты не удаляются нужно писать запрос для возврата только тех данных
            //у которых нет даты конца в БД
          
            ContactData toBeRemoved = oldContacts[0];


            app.Contacts.ContactRemove(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(0);


            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id); ;
            }
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
