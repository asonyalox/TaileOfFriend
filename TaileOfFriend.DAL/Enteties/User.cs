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

        
        public Profile Profile { get; set; }
        public List<UserCategory> UserCategories { get; set; }
    }
}
