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

        public OperationDetails AddCategory(string title)
        {
            Database.Categories.Insert(new Category() { Name = title });
            Database.SaveAsync();
            return new OperationDetails(true, "Ok", "");
        }

        public async Task<OperationDetails> EditAsync(Category category)
        {
            if (category.Id == 0)
            {
                return new OperationDetails(false, "Некоректне ID 0", "");
            }

            Category oldCategory = Database.Categories.GetById(category.Id);
            if (oldCategory == null)
            {
                return new OperationDetails(false, "Не знайдено", "");
            }

            oldCategory.Name = category.Name;

            await Database.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            Category category = Database.Categories.GetById(id);
            if (category == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            Database.Categories.Delete(category);
            await Database.SaveAsync();
            return new OperationDetails(true, "Не знайдено ", "");
        }
    }
}
