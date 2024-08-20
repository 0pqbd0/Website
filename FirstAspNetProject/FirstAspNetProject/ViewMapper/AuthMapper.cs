using System;
using FirstAspNetProject.ViewModels;
using FirstAspNetProject.DAL.Models;
namespace FirstAspNetProject.ViewMapper
{
    public class AuthMapper
    {
        public static UserModel MapRegisterViewModelToUserModel(RegisterViewModel model)
        {
            return new UserModel
            {
                Email = model.Email!,
                Password = model.Password!
            };
        }
    }
}
