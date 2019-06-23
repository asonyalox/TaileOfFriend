using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.DTO
{
    public class ProfileDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }

        public string ImageUrl { get; set;}
        public DateTime Birthday { get; set; }
        public Location Location { get; set; }
        public Gender Gender { get; set; }
    }
}
