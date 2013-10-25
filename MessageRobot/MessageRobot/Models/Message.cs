using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MessageRobot.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }
        public int ContactId { get; set; }
    }
}