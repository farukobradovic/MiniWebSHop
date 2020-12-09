using Enterwell_Faruk_Obradovic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterwell_Faruk_Obradovic.DP.UserManagment.Interfaces
{
    public interface IUserManagment
    {
        bool CreateUser(RegisterViewModel model);
        Task<bool> LoginUser(string email, string pw);
        Task<bool> SignOut();
    }
}
