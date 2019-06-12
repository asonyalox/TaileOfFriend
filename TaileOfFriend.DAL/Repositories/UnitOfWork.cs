using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace TaileOfFriend.DAL.Repositories
{
    class UnitOfWork : IUnitOfWork
    {
        public  TaileOfFriendContext context { get; private set; }

        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public UserManager<User> UserManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }

        public IProfileRepository ProfileManager { get; }
        public IImageRepository Images { get; }
        public ICategoryRepository Categories { get; }
        public IEventRepository Events { get; }
        public ILocationRepository Lockations { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    
                }
                this.disposed = true;
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        
    }
}
