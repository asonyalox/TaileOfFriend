using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Interfaces;

namespace TaileOfFriend.web.Controllers
{
    public class EventController:Controller
    {
        private IEventService eventService;
        private IProfileService profileService;
        private ICategoryService categoryService;

        public EventController(
           IEventService _eventService,
           IProfileService _profileService,
           ICategoryService _categoryService)
        {
            eventService = _eventService;
            profileService = _profileService;
            categoryService = _categoryService;
        }

        public IActionResult Index() => View();

        public IActionResult ListEvent() => PartialView("ListEvent");

    }
}
