using DAL.Context;
using DAL.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Panel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;


namespace Web.Controllers
{

    public class AuthController : Controller
    {
        private readonly TaskManagerContext _context;
        public AuthController(TaskManagerContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();// trigger Dataseeding


        }


        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.RedirectUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string RedirectUrl)
        {

          
            var appuser = await _context.AppUsers.FirstOrDefaultAsync(c => c.UserName == username);
            if (appuser != null)
            {
                await AddAuthAsync(appuser);
             
                return RedirectTolocal(RedirectUrl);

            }
            ViewBag.msg = "نام کاربری یا رمز عبور اشتباه است";
            ViewBag.RedirectUrl = RedirectUrl;
            return View();


        
        
        }

        private async Task AddAuthAsync(AppUser appUser)
        {
            var claimes = new List<Claim>();
            claimes.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claimes.Add(new Claim(ClaimTypes.Role, appUser.Rols.ToString()));




            var ClaimIdentity = new ClaimsIdentity(claimes,
               CookieAuthenticationDefaults.AuthenticationScheme);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.Now.AddDays(15),

                AllowRefresh = true
            };
            await HttpContext.SignInAsync(
                   CookieAuthenticationDefaults.AuthenticationScheme,
                   new ClaimsPrincipal(ClaimIdentity),
                   properties
                  );
        }

        private IActionResult RedirectTolocal(string returnUrl)
        {

            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);

            }

            return RedirectToAction("GetTasks", "Home");
        }



        public IActionResult Denied(string ReturnUrl)
        {

            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete(Const.CookieName);
            return RedirectToAction(nameof(Login));

        }
    }
}
