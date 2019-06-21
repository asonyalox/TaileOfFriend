using System;
using System.Collections.Generic;

using System.Text;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;


namespace TaileOfFriend.DAL.Repositories
{
    public class ImageRepository:Repository<Image>,IImageRepository
    {
        public ImageRepository(TaileOfFriendContext mainDbContext) : base(mainDbContext)
        {

        }

        
    }
}
