using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.web.ViewModel;

namespace TaileOfFriend.web.Controllers
{
    public class EventController:Controller
    {
        private IEventService eventService;
        private IProfileService profileService;
        private ICategoryService categoryService;
        private IMapper mapper;

        public EventController(
           IEventService _eventService,
           IProfileService _profileService,
           ICategoryService _categoryService,
           IMapper _mapper            )
        {
            eventService = _eventService;
            profileService = _profileService;
            categoryService = _categoryService;
            mapper = _mapper;
        }

        public IActionResult Index() => View();

        public IActionResult Events() => View("Events" , eventService.GetAllEvents());
        [Authorize]
        public IActionResult AddEvent()
        {
            EventViewModel eventModel = new EventViewModel
            {
                Categories = categoryService.Categories(),
                SelectedCategories = new List<string>()
            };
            return View(eventModel);
        }
              
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddEvent(EventViewModel model)
        {       
            

            await eventService.Create(model.EventName,model.Location,model.Description,model.EventDates,model.OwnerId);
            return RedirectToAction("Index", "Profile");
        }
        
        public IActionResult DeleteEvent(int event_id)
        {
            eventService.DeleteAsync(event_id);
            return RedirectToAction("Index", "Profile");
        }



    }
}
