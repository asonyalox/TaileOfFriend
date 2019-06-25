using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task<OperationDetails> CreateAsync(UserDTO userDto);
        Task<bool> AuthenticateAsync(UserDTO userDto);
        Task SignOutAsync();

        Task<User> GetCurrentUserAsync(HttpContext context);

        Task AdminSeedAsync(UserDTO adminDto);
        Task<IdentityResult> Delete(UserDTO userDto);

    }
}
