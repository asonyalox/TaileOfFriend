using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TaileOfFriend.DAL.Enteties;
using System.Linq;

namespace TaileOfFriend.BLL.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new User { Email = userDto.Email, PhoneNumber=userDto.Phone, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
                // Роль добавкка
                await Database.UserManager.AddToRoleAsync(user, userDto.Role);
                //Profile
                Profile profile = new Profile { Id = user.Id,  Birthday=userDto.Birthday};
               
            };

            var p = new Profile
            {
                UserId = user.Id;

            };

            if (userDto.Location != null)
            {

                p.Location location = Database.Lockations.All()
                    .Where(l => l.Loc == userDto.Location.Loc).FirstOrDefault() ??
                    userDto.Location;


            }

            
            
        }

       


    }
}
