using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MessageRobot.Models
{
    public class Notice
    {
        public int Id { get; set; }
        public string NoticeDay { get; set; }
        public string NoticeTime { get; set; }
        public string NoticeText { get; set; }
        public string NoticeType { get; set; }
        public string TimeZone { get; set; }
        public int ContactId { get; set; }
    }
}