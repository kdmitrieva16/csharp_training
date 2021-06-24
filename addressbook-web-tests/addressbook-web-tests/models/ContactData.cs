using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string lastname="";

        public ContactData(string firstname)
        {
            this.firstname = firstname;
        }

        public string FirstName
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
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
            if (firstname.CompareTo(other.firstname) == 0)
            {
                return LastName.CompareTo(other.LastName);
            }
            return firstname.CompareTo(other.firstname);
        }

    }
}

