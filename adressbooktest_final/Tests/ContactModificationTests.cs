using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAdressbookTests
{
    [TestFixture]
   public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newContact = new ContactData("name56");
            newContact.Firstname = "Nickita32222";
            newContact.Lastname = "Mihailyuk322222";
            newContact.Middlename = "all_ok222222";
            app.Contacts.ModifyContact(2, newContact);
        }
    }
}
