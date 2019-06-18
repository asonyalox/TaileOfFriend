using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.DTO
{
    public class EditeProfileDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public Location Location { get; set; }
        public DateTime Birthday { get; set; }
    }
}
