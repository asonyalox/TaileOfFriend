using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Interfaces;

namespace TaileOfFriend.web.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        public class AdminController : Controller
        {
            public IUserService UserService { get; set; }
            public IProfileService ProfileService { get; set; }

            public AdminController(IUserService userSrv, IProfileService profileSrv)
            {
                UserService = userSrv;
                ProfileService = profileSrv;
            }

            public IActionResult Index() => View();

            public IActionResult Users() => View(ProfileService.Users());
        }
    }
}
