using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.DAL.Interfaces
{
    public interface ILocationRepository:IRepository<Location>
    {
        Location FindClone(Location clone);
    }
}
