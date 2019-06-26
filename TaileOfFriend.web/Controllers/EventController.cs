using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.web.ViewModel;

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

        public IActionResult Events() => View(eventService.Events());

        public IActionResult AddEvent()
        {
            EventViewModel eventModel = new EventViewModel
            {
                Categories = categoryService.Categories(),
                SelectedCategories = new List<string>()
            };
            return View(eventModel);
        }

       /* [HttpPost]
        public async Task<IActionResult> AddEvent(EventViewModel model)
        {
            
            ProfileDTO ProfileDTO = profileService.GetProfile(User.Identity.Name);
        }*/

        public IActionResult DeleteEvent(int event_id)
        {
            eventService.DeleteAsync(event_id);
            return RedirectToAction("Index", "Profile");
        }



    }
}
