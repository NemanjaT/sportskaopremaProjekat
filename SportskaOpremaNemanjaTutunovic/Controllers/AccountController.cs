using SportskaOpremaNemanjaTutunovic.Models;
using SportskaOpremaNemanjaTutunovic.Models.EFRepository;
using SportskaOpremaNemanjaTutunovic.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SportskaOpremaNemanjaTutunovic.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        private IAuthRepository authRepository = new AuthRepository();

    

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserBO user)
        {
            if (authRepository.isValid(user))
            {
                
                FormsAuthentication.SetAuthCookie(user.Username, false);
                if (authRepository.GetRoleForUser(user.Username) == "admin")
                {
                    
                    return RedirectToAction("Index", "Artikal");
                }
                return RedirectToAction("IndexKorisnik", "Artikal");
            }
            ModelState.AddModelError("", "Niste uneli isparavan username ili password!");
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(UserBO user)
        {
            if (authRepository.postojiUsername(user.Username) == true)
            {
                ModelState.AddModelError("Username", "Korisnik sa korisničkim imenom: " + user.Username + " već postoji");
                System.Diagnostics.Debug.WriteLine("Dodat modelErr, id=" + user.Username);
            }
            if (ModelState.IsValid)
            {
                authRepository.addUser(user);
                return RedirectToAction("Login");
            }
            else
            {
                return View();
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}