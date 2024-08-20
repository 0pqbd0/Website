using System;
using FirstAspNetProject.BL.Auth;
using FirstAspNetProject.ViewMapper;
using FirstAspNetProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;


namespace FirstAspNetProject.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthBL authBl;
        public RegisterController(IAuthBL authBL) 
        {
            this.authBl = authBL;
        }

        [HttpGet]
        [Route("/register")]
        public IActionResult Index()
        {
            return View("Index", new RegisterViewModel());
        }

        [HttpPost]
        [Route("/register")]
        public IActionResult IndexSave(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                authBl.CreateUser(AuthMapper.MapRegisterViewModelToUserModel(model));
                return Redirect("/"); 
            }

            return View("Index", model);

        }
    }
}
