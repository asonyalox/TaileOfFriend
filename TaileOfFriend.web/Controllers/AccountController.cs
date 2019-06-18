using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.web.ViewModel;

namespace TaileOfFriend.web.Controllers
{
    public class AccountController:Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            await AdminSeedAsync();

            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    
                };
                bool auth = await _userService.AuthenticateAsync(userDto);
                if (auth)
                {
                    return RedirectToAction("Index", "Profile");
                }
            }
            ModelState.AddModelError("", "Емейл чи пароль невірний");
            return View(model);
        }

        public IActionResult Register() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = "user",
                    Gender=model.Gender,
                    Birthday=model.Birthday,
                };

                OperationDetails operationDetails = await _userService.CreateAsync(userDto);
                
                if (operationDetails.Succedeed)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
             }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
        private async Task AdminSeedAsync()
        {
            await _userService.AdminSeedAsync(new UserDTO
            {
                Email = "admin@gmail.com",
                UserName = "SuperAdmin",
                Password = "Proton1!",
                Role = "admin",
            });
        }
    }
}
