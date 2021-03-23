using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using MVC.Data;
using MVC.Models;

namespace MVC.Controllers
{
    public class UsersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,UserName,Password,FirstName,LastName,Email,Role")] User user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Users.Add(user);

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(user);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string userName, string eMail, string password, User userModel)
        {
            if (db.Users.Where(x => x.Email == eMail).Any())
            {
                ViewBag.Mesaj = "Bu mail adresiyle daha önce kayıt yapıldı.";
                return View("Create");
            }
            else
            {
                var crypto = new SimpleCrypto.PBKDF2();
                var encrypedPassword = crypto.Compute(userModel.Password);

                var user = new User();

                int result = 0;

                if (userModel.Id == 0)
                {
                    user.UserName = userModel.UserName;
                    user.Password = encrypedPassword;
                    user.Salt = crypto.Salt;
                    user.UserCode1 = DateTime.Now.Millisecond.ToString();
                    user.UserCode2 = Guid.NewGuid().ToString();
                    user.UserConfirmed = "0";
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.Email = userModel.Email;
                    user.Role = userModel.Role;

                    db.Users.Add(user);
                    db.SaveChanges();
                    SendActivationEmail(user);
                    ViewBag.Mesaj = "Üye kaydı yapıldı. Mail kutunuza aktivasyon linki gönderdildi";

                }
                return View(user);
            }
        }

        private void SendActivationEmail(User user)
        {
            using (MailMessage mm = new MailMessage("erenkaraaa47@gmail.com", user.Email))
            {
                mm.Subject = "Hesap Aktivasyonu";
                string body = "Merhaba" + user.UserName + ",";
                body += "<br /><br />Hesabınızı etkinleştirmek için lütfen aşağıdaki bağlantıyı tıklayın";
                body += "<br /><a href = '" + string.Format("{0}://{1}/Users/Aktifet/{2}", Request.Url.Scheme, Request.Url.Authority, user.UserCode1 + user.UserCode2) + "'>Hesabınızı etkinleştirmek için burayı tıklayın.</a>";
                body += "<br /><br />Teşekkürler";
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

        public ActionResult AktifEt()
        {
            if (RouteData.Values["id"]!=null)
            {
                string kod = RouteData.Values["id"].ToString();
                DatabaseContext db = new DatabaseContext();
                User user = db.Users.Where(x => x.UserCode1 + x.UserCode2 == kod).FirstOrDefault();
                user.UserConfirmed = "1";
                db.SaveChanges();
                ViewBag.Bilgi = "Aktivasyon Başarılı";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user, string eMail, string password)
        {
            //var kullanici = db.Users.FirstOrDefault(x => x.Email == eMail && x.Password == password);
            if (user != null)
            {
                if (new LoginCheck().IsLoginSuccess(user))
                {
                    Session["UserName"] = user.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Mesaj = "Kullanıcı aktif edilmemiştir. Mailinize gönderilen aktivasyon linkini tıklayınız.";
                }
            }
            else
            {
                ViewBag.Mesaj = "Böyle bir kullanıcı yoktur.";
            }

            return View();
        }

        public ActionResult UserDashBoard()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,FirstName,LastName,Email,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
