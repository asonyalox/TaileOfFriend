using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.Interfaces
{
    public interface IProfileService:IDisposable
    {
        List<ProfileDTO> Users();
        ProfileDTO GetProfile(User u);
    }
}
