using System;
using System.Configuration;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Guestbook.Models;

namespace Guestbook.ModelBinders
{
    public class MsgBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var jsonStr = actionContext.Request.Content.ReadAsStringAsync().Result;
            var msgObj = Json.Decode(jsonStr);

            bindingContext.Model = new Msg
            {
                UserName = msgObj.UserName,
                Email = msgObj.Email,
                HomePage = msgObj.HomePage,
                Text = msgObj.Text,
                Date = DateTime.Now
            };

            var captchaValidtor = new Recaptcha.RecaptchaValidator
            {
                PrivateKey = ConfigurationManager.AppSettings["ReCaptchaPrivateKey"],
                RemoteIP = ((System.Web.HttpContextWrapper)actionContext.Request.Properties["MS_HttpContext"]).Request.UserHostAddress,
                Challenge = msgObj.recaptcha_challenge_field,
                Response = msgObj.recaptcha_response_field
            };

            var recaptchaResponse = captchaValidtor.Validate();
            if (!recaptchaResponse.IsValid)
            {
                actionContext.ModelState.AddModelError("recaptcha_response_field", "Символы не соответствуют изображению.");
            }
            return true;
        }
    }
}