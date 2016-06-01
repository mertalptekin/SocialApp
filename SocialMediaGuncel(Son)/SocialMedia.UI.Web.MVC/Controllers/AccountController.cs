using SocialMedia.BL.DataService;
using SocialMedia.Common.Services.Mail;
using SocialMedia.DAL.Models.Data.Entity;
using SocialMedia.DTO.Layer.Model;
using SocialMedia.UI.Web.MVC.Attribute;
using SocialMedia.UI.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialMedia.UI.Web.MVC.Controllers
{
    public class AccountController : BaseController
    {
        [AuthenticationControl]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return Redirect("/Account/Login");
        }

        private AppUserService appuserService;
        public AccountController()
        {
            appuserService = unitOfWork.AppUserService;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/Home/Index");
            }


            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword(string MailAdress)
        {

            MailAdress = MailAdress.Replace("\\", "");

            var isExist = appuserService.Any(x => x.Email == MailAdress);

            if (isExist)
            {
                ViewBag.Email = MailAdress;
                return View();
            }

            return Redirect("/Account/ForgetPassword/");
            
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = appuserService.FirstOrDefault(x => x.Email == model.Email);
                user.Password = model.Password;
                appuserService.Save();

                ViewBag.Message = "Parolanız resetlendi.";
            }
           

            return View();
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(string Email)
        {
            var isExist = appuserService.Any(x => x.Email == Email);

            if (isExist)
	        {
		         List<string> mailadress = new List<string>();
            mailadress.Add(Email);

           bool isSend = MailService.Send(new EmailDetail
            {
                From = "polengidainfo@gmail.com",
                To = mailadress,
                Body = "<p>Parolanızı değiştirmek için aşağıdaki linke tıklayınız</p><a href=" + Path.Combine("http://localhost:53647/Account/ChangePassword?MailAdress=", Email)+">Parolamı Değiştir</a>",
                Subject = "Parola Resetleme Maili"
            });

                if (isSend)
	            {
		            ViewBag.Message="E-Posta adresinize parola sıfırlama isteği gönderildi.";
                    return View();
	            }
                else{
                      ViewBag.Message="E-posta adresinize parola sıfırlama isteği gönderilemedi. Tekrar deneyiniz";
                    return View();
                }
                
                
	        }

           
            ViewBag.Message ="Sistemde böyle bir hesap mevcut değil.";
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                bool hasAccount = appuserService.Any(x => x.Email == model.Email && x.Password == model.Password);

                if (hasAccount)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return Redirect("/Home/Index");
                }
            }

            ViewBag.Message = "E-Posta veya şifre yanlış";

            return View();
        }


        public ActionResult Activate(string activationcode)
        {
            activationcode = activationcode.Replace("\\","");

            var user = appuserService.FirstOrDefault(x => x.ActivationCode == activationcode);
            user.IsActive = true;
            appuserService.Save();


            // RedirectToAction("Login","Account");
            return Redirect("/Account/Login");
        }

        [AllowAnonymous]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Register(AppUserDTO model)
        {

            if (ModelState.IsValid)
            {
                AppUser user = new AppUser();
                user.Email = model.Email;
                user.Password = model.Password;
                user.ActivationCode = Guid.NewGuid().ToString();
                user.UserName = model.UserName;

                appuserService.Insert(user);

                if (appuserService.Save() > 0)
                {

                    List<string> emailList = new List<string>();
                    emailList.Add(user.Email);

                    bool IsSend = MailService.Send(new EmailDetail
                     {
                         From = "polengidainfo@gmail.com",
                         To = emailList,
                         Body = "<p>Hesabınızı aktif etmek için aşağıdaki linke tıklayın</p><a href=" + Path.Combine("http://localhost:53647/Account/Activate?activationcode=",user.ActivationCode) +">Hesabımı Aktif Et</a>",

                         Subject = "Üyelik aktivasyon maili"
                     });

                    if (IsSend)
                    {
                        ViewBag.Message = "Kayıt Başarılı.Lütfen e-posta adresiniz kontrol ediniz";
                        ViewBag.IsSuccess = true;
                    }
                    else
                    {
                        ViewBag.Message = "E-Posta tarafınıza iletilemedi.Parolanızı resetlemek için reset parola tuşuna basınız";
                        ViewBag.IsSuccess = false;
                    }
                }
                else
                {
                    ViewBag.Message = "Bu kullanıcı hesabı sistemde mevcut";
                    ViewBag.IsSuccess = false;
                }

                return View();

            }

            return View();

        }
    }
}