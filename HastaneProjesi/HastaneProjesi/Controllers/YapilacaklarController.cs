using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HastaneProjesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HastaneProjesi.Controllers
{
    [Authorize]
    public class YapilacaklarController : Controller
    {
       
       
            private readonly SignInManager<AppUser> _signInManager;
            private readonly UserManager<AppUser> _userManager;
            public YapilacaklarController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
            {
                _signInManager = signInManager;
                _userManager = userManager;
            }
            public async Task<IActionResult> Index()
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                return View(user);
            }

           
        }
}
