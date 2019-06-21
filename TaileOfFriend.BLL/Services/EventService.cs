using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;

namespace TaileOfFriend.BLL.Services
{
    public class EventService:IEventService
    {
        public IUnitOfWork Database { get; set; }

        public EventService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<Event> GetAllEvents() => Database.Events.All();

        public Event GetById(int id) => Database.Events.GetById(id);

        public async Task<OperationDetails> CreateAsync(Event _event)
        {
            if (Database.Events.All().Any(c => c.Name == _event.Name))
            {
                return new OperationDetails(false, "Подія з такою назвою вже існує", "");
            }

            Database.Events.Insert(_event);

            await Database.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> EditAsync(Event _event)
        {
            if (_event.Id == 0)
            {
                return new OperationDetails(false, "Некоректне ID 0", "");
            }

            Event oldEvent = Database.Events.GetEventWithAllFileds(_event.Id);
            if (oldEvent == null)
            {
                return new OperationDetails(false, "Не знайдено", "");
            }

            oldEvent.Name = _event.Name;
            oldEvent.EventImage = _event.EventImage;
            oldEvent.Description = _event.Description;
            oldEvent.Location = _event.Location;

            Database.Events.Update(oldEvent);
            await Database.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            Event _event = Database.Events.GetById(id);
            if (_event == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            Database.Events.Delete(_event);
            await Database.SaveAsync();
            return new OperationDetails(true, "Подію видалено ", "");
        }
    }
}
