using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace TaileOfFriend.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public  TaileOfFriendContext Context { get; private set; }

        public RoleManager<IdentityRole> RoleManager { get; private set; }
        public UserManager<User> UserManager { get; private set; }
        public SignInManager<User> SignInManager { get; private set; }

        public IProfileRepository profileRepositories;
        private IImageRepository images;
        public ICategoryRepository categories;
        public IEventRepository events;
        public ILocationRepository lockations;

        public UnitOfWork(
            TaileOfFriendContext db,
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager
            
            )
        {
            Context = db;

            UserManager = userManager;
            RoleManager = roleManager;
            SignInManager = signInManager;

            
        }


        public IProfileRepository ProfileRepository =>
            profileRepositories ?? (profileRepositories = new ProfileRepository(Context));

        public ILocationRepository Locations =>
            lockations ?? (lockations = new LocationRepository(Context));

        public ICategoryRepository Categories =>
           categories ?? (categories = new CategoryRepository(Context));

        public IImageRepository Images =>
            images ?? (images = new ImageRepository(Context));

        public IEventRepository Events =>
            events ?? (events = new EventRepository(Context));

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
            await Context.SaveChangesAsync();
        }

        
    }
}
