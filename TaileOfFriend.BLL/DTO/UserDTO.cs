using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.DTO
{
   public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public Image Avatar { get; set; }
        public Location Location { get; set; }

    }
}
