using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData: IEquatable<ContactData>, IComparable<ContactData>
    {
       

        public ContactData(string firstname)
        {
            FirstName = firstname;
        }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string Id { get; set; } 

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

    }
}

