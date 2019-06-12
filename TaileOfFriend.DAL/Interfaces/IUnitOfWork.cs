using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        SignInManager<User> SignInManager { get; }

        RoleManager<IdentityRole> RoleManager { get; }

        UserManager<User> UserManager { get; }

        IProfileRepository ProfileManager { get; }
        IImageRepository Images { get; }
        ICategoryRepository Categories { get; }
        IEventRepository Events { get; }
        ILocationRepository Lockations { get; }

        Task SaveAsync();
    }
}
