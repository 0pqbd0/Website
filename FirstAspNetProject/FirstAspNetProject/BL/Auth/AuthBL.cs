﻿using System;
using FirstAppNetProject.BL.Auth;
using FirstAspNetProject.DAL;
using FirstAspNetProject.DAL.Models;
namespace FirstAspNetProject.BL.Auth
{
    public class AuthBL: IAuthBL
    {
        private readonly IAuthDAL authDal;
        private readonly IEncrypt encrypt;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AuthBL(IAuthDAL authDal, 
            IEncrypt encrypt,
            IHttpContextAccessor httpContextAccessor) 
        {
            this.authDal = authDal;
            this.encrypt = encrypt;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<int> CreateUser(UserModel user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.Password = encrypt.HashPassword(user.Password, user.Salt);
            int id = await authDal.CreateUser(user);
            Login(id);
            return id;
        }
         
        public void Login(int id)
        {
            httpContextAccessor.HttpContext?.Session.SetInt32(AuthConstants.AUTH_SESSION_PARAM_NAME, id);
        }
    }
}
