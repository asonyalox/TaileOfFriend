using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.Interfaces
{
    public interface IEventService
    {
        IEnumerable<Event> GetAllEvents();
        Event GetById(int id);

        Task<OperationDetails> CreateAsync(Event _event);
        Task<OperationDetails> EditAsync(Event _event);
        Task<OperationDetails> DeleteAsync(int id);
        IEnumerable<EventDTO> Events();
        Task<OperationDetails> Create(string EventName, Location Location, string Description, DateTime EventDates, string OwnerId);
    }
}
