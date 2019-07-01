using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.DTO
{
    public class EventDTO
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDates { get; set; }
        public virtual Location Location { get; set; }
        public string OwnerId { get; set; }
        public string Description { get; set; }
        public List<string> Categories { get; set; }
        public string ImageUrl { get; set; }
    }
}
