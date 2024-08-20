using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
namespace FirstAspNetProject.BL.Auth
{
    public interface IAuthBL
    {
        Task<int> CreateUser(FirstAspNetProject.DAL.Models.UserModel user);
    }
}
