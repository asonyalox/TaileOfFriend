using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.BLL.DTO
{
    public class ProfileDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string ImageUrl { get; set;}
        public DateTime Birthday { get; set; }
        public string Location { get; set; }
    }
}
