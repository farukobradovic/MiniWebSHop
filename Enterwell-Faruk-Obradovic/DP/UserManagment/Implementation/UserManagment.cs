using Enterwell_Faruk_Obradovic.Data;
using Enterwell_Faruk_Obradovic.DP.UserManagment.Interfaces;
using Enterwell_Faruk_Obradovic.Models;
using Enterwell_Faruk_Obradovic.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.DP.UserManagment.Implementation
{

    public class UserManagment : IUserManagment
    {
        private IUserDP userDP;
        private readonly SignInManager<Korisnik> loginManager;
        public UserManagment(IUserDP userDP, SignInManager<Korisnik>loginManager)
        {
            this.userDP = userDP;
            this.loginManager = loginManager;
        }


        public bool CreateUser(RegisterViewModel model)
        {
            var user = new Korisnik
            {
                UserName = model.UserName,
                Ime = model.Ime,
                Prezime = model.Prezime,
                Grad = model.Grad,
                Adresa = model.Adresa,
                PhoneNumber = model.BrojTelefona,
                Email = model.Email
            };

            var boolUser = userDP.CreateUser(user, model.PW);
            return boolUser;

        }
       
        public async Task<bool> LoginUser(string email, string pw)
        {
            var user = userDP.FindUserByEmail(email);
            if (user != null)
            {
                return await userDP.SignIn(user.UserName, pw);

            }
            return false;
        }
        
        public async Task<bool> SignOut()
        {
            await loginManager.SignOutAsync();
            return true;
        }

    }
}
