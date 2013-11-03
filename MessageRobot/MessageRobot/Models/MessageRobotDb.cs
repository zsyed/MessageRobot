using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MessageRobot.Models
{
    public class MessageRobotDb: DbContext
    {
        public MessageRobotDb()
            : base("DefaultConnection")
        {
        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}