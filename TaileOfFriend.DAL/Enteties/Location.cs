﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
   public class Location
    {
        public int Id { get; set; }
        public string Loc { get; set; }

        public ICollection<Event> Events { get; set; }
        public ICollection<User> Users { get; set; }
     }
}
