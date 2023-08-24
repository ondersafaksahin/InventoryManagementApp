using InventoryManagementApp.Application.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementApp.Application.Services.AppUserService
{
    public interface IAppUserService
    {
        Task<SignInResult> Login(LoginDTO user);
        Task LogOut();
    }
}
