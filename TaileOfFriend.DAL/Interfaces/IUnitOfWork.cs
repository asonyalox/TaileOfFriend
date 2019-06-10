using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
        IEventRepository Events { get; }
        ILocationRepository Lockations { get; }

        int Save();
    }
}
