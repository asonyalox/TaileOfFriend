using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace TaileOfFriend.DAL.Enteties
{
   public class Event:BaseEntity
    {
        
        public string Photos { get; set; }
        public string Category { get; set; }
        [DataType(DataType.Date)]
        public DateTime EventDates { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }

        public List<EventCategory> EventCategories { get; set; }

        
        public Location Location { get; set; }
    }
}
