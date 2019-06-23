using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Interfaces;

namespace TaileOfFriend.web.Controllers
{
    
        [Authorize(Roles = "Admin")]
        public class AdminController : Controller
        {
            public IUserService UserService { get; set; }
            public IProfileService ProfileService { get; set; }
            public ICategoryService categoryService { get; set; }

            public AdminController
            (IUserService _userService, 
             IProfileService _profileService,
             ICategoryService _categoryService )
            {
                UserService = _userService;
                ProfileService = _profileService;
            categoryService = _categoryService;
            }

            public IActionResult Index() => View();

            public IActionResult Users() => View(ProfileService.Users());

            public IActionResult Categories() => View(categoryService.GetAllCategories());

            [HttpPost]
             public IActionResult AddCategory(string title)
            {
                categoryService.AddCategory(title);
                return RedirectToAction("Categories", "Admin");
             }

        public IActionResult DeleteAsyc(int id)
        {
            categoryService.DeleteAsync(id);
            return RedirectToAction("Categories", "Admin");
        }
    }
    
}
