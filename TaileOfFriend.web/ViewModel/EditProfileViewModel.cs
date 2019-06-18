using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaileOfFriend.web.ViewModel
{
    public class EditProfileViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Location { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
    }
}
