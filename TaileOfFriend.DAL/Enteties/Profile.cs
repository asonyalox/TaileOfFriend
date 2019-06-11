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
        public string Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public Location Location { get; set; }
        public Image Image { get; set; }

        public virtual User User { get; set; }

    }
}
