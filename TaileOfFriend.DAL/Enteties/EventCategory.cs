using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
    public class EventCategory:BaseEntity
    {
        

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
