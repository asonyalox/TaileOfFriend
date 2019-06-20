using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.Interfaces
{
    public interface ILocationService
    {
         IEnumerable<Location> GetAllLocations();
        Location GetById(int id);

        Task<OperationDetails> CreateAsync(Location location);
        
        Task<OperationDetails> DeleteAsync(int id);
    }
}
