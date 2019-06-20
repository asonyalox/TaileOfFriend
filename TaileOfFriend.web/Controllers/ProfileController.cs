using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.web.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using TaileOfFriend.BLL.DTO;

namespace TaileOfFriend.web.Controllers
{
    public class ProfileController:Controller
    {
        private IProfileService _profileService;
        private IUserService _userService;
        private IFileService _fileService;
        

        public ProfileController(
            IProfileService profileSrv,
            IUserService userSrv,
            IFileService fileSrv
            )
        {
            _profileService = profileSrv;
            _userService = userSrv;
            _fileService = fileSrv;
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
