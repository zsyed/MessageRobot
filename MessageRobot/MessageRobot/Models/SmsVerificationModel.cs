using System.ComponentModel.DataAnnotations;

namespace MessageRobot.Models
{
    public class SmsVerificationModel
    {
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name = "SMS Verification Code")]
        public string SmsVerificationCode { get; set; }
    }
}