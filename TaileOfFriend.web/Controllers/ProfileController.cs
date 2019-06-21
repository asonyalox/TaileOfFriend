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
        private IProfileService profileService;
        private IUserService userService;
        private IFileService fileService;
        private IEventService eventService;
        private ICategoryService categoryService;
        

        public ProfileController(
            IProfileService _profileService,
            IUserService _userService,
            IFileService _fileService,
            ICategoryService _categoryService
            )
        {
            profileService = _profileService;
            userService = _userService;
            fileService = _fileService;
            categoryService = _categoryService;
        }

        

        
    }
}
