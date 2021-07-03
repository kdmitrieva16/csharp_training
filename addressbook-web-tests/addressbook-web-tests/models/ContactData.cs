using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressBookTests
{
    [Table(Name="addressbook")]
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData()
        {
        }
        public ContactData(string firstname)
        {
            FirstName = firstname;
        }
        [Column(Name="firstname")]

        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }
        public string AllPhones
        {
            get
            {
            if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone=="")
            {
                return "";
            }
            return Regex.Replace(phone, "[-()]", "") + "\r\n";
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (Email + Email2 + Email3).Trim();
                }
            }
            set
            {
                allEmails = value;
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
            if (FirstName == other.FirstName)
            {
                if (LastName == other.LastName)
               {
                    return true;
                }     
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (FirstName+LastName).GetHashCode();
        }

        public override string ToString()
        {
            return "firstname:" + FirstName + ", lastname:" + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return FirstName.CompareTo(other.FirstName);
        }

        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db=new AddressBookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
            
        }

    }
}

