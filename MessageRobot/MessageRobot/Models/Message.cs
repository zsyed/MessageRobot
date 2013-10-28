using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageRobot.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string MessageDay { get; set; }
        public string MessageTime { get; set; }
        public string MessageText { get; set; }
        public string MessageType { get; set; }
        public int ContactId { get; set; }
    }
}