using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<ProfileCategory> ProfileCategories { get; set; }

        public List<EventCategory> EventCategories { get; set; }
    }
}
