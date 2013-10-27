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
        public string Day { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Time { get; set; }

        public int ContactId { get; set; }
    }
}