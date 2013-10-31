using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Twilio;

namespace MessageRobot.Tests.SMS
{
    [TestClass]
    public class Notice
    {
        [TestMethod]
        public void TestMessage()
        {
            var smsNumber = "+19492099893";
            var smsText = "3rd notice from the new reminder application.";
            string twilioPhoneNumber = "+17144595176";

            string AccountSid = "AC36241612702f6674342ac88458c378c8";
            string AuthToken = "5c81d4a1aec022545daf8da956a6b729";

            var twilio = new TwilioRestClient(AccountSid, AuthToken);
            var notice = twilio.SendSmsMessage(twilioPhoneNumber, smsNumber, smsText, "");
        }
    }
}
