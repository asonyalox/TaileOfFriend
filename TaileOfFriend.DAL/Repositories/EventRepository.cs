using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TaileOfFriend.DAL.Repositories
{
    public class EventRepository: Repository<Event>, IEventRepository
    {
        public EventRepository(TaileOfFriendContext mainDbContext) : base(mainDbContext)
        {

        }

        public Event GetEventWithAllFileds(int id)
        {
            return Entities.Where(l => l.Id == id)
                .Include(l => l.Category)
                .Include(l=>l.Location)
                .Include(l=>l.Owner)
                .Include(l=>l.EventImage)
                .FirstOrDefault();
        }
    }
}
