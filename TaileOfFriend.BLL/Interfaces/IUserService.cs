using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Infrasrtucture;

namespace TaileOfFriend.BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDto);
        Task<ClaimsIdentity> Authenticate(UserDTO userDto);
        Task SetInitialData(UserDTO adminDto, List<string> roles);
    }
}
