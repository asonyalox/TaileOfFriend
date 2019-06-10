using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaileOfFriend.DAL.Enteties
{
   public class User: IdentityUser
    {
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Description { get; set; }

        public List<UserCategory> UserCategories { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}
