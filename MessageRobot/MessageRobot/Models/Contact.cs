using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageRobot.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        public string LoginName { get; set; }
        public string Subscribe { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Notice> Notices { get; set; }
    }
}