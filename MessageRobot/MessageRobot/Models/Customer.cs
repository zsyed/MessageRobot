using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageRobot.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Subscribe { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}