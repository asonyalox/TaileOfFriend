using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaileOfFriend.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {


        ICategoryRepository Categories { get; }
        IEventRepository Events { get; }
        ILocationRepository Lockations { get; }

        Task SaveAsync();
    }
}
