using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
    public class Profile
    {
        [Key]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public Location Location { get; set; }
        public Image Image { get; set; }
        public string UserName { get; set; }

        public virtual List<ProfileCategory> ProfileCategories { get; set; }
        public Gender Gender { get; set; }
    }
}
