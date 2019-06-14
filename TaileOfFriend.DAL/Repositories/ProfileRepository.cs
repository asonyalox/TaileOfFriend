using System;
using System.Collections.Generic;
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
    }
}
