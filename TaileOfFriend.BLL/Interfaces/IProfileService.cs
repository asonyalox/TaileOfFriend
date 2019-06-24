using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.Interfaces
{
    public interface IProfileService:IDisposable
    {
        IEnumerable<ProfileDTO> Users();
        ProfileDTO GetProfile(User u);

        Task<OperationDetails> ChangeImage(string userId, Image newImage);
        Task<OperationDetails> ChangeLocation(string userId, Location newLocation);
        Task<User> FindById(string id);
        Task<OperationDetails> ChangeProfileInfo(ProfileDTO profile);
        ProfileDTO GetById(string id);
        
       



    }
}
