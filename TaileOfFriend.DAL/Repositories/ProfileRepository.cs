using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;

namespace TaileOfFriend.DAL.Repositories
{
    public class ProfileRepository:Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(TaileOfFriendContext mainDbContext) : base(mainDbContext)
        {

        }

        public Profile GetById(string id)
        {
            return dbset.Find(id); 
        }

        public Profile GetProfileWithFields(string id)
        {
            return Entities.Where(p => p.UserId == id)
                .Include(p => p.User)
                .Include(p=>p.Image)
                .Include(p=>p.Location)
                .FirstOrDefault();
        }
    }
}
