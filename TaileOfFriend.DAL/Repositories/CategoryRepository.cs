using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace TaileOfFriend.DAL.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(TaileOfFriendContext mainDbContext) : base(mainDbContext)
        {

        }

        public  override IEnumerable<Category> GetAll()
        {
            return context.Categories;
        }

    } 
}
