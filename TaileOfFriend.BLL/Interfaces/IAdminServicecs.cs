using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.Interfaces
{
    public interface IAdminServicecs:IDisposable
    {
        List<User> Users { get; set; }

        
    }
}
