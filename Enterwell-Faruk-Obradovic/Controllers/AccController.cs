using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterwell_Faruk_Obradovic.DP.UserManagment.Interfaces;
using Enterwell_Faruk_Obradovic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Enterwell_Faruk_Obradovic.Controllers
{
    public class AccController : Controller
    {
        IUserDP userDP;
        IUserManagment userManagment;


        public AccController(IUserDP userDP, IUserManagment userManagment)
        {
            this.userDP = userDP;
            this.userManagment = userManagment;
        }

            
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        //Poslije registracije se potrebno posebno logovati
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (userManagment.CreateUser(model))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Greška pri kreiranju korisnika !");
                }
            }


            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(await userManagment.LoginUser(model.Email, model.PW))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Pokušajte ponovo !");
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            await userManagment.SignOut();
            return RedirectToAction("Index", "Home");
        }


    }
}