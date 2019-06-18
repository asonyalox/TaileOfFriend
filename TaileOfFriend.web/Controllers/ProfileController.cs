using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.web.ViewModel;

namespace TaileOfFriend.web.Controllers
{
    public class ProfileController:Controller
    {
        private IProfileService _profileService;
        private IUserService _userService;

        public ProfileController(
            IProfileService profileSrv,
            IUserService userSrv
            )
        {
            _profileService = profileSrv;
            _userService = userSrv;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);

            var profile = _profileService.GetProfile(currentUser);

            var viewModel = new ProfileViewModel
            {
                ImageUrl = profile.ImageUrl,
                UserName = profile.UserName,
                Email = profile.Email,
                Age = DateTime.Today.Year - profile.Birthday.Year,
                Location =profile.Location,
                
            };

            return View(viewModel);
        }
    }
}
