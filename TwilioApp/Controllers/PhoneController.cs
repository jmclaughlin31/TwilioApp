using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.AspNet.Mvc;


namespace TwilioApp.Controllers
{
    public class PhoneController : TwilioController
    {
        public ActionResult MakeCall()
        {

            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(ConfigurationManager.AppSettings["MyPhoneNumber"]);

            var from = new PhoneNumber("+353768888128");

            var call = CallResource.Create(

                to: to, from: from,
                url: new Uri("http://demo.twilio.com/docs/voice.xml"));

            return Content(call.Sid);

        }
    }
}