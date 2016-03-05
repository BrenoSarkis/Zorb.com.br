using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Zorb.com.br.Controllers
{
    public class ZorbController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }

        public string EnviarEmail(string nome, string email, string mensagem)
        {
            var username = System.Environment.GetEnvironmentVariable("SENDGRID_USER");
            var pswd = System.Environment.GetEnvironmentVariable("SENDGRID_PASS");

            //var username = "azure_2766a2fb7a4faafa71e5e711d4aacfa7@azure.com";
            //var pswd = "8nHqhlR7528bTOZ";

            var credentials = new NetworkCredential(username, pswd);
            // Create an Web transport for sending email.
            var transportWeb = new Web(credentials);
            var myMessage = new SendGridMessage();

            // Add the message properties.
            myMessage.From = new MailAddress(email);

            // Add multiple addresses to the To field.
            List<String> recipients = new List<String>
            {
                @"Andressa Feijoo <andressa.feijoo@hotmail.com>",
                @"Hannah Feijoo <hannahfeijoo@hotmail.com>",
                @"Juan Feijoo <juanfeijoo@ig.com.br>",
                @"Breno Sarkis <sarkisbreno@gmail.com>"
            };

            myMessage.AddTo(recipients);

            myMessage.Subject = "Alguém entrou em contato pelo site!";

            //Add the HTML and Text bodies
            //myMessage.Html = mensagem;
            myMessage.Text = mensagem;
            transportWeb.DeliverAsync(myMessage);
            return "";
        }
    }
}