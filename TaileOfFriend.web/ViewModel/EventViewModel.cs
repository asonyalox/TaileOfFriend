using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.web.ViewModel
{
    public class EventViewModel
    {
        public Event Event { get; set; }
        public Image Image { get; set; }
        public Profile Owner { get; set; }
        public string EventImage { get; set; }

        public List<Category> Categories { get; set; }
    }
}
