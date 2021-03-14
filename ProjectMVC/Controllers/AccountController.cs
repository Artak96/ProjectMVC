using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectMVC.BLL;
using ProjectMVC.Core.Interfaces;
using ProjectMVC.Data.Models;
using ProjectMVC.Data.Repositoryes;
using ProjectMVC.Models.ViewModels;

namespace ProjectMVC.Controllers
{
    public class AccountController : Controller
    {
        IRepository<User> _userRepository;
        public AccountController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _userRepository.List().Where(u => u.Email == model.Email).FirstOrDefault();
            if (user is null)
            {
                return RedirectToAction("Login");
            }
            else if (user.Password == model.Password)
            {
                return RedirectToAction("Index");
            }
            else
                return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Registration() => View();

        [HttpPost]
        public IActionResult Registration(RegistrationViewModel registrationViewModel)
        {
            AccountBL accountBL = new AccountBL((UserRepository)this._userRepository);
            if (accountBL.Registration(registrationViewModel))
            {
                return RedirectToAction("Login", new LoginViewModel
                {
                    Email = registrationViewModel.Email,
                    Password = registrationViewModel.Password
                });
            }
            else
            {
                return RedirectToAction("Registration");
            }
        }
    }
}