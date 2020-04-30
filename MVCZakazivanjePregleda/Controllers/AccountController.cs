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
            using (var contex = new ZakazivanjePregledaEntities())
            {
                contex.tblKorisniks.Add(model);
                contex.SaveChanges();
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}