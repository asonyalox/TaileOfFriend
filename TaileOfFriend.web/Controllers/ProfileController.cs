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
using AutoMapper;

namespace TaileOfFriend.web.Controllers
{
    public class ProfileController:Controller
    {
        private IProfileService profileService;
        private IUserService userService;
        private IFileService fileService;
        private IEventService eventService;
        private ICategoryService categoryService;
        private IMapper mapper;


        public ProfileController(
            IProfileService _profileService,
            IUserService _userService,
            IFileService _fileService,
            ICategoryService _categoryService,
            IEventService _eventService,
            IMapper _mapper
            )
        {
            profileService = _profileService;
            userService = _userService;
            fileService = _fileService;
            categoryService = _categoryService;
            eventService = _eventService;
            mapper = _mapper;
        }

        public async Task<IActionResult> Index()
        {
            User currentUser = await userService.GetCurrentUserAsync(HttpContext);
            var profile = profileService.GetProfile(currentUser);
            var viewModel = mapper.Map<ProfileDTO, ProfileViewModel>(profile);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ChangeImage()
        {
            User currentUser = await userService.GetCurrentUserAsync(HttpContext);
            ChangeImageViewModel model = new ChangeImageViewModel { UserId = currentUser.ProfileId };

            return RedirectToAction("Index", "Profile");
        }

        public async Task<IActionResult> Edit(string id)
        {
            User user = await profileService.FindById(id);
            if (user == null)
                return NotFound();
            EditProfileViewModel model = new EditProfileViewModel
            {
                Id = user.Id,
                Location=user.Profile.Location.Loc,
                UserName = user.UserName,
                Birthday = user.Profile.Birthday
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileViewModel model)
        {
            User currentUser = await userService.GetCurrentUserAsync(HttpContext);

            if (ModelState.IsValid && (model.Id == currentUser.Profile.UserId || User.IsInRole("Admin")))
            {
                ProfileDTO profile = mapper.Map<EditProfileViewModel, ProfileDTO>(model);

                var result = await profileService.ChangeProfileInfo(profile);

                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();

        }
    }
}
