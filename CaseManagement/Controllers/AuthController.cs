using CaseManagement.Models;
using CaseManagement.Models.Applicant;

using CaseManagementData;
using CaseManagementData.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CaseManagement.Controllers
{
    public class AuthController : Controller
    {
        private readonly CaseManagementContext _context;

        public AuthController(CaseManagementContext context)
        {
            _context = context;
        }

    
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return GoToReturnUrl("");
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string returnUrl, string username, string password)
        {
            var user = _context.Users.SingleOrDefault(m => m.Email == username);
          
            if(user != null)
            {
                if (password == user.Password)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, Convert.ToString(user.Id), ClaimValueTypes.Integer, ""),
                    new Claim(ClaimTypes.Name, Convert.ToString(user.FirstName), ClaimValueTypes.String, "")

                };
                    var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);
                    

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        userPrincipal,
                        new AuthenticationProperties
                        {
                            ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                            IsPersistent = false,
                            AllowRefresh = false
                        });

                    return GoToReturnUrl(returnUrl);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        private IActionResult GoToReturnUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Welcome()
        {
            return View();
        }

        public IActionResult Denied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Index));
           
        }
    }
}
