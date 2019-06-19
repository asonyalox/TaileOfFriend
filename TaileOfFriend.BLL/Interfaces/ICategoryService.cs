using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.DAL.Enteties;


namespace TaileOfFriend.BLL.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetById(int id);

        Task<OperationDetails> CreateAsync(Category categoty);
        Task<OperationDetails> EditAsync(Category categoty);
        Task<OperationDetails> DeleteAsync(int id);
    }
}
