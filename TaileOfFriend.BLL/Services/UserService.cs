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
                user = new User { Email = userDto.Email, UserName = userDto.Email };
                var result = await Database.UserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
                // Роль добавкка
                await Database.UserManager.AddToRoleAsync(user, userDto.Role);
                //Profile
                Profile profile = new Profile { Id = user.Id, Location = userDto.Location, Name = userDto.Name };
                Database.ProfileManager.Create(profile);
                await Database.SaveAsync();
                return new OperationDetails(true, "Реєстрація відбулась успішно", "");
            }
            else
            {
                return new OperationDetails(false,"Користувач з таким емейлом вже існує","Email")
            }

            
        }

        public async Task<ClaimsIdentity>Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claim = null;
            //Знаходимо користувача
            User user = await Database.UserManager.FindAsync(userDto.Email, userDto.Password);
            // Авторизумємо і повертаємо обєкт ClaimsIdentity
            if (user != null)
                claim = await Database.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }


    }
}
