using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAdressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string nickname = "";
        private string photo = "";
        private string title = "";
        private string company = "";
        private string fax = "";
        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "10";
        private string bmonth = "May";
        private string byear = "1990";
        private string aday = "10";
        private string amonth = "May";
        private string ayear = "1990";
        private string address2 = "";
        private string phone2 = "";
        private string notes = "";
        private string allPhones;
        private string aLastname;
        private string aMiddlename;
        private string aNickname;
        private string aAddress;
        private string aTitle;
        private string aCompany;
        private string ahomePhone;
        private string amobilePhone;
        private string aworkPhone;
        private string afax;
        private string aemail1;
       private string aemail2;
       private string aemail3;
       private string ahomePage;
       private string aaday;
       private string aamonth;
       private string aayear;
       private string abday;
       private string abmonth;
       private string abyear;
       private string allinform;
        private string aaddress2;
        private string aphone2;
        private string anotes;
        private string acell;
        private string cell;



        public ContactData()
        {
        }
        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public ContactData(string firstname)
        {
            Firstname = firstname;

        }
        public ContactData(string firstname, string middlename, string lastname)
        {
            Firstname = firstname;
            Middlename = middlename;
            Lastname = lastname;
        }

        public string ACell
        {
            get
            {
                if (acell != null)
                {
                    return acell.Replace("\r", "").Replace("\n", "").Replace("Anniversary", "")
                    .Replace(" ", "").Replace("Birthday", "").Replace("M:", "").Replace("H:", "").Replace("P:", "")
                    .Replace("Homepage:", "").Replace("W:", "").Replace("F:", "").Replace(".","");
                }
                return Cell;
            }
            set { acell = value; }
        }
        public string Cell { get; set; }
        public string AllPhones
        {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                return CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work).Trim();

            }
            set { allPhones = value; }

        }
        public string Allinform
        {
            get
            {
                if (allinform != null)
                {
                    return allinform;
                }
                return Firstname + AMiddlename + ALastname  + ANickname  + ATitle + ACompany + AAddress+ AhomePhone + AmobilePhone+AworkPhone + Afax + Aemail1
                    +Aemail2+Aemail3+AhomePage+Abday+Abmonth+Abyear + Aaday + Aamonth + Aayear + Aaddress2+Aphone2+Anotes;

            }
            set { allinform = value; }

        }
        public string ALastname
        {
            get
            {
                if (aLastname != null)
                {
                    return aLastname;
                }
                return Lastname;
            }
            set { aLastname = value; }
        }
        public string AMiddlename
        {
            get
            {
                if (aMiddlename != null)
                {
                    return aMiddlename;
                }
                return Middlename;
            }
            set { aMiddlename = value; }
        }
        public string ANickname
        {
            get
            {
                if (aNickname != null)
                {
                    return aNickname;
                }
                return Nickname;
            }
            set { aNickname = value; }
        }
        public string AAddress
        {
            get
            {
                if (aAddress != null)
                {
                    return aAddress;
                }
                return Address;
            }
            set { aAddress = value; }
        }
        public string ATitle
        {
            get
            {
                if (aTitle != null)
                {
                    return aTitle;
                }
                return Title;
            }
            set { aTitle = value; }
        }
        public string ACompany
        {
            get
            {
                if (aCompany != null)
                {
                    return aCompany;
                }
                return Company;
            }
            set { aCompany = value; }
        }
        public string AhomePhone
        {
            get
            {
                if (ahomePhone != null)
                {
                    return ahomePhone;
                }
                return Home;
            }
            set { ahomePhone = value; }
        }
        public string AmobilePhone
        {
            get
            {
                if (amobilePhone != null)
                {
                    return amobilePhone;
                }
                return  Mobile;
            }
            set { amobilePhone = value; }
        }
        public string AworkPhone
        {
            get
            {
                if (aworkPhone != null)
                {
                    return  aworkPhone;
                }
                return  Work;
            }
            set { aworkPhone = value; }
        }
        public string Afax
        {
            get
            {
                if (afax != null)
                {
                    return afax;
                }
                return  fax;
            }
            set { afax = value; }
        }
        public string Aemail1
        {
            get
            {
                if (aemail1 != null)
                {
                    return aemail1;
                }
                return email1;
            }
            set { aemail1 = value; }
        }
        public string Aemail2
        {
            get
            {
                if (aemail2 != null)
                {
                    return aemail2;
                }
                return email2;
            }
            set { aemail2 = value; }
        }
        public string Aemail3
        {
            get
            {
                if (aemail3 != null)
                {
                    return aemail3;
                }
                return email3;
            }
            set { aemail3 = value; }
        }
        public string AhomePage
        {
            get
            {
                if (ahomePage != null)
                {
                    return ahomePage;
                }
                if (homepage == null) { return homepage; }
                return "Homepage:" + homepage;
            }
            set { ahomePage = value; }
        }
        public string Aaday
        {
            get
            {
                if (aaday != null)
                {
                    return aaday; 
                }
                return "Anniversary "+aday+ ". ";
            }
            set { aaday = value; }
        }
        public string Aamonth
        {
            get
            {
                if (aamonth != null)
                {
                    return aamonth;
                }
                return amonth;
            }
            set { aamonth = value; }
        }
        public string Aayear
        {
            get
            {
                if (aayear != null)
                {
                    if (ayear != null)
                    {
                        int b = 2017;
                        int a = Convert.ToInt32(aayear);
                        int c = b - a;
                        return aayear + "(" + c + ")";
                    }
                    return aayear;
                }
                return ayear;
            }
            set { aayear = value; }
        }
        public string Abday
        {
            get
            {
                if (abday != null)
                {
                    return abday;
                }
                return  bday;
            }
            set { abday = value; }
        }
        public string Abmonth
        {
            get
            {
                if (abmonth != null)
                {
                    return abmonth.Trim();
                }
                return bmonth;
            }
            set { abmonth = value; }
        }
        public string Abyear
        {
            get
            {
                if (abyear != null)
                {
                    if (byear != null)
                    {
                        int b = 2017;
                        int D = Convert.ToInt32(abyear);
                        int E = b - D;
                        return abyear + "(" + E + ")";
                    }
                    return abyear;
                }

                return byear;
            }
            set { abyear = value; }
        }
        public string Aaddress2
        {
            get
            {
                if (aaddress2 != null)
                {
                    return " " + aaddress2;
                }

                return  address2;
            }
            set { aaddress2 = value; }
        }
        public string Anotes
        {
            get
            {
                if (anotes != null)
                {
                    return anotes;
                }
                return notes;
            }
            set { anotes = value; }
        }
        public string Aphone2
        {
            get
            {
                if (aphone2 != null)
                {
                    return aphone2;
                }
                return  phone2;
            }
            set { aphone2 = value; }
        }
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
           return phone.Replace(" ", "").Replace("-","").Replace("(", "").Replace(")", "")+"\r\n";
        }


        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
        public string Address { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Fax
        {
            get
            {
                return fax;
            }
            set
            {
                fax = value;
            }
        }
        public string Email1
        {
            get
            {
                return email1;
            }
            set
            {
                email1 = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }
            set
            {
                bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }
        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }
        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }
        public string Ayear
        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }
            set
            {
                phone2 = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname + Lastname == other.Firstname + other.Lastname;
        }
        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }
        public override string ToString()
        {
            return Firstname + Lastname;
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 1)
            {
                return Firstname.CompareTo(other.Firstname);   
            }
            return   Lastname.CompareTo(other.Lastname);
        }

        [Column(Name = "firstname"), NotNull]
        public string Firstname { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "middlename")]
        public string Middlename { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Contacts select g).ToList();
            }
        }

    }
    }