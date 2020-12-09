using Enterwell_Faruk_Obradovic.Data;
using Enterwell_Faruk_Obradovic.DP.UserManagment.Interfaces;
using Enterwell_Faruk_Obradovic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.DP.UserManagment.Implementation
{
    public class UserDP : IUserDP
    {
        IHttpContextAccessor contextAccessor;
        ApplicationDbContext db;
        private readonly UserManager<Korisnik> userManager;
        private readonly SignInManager<Korisnik> loginManager;

        public UserDP(ApplicationDbContext db, UserManager<Korisnik> userManager,
            SignInManager<Korisnik> loginManager, IHttpContextAccessor contextAccessor)
        {
            this.db = db;
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.contextAccessor = contextAccessor;
        }

        public Korisnik FindUserByUsername(string username)
        {
            Korisnik user = (Korisnik)db.Users.SingleOrDefault(c => c.UserName == username);
            return user;
        }
        public Korisnik FindUserByEmail(string email)
        {
            Korisnik user = (Korisnik)db.Users.SingleOrDefault(c => c.Email == email);
            return user;
        }
        public bool CreateUser(Korisnik user, string pw)
        {
            IdentityResult result = userManager.CreateAsync(user, pw).Result;
            if (result.Succeeded == true)
            {
                db.SaveChanges();
            }
            return result.Succeeded;
        }

        public async Task<bool> SignIn(string userName, string pw)
        {
            var result = await loginManager.PasswordSignInAsync(userName, pw, false, true);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<Korisnik> getLoggedUser()
        {
            return await userManager.GetUserAsync(contextAccessor.HttpContext.User);
        }

    }
}
