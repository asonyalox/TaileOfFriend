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
            ChangeImageViewModel model = new ChangeImageViewModel { UserId = currentUser.Id };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeImage(ChangeImageViewModel model)
        {
            User currentUser = await userService.GetCurrentUserAsync(HttpContext);

            if (ModelState.IsValid && (model.UserId == currentUser.Id || User.IsInRole("Admin")))
            {
                var newImage = await fileService.AddImage(model.Image);
                var result = await profileService.ChangeImage(model.UserId, newImage);
                if (result.Succedeed)
                {
                   
                    return RedirectToAction("Index");
                }
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return View(profileService.Users());
        }

        [HttpGet]
        public IActionResult GetById(string id)
        {
            var profile = profileService.GetById(id);
            if (profile != null)
            {
                var viewModel = mapper.Map<ProfileDTO, ProfileViewModel>(profile);
                return View(viewModel);
            }
            return BadRequest();
        }

        public async Task<IActionResult> Edit()
        {
            User currentUser = await userService.GetCurrentUserAsync(HttpContext);
            EditProfileViewModel model = new EditProfileViewModel { UserId = currentUser.Id };

            return View(model);



        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditProfileViewModel model)
        {
            User currentUser = await userService.GetCurrentUserAsync(HttpContext);

            if (ModelState.IsValid && (model.UserId == currentUser.Id || User.IsInRole("Admin")))
            {
                ProfileDTO profile = mapper.Map<EditProfileViewModel, ProfileDTO>(model);

                var result = await profileService.ChangeProfileInfo(profile);

                if (result.Succedeed)
                {
                    return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {

            await userService.Delete(id);
            return RedirectToAction("Users", "Admin");

        }

    }
}
