using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAdressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            //Verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }


        [Test]
        public void TestContactInformationdetail()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFullFromTable(0);
            ContactData fromPersonalForm = app.Contacts.GetContactInformationFromPersonalform(0);
            Assert.AreEqual(fromTable, fromPersonalForm);
        }
    }
}
