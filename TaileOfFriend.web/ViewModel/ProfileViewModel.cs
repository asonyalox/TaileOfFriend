using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.web.ViewModel
{
    public class ProfileViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public Gender Gender { get; set; }
        public string Image { get; set; }
        public int Age { get; set; }
        public Location Location { get; set; }
    }
}
