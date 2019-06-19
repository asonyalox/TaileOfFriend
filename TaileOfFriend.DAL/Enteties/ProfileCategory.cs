using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
    public class ProfileCategory:BaseEntity
    {
       


        public string ProfileId { get; set; }
        public Profile Profile{ get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
