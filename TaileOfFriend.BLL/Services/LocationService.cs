using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Interfaces;
using System.Linq;
using TaileOfFriend.DAL.Enteties;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.BLL.Interfaces;

namespace TaileOfFriend.BLL.Services
{
    public class LocationService:ILocationService
    {
        public IUnitOfWork Database { get; set; }

        public LocationService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<Location> GetAllLocations() => Database.Locations.All();

        public Location GetById(int id) => Database.Locations.GetById(id);

        public async Task<OperationDetails> CreateAsync(Location location)
        {
            if (location.Loc == null)
            {
                return new OperationDetails(false, "Назва не може бути пустою", "");
            }

            if (Database.Locations.All().Any(c => c.Loc == location.Loc))
            {
                return new OperationDetails(false, "Дана локація вже існує", "");
            }

            Database.Locations.Insert(location);
            await Database.SaveAsync();

            return new OperationDetails(true, "", "");
        

        }

        

        public async Task<OperationDetails> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id локації 0", "");
            }
            Location location = Database.Locations.GetById(id);
            if (location == null)
            {
                return new OperationDetails(false, "Не знайдено", "");
            }

            Database.Locations.Delete(location);
            await Database.SaveAsync();
            return new OperationDetails(true, "Не знайдено ", "");
        }

        

    }
}
