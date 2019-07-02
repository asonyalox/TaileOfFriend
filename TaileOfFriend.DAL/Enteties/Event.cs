using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TaileOfFriend.DAL.Enteties
{
   public class Event:BaseEntity
    {
        public string EventName { get; set; }
        
        public string Category { get; set; }
        [DataType(DataType.Date)]
        public DateTime EventDates { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        
        public  List<EventCategory> EventCategories { get; set; }

        public virtual Location Location { get; set; }

        public virtual User Owner { get; set; }
       // [Url]
       // public string ImageUrl { get; set; }

        
    }
}
