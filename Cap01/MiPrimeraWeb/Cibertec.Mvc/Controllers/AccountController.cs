using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Cibertec.Models;
using Cibertec.Mvc.Models;
using Cibertec.UnitOfWork;
using log4net;

namespace Cibertec.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IUnitOfWork IUnitOfWork, ILog log) : base(IUnitOfWork, log)
        {
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            return View(new UserViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(UserViewModel user)
        {
            if (!ModelState.IsValid) return View(user);
            var validUser = _unitOfWork.Users.VAlidateUer(user.Email, user.Password);
            if (validUser == null)
            {
                ModelState.AddModelError("", "Invalid email or password");
                return View(user);
            }
            var identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Email, validUser.Email),
                new Claim(ClaimTypes.Name,$"{validUser.FirstName} {validUser.LastName}"),
                new Claim(ClaimTypes.NameIdentifier, validUser.Email)

            }, "ApplicationCookie");

            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignIn(identity);
            return RediretLocal(user.ReturnUrl);

        }

        public ActionResult Logout()
        {
            var context = Request.GetOwinContext();
            var authManager = context.Authentication;
            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(RegisterUserViewModel userView)
        {
            if (!ModelState.IsValid) return View(userView);
            User user = new User()
            {
                Email = userView.Email,
                FirstName = userView.FirstName,
                LastName = userView.LastName,
                Password = userView.Password
            };

            var validUser = _unitOfWork.Users.CreateUser(user);
            if (validUser == null)
            {
                ModelState.AddModelError("", "No se pudo crear el usuario");
                return View(user);
            }

            return RedirectToAction("Login","Account");
        }

        private ActionResult RediretLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}