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
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactData GetContactInformationFromTable(int inf)
        {
         manager.Navigator.OpenHomePage();

          IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[inf]
         .FindElements(By.TagName("td"));
           string lastName = cells[1].Text;
           string FirstName = cells[2].Text;
           string address = cells[3].Text;
           string allPhones = cells[5].Text;

         return new ContactData(FirstName, lastName)
          {   Address = address,
         AllPhones = allPhones, };      
        }

        public ContactData GetContactInformationFromPersonalform(int v)
        {
            manager.Navigator.OpenHomePage();
            SelectContactForDetail(v);
            string cell = driver.FindElement(By.XPath("//div[@id='content']")).Text;
            cell.Replace("Anniversary", "").Replace("(27)", "").Replace("Birthday", "").Replace("W:", "")
       .Replace("M:", "").Replace("H:", "").Replace("Homepage:", "").Replace("F:", "").Replace("P:", "")
       .Replace("\n", "").Replace("\r", "").Replace(" ", "").Replace("*", "").Replace(".", "").Replace("-", "");

            return new ContactData  (cell);
        }


        public ContactData GetContactInformationFullFromTable(int v)
        {
            manager.Navigator.OpenHomePage();
            SelectContactForModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string middlename = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string nickname = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string aday = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string amonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string ayear = driver.FindElement(By.Name("ayear")).GetAttribute("value");
            string bday = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bmonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string byear = driver.FindElement(By.Name("byear")).GetAttribute("value");

             string cell = firstname+lastname+middlename+nickname+ title+company+
                address+homePhone+mobilePhone
                +workPhone+fax+email1+email2+email3
                +homepage+aday+amonth+ayear+bday+bmonth+byear;
            cell.Replace("Anniversary","").Replace("(27)","").Replace("Birthday","").Replace("W:","")
              .Replace("M:","").Replace("H:","").Replace("Homepage:","").Replace("F:","").Replace("P:","")
           .Replace("\n","").Replace("\r","").Replace(" ","").Replace("*","").Replace(".","").Replace("-","");
            return new ContactData (cell);
            }
       
        public ContactData GetContactInformationFromEditForm(int index1)
        {
            manager.Navigator.OpenHomePage();
            SelectContactForModification(index1);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string adress = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

             return new ContactData(firstname, lastname)
            {
                Address = adress,
                Home = homePhone,
                Work = workPhone,
                Mobile = mobilePhone
             };
        }

        public ContactHelper ContactRemove(int v)
        {
            SelectContactForModification(v);
            RemoveContact();
            manager.Navigator.Clicktohome();
            return this;
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
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
            contactCache = null;
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContactForModification(int v)
        {
            driver.FindElements(By.Name("entry"))[v]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            contactCache = null;
            return this;
        }
         public ContactHelper SelectContactForDetail(int v)
        {
            driver.FindElements(By.Name("entry"))[v]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
        
            return this;
        }

        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
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
        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.OpenHomePage();
                List<ContactData> contacts = new List<ContactData>();
                ICollection<IWebElement> contactElements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in contactElements)
                {
                    string fn = element.FindElements(By.TagName("td"))[2].Text;
                    string ln = element.FindElements(By.TagName("td"))[1].Text;
                    
                    contactCache.Add(new ContactData(fn, ln)
                    { Id = element.FindElement(By.TagName("input")).GetAttribute("value") });
                }
            }
            return new List<ContactData>(contactCache);
        }
       
    }

}