using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

using MVC.Models;

namespace MVC.Controllers
{
    public class SifreHatirlatController : Controller
    {
        // GET: SifreHatirlat
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string eMail)
        {
            DatabaseContext db = new DatabaseContext();
            User user = new User();
            var durum = db.Users.Where(x => x.Email == eMail).FirstOrDefault();

            if (durum != null)
            {
                user.UserName = durum.UserName;
                user.UserCode1 = durum.Password;
                user.UserCode1 = durum.UserCode1;
                user.UserCode2 = durum.UserCode2;
                user.Email = durum.Email;
                user.FirstName = durum.FirstName;
                user.LastName = durum.LastName;
                user.Role = durum.Role;
                SendActivationEmail(user);
                ViewBag.Mesaj = "Sıfırlama linki mail adresinize gönderildi";
                return View(user);
            }
            else
            {
                ViewBag.Mesaj = "Bu mail ile üyemiz yoktur";
            }
            return View();
        }

        private void SendActivationEmail(User user)
        {
            using (MailMessage mm = new MailMessage("erenkaraaa47@gmail.com", user.Email))
            {
                mm.Subject = "Şifre sıfırlama";
                string body = "Merhaba " + user.UserName + ",";
                body += "<br /><br /><h1>Hesabınıza ait parolanızı sıfırlamak için lütfen aşağıdaki bağlantıyı tıklayın</h1>";
                body += "<br /><a href = '" + string.Format("{0}://{1}/SifreHatirlat/Sifirla/{2}", Request.Url.Scheme, Request.Url.Authority, user.UserCode1 + user.UserCode2) + "'>Parolayı sıfırlamak için burayı tıklayın.</a>";
                body += "<br /><br />Teşekkürler...";
                mm.Body = body;
                mm.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("erenkaraaa47@gmail.com", "60856048748");
                    smtp.EnableSsl = true;
                    smtp.Send(mm);
                }
            }
        }

        public ActionResult Sifirla()
        {
            if (RouteData.Values["id"] != null)
            {
                string kod = RouteData.Values["id"].ToString();
                DatabaseContext db = new DatabaseContext();
                User user = db.Users.Where(x => x.UserCode1 + x.UserCode2 == kod).FirstOrDefault();
                Session["user"] = user.Id.ToString();
                user.Password = "";
                db.SaveChanges();
                ViewBag.Bilgi = "Parolanız Sıfırlandı.";
                ViewBag.Mail = user.Email;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YeniParola(string password)
        {
            int userId = Convert.ToInt32(Session["user"]);
            DatabaseContext db = new DatabaseContext();
            User user = db.Users.Where(x => x.Id == userId).FirstOrDefault();
            user.Password = password;
            db.SaveChanges();
            Session["Mesaj"] = "Şifreniz yenilendi";
            return RedirectToAction("Sifirla", "SifraHatirlat");
        }
    }
}