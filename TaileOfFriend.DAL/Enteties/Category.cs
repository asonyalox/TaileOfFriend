using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
    public class Category:BaseEntity
    {
        
        public string Name { get; set; }

        public List<ProfileCategory> ProfileCategories { get; set; }

        public List<EventCategory> EventCategories { get; set; }
    }
}
