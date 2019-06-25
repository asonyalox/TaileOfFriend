using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.web.ViewModel
{
    public class EventViewModel
    {
        [Required]
        public string EventName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EventDates { get; set; }

        public IFormFile formFile { get; set; }

        public List<string> SelectedCategories { get; set; }
        public List<Category> Categories { get; set; }

        public string OwnerId { get; set; }

        public string Description { get; set; }
    }
}