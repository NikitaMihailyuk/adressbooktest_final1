using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    public class ContactHelper :HelperBase
    {
       
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper ContactRemove(int v)
        {
            SelectContactForModification(v);
            RemoveContact();
            manager.Navigator.Clicktohome();
            return this;
        }

        public ContactHelper ModifyContact(int v, ContactData newContact)
        {
            SelectContactForModification(v);
            FillNewContact(newContact);
            UpdateNewContact();
            manager.Navigator.Clicktohome();
            return this;
        }

        public ContactHelper UpdateNewContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            return this;
        }

        public ContactHelper SelectContactForModification(int v)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (v+1) + "]")).Click();
            return this;
        }

        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public bool CheckContact(int v)
        {
            return IsElementPresent(By.Name("Selected[" + (v+1) + "]"));
        }

        public ContactHelper FillNewContact(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("photo"), contact.Photo);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            Type(By.Name("byear"), contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            Type(By.Name("ayear"), contact.Ayear);
            Type(By.Name("byear"), contact.Byear);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            return this;
        }

        public ContactHelper Create(ContactData contact)
        {
            AddNewContact();
            FillNewContact(contact);
            SubmitNewContact();
            manager.Navigator.Clicktohome();
            return this;
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.OpenHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr"));
            int elcount = elements.Count();
            for (int index = 1; index < elcount ; index++)
            {
                IWebElement lastName = driver.FindElement(By.XPath("(//tr[@name='entry'][" + index + "]/td[2])"));
                IWebElement firstName = driver.FindElement(By.XPath("(//tr[@name='entry'][" + index + "]/td[3])"));
                contacts.Add(new ContactData(firstName.Text+lastName.Text));
            }
            return contacts;
        }
    }

}
