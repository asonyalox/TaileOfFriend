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
using Microsoft.AspNetCore.Http;

namespace TaileOfFriend.BLL.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> CreateAsync(UserDTO userDto)
        {
            if(await Database.UserManager.FindByEmailAsync(userDto.Email) != null)
            {
                return new OperationDetails(false, "Такий Емейл вже зареєстровано", "Email");
            }

            User user = new User
            {
                Email = userDto.Email,
                UserName = userDto.Email,
                PhoneNumber = userDto.Phone,
                
            };

            var result = await Database.UserManager.CreateAsync(user, userDto.Password);

            if (result.Errors.Count() > 0)
            {
                return new OperationDetails(false, result.Errors.FirstOrDefault().ToString(), "");
            }

            //Добавляємо роль

            await Database.UserManager.AddToRoleAsync(user, userDto.Role);

            Profile profile = new Profile
            {
                UserId = user.Id,
                Birthday = userDto.Birthday,
                Gender = userDto.Gender,
            };
            

            if (userDto.Location != null)
            {

                Location location = Database.Locations.All()
                    .Where(l => l.Loc == userDto.Location.Loc).FirstOrDefault() ??
                    userDto.Location;

                profile.Location = location;
            }

            Database.ProfileRepository.Insert(profile);
            
        

            await Database.SaveAsync();

            return new OperationDetails(true, "Реєстрація пройшла успішно", "");
            
        }

       public async Task<bool> AuthenticateAsync(UserDTO userDto)
        {
            User user = await Database.UserManager.FindByEmailAsync(userDto.Email);
            var result = await Database.SignInManager.PasswordSignInAsync(user.UserName, userDto.Password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task<User> GetCurrentUserAsync(HttpContext context)
        {
            return await Database.UserManager.GetUserAsync(context.User);
        }

        public async Task SignOutAsync()
        {
            await Database.SignInManager.SignOutAsync();
        }

        public async Task AdminSeedAsync(UserDTO adminDto)
        {
            if (!Database.UserManager.Users.Any())
            {
                await CreateAsync(adminDto);
            }
        }

        public void Dispose()
        {
            Database.Dispose();
        }

    }
}
