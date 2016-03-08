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

        public bool EnviarEmail(string nome, string email, string mensagem)
        {
            try
            {
                var usuarioDoSendGrid = System.Environment.GetEnvironmentVariable("SENDGRID_USER");
                var senhaDoSendGrid = System.Environment.GetEnvironmentVariable("SENDGRID_PASS");

                var credenciais = new NetworkCredential(usuarioDoSendGrid, senhaDoSendGrid);
                var transporteWeb = new Web(credenciais);
                var mensagemDoSendGrid = new SendGridMessage();

                mensagemDoSendGrid.From = new MailAddress(email);
                List<String> recipients = new List<String>
            {
                @"Andressa Feijoo <andressa.feijoo@hotmail.com>",
                @"Hannah Feijoo <hannahfeijoo@hotmail.com>",
                @"Juan Feijoo <juanfeijoo@ig.com.br>",
                @"Breno Sarkis <sarkisbreno@gmail.com>"
            };

                mensagemDoSendGrid.AddTo(recipients);
                mensagemDoSendGrid.Subject = "Zorb";
                mensagemDoSendGrid.Text = mensagem;
                transporteWeb.DeliverAsync(mensagemDoSendGrid);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}