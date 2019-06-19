using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
    public class EventImage:BaseEntity
    {
        

        public Event Event { get; set; }
        public Image Image { get; set; }
    }
}
