using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TaileOfFriend.DAL.Enteties
{
    public enum Gender
    {
        Male,
        Female,
        Other,
    }
   public class User: IdentityUser
    {
        public string ProfileId { get; set; }
        public Profile Profile { get; set; }
        
    }
}
