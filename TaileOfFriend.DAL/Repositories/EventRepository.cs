using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Interfaces;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.DAL.Repositories
{
    public class EventRepository: Repository<Event>, IEventRepository
    {
        public EventRepository(TaileOfFriendContext mainDbContext) : base(mainDbContext)
        {

        }
    }
}
