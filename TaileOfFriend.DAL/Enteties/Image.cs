using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaileOfFriend.DAL.Enteties
{
    public class Image
    {
        
        public int Id { get; set; }
        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }
    }
}
