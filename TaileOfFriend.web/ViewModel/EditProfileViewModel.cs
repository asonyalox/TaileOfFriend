using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.web.ViewModel
{
    public class EditProfileViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public Location Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
