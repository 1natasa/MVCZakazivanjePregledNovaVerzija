using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVCZakazivanjePregleda.Models;
namespace MVCZakazivanjePregleda.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tblKorisnik model)
        {
            using (var context = new ZakazivanjePregledaEntities())
            {
                
                bool isValid = context.tblKorisniks.Any(x => x.korisnickoIme == model.korisnickoIme && x.sifraKorisnika == model.sifraKorisnika);
                if(isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.korisnickoIme, false);
                   
                    return RedirectToAction("Index", "Home");
                }
                
                ModelState.AddModelError("", "Korisnicko ime ili sifra nisu dobri");
                return View();
            }
            
            
        }
        public ActionResult Registration()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Registration(tblKorisnik model)
        {

            bool Status = false;
            string message = "";
            
            
            if (ModelState.IsValid)
            {
                var isExist = IsEmailExist(model.emailKorisnika);
                var isExistUsername = IsUsernameExist(model.korisnickoIme);
                if(isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email vec postoji");
                    return View(model);
                }

                if (isExistUsername)
                {
                    ModelState.AddModelError("UsernameExist", "Korisnicko ime vec postoji");
                    return View(model);
                }


                using (ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities())
                {
                    db.tblKorisniks.Add(model);
                    db.SaveChanges();
                    
                    Status = true;
                    message = "Uspesno ste se registrovali";
                   
                    
                }

            } else
            {
                message = "Nespesan zahtev!";
            }

            /*using (var contex = new ZakazivanjePregledaEntities())
            {
                contex.tblKorisniks.Add(model);
                contex.SaveChanges();
            }*/

            ViewBag.Message = message;
            ViewBag.Status = Status;
            //return RedirectToAction("Login");
            return View("SuccessfulLogin");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [NonAction]
        public bool IsEmailExist(string emailKorisnika)
        {
            using (ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities())
            {
                var v = db.tblKorisniks.Where(a => a.emailKorisnika == emailKorisnika).FirstOrDefault();
                return v != null;

            }
        }
        [NonAction]
        public bool IsUsernameExist(string username)
        {
            using (ZakazivanjePregledaEntities db = new ZakazivanjePregledaEntities())
            {
                var v = db.tblKorisniks.Where(a => a.korisnickoIme == username).FirstOrDefault();
                return v != null;
            }
        }
    }
}