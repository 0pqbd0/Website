﻿using System;
using FirstAspNetProject.DAL.Models;

namespace FirstAspNetProject.DAL;

public interface IAuthDAL
{
    Task<UserModel> GetUser(string email);
    Task<UserModel> GetUser(int id);
    Task<int> CreateUser(UserModel model);
}
