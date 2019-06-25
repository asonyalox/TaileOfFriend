using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using System.Linq;

namespace TaileOfFriend.DAL.Repositories
{
    public class LocationRepository: Repository<Location>, ILocationRepository
    {
        public LocationRepository(TaileOfFriendContext mainDbContext) : base(mainDbContext)
        {

        }

        public Location FindClone(Location clone)
        {
            return dbset.FirstOrDefault(x => x.Loc == clone.Loc);
        }
    }
}
