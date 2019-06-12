using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.DAL.Interfaces
{
    public interface IProfileRepository:IRepository<Profile>
    {
        void Create(Profile profile);
        Profile FindById(string id);
        User FindByUserName(string UserName)
    }
}
