using Enterwell_Faruk_Obradovic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.DP.UserManagment.Interfaces
{
    public interface IUserDP
    {
        Korisnik FindUserByUsername(string username);
        Korisnik FindUserByEmail(string email);
        bool CreateUser(Korisnik user, string pw);
        Task<bool> SignIn(string userName, string pw);
        Task<Korisnik> getLoggedUser();
    }
}
