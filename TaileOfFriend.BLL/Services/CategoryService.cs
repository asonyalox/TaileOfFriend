using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;
using System.Linq;



namespace TaileOfFriend.BLL.Services
{
    public class CategoryService:ICategoryService
    {
       public  IUnitOfWork Database { get; set; }

       public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<Category> GetAllCategories() => Database.Categories.All();

        public Category GetById(int id) => Database.Categories.GetById(id);

        public async
    }
}
