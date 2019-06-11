using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
    public class EventImage
    {
        public int Id { get; set; }

        public Event Event { get; set; }
        public Image Image { get; set; }
    }
}
