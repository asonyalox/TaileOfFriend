using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaileOfFriend.web.ViewModel
{
    public class ChangeImageViewModel
    {
        public string UserId { get; set; }
        public IFormFile Image { get; set; }
    }
}
