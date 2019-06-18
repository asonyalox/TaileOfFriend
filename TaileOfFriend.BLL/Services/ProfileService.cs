using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Interfaces;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;

namespace TaileOfFriend.BLL.Services
{
   public class ProfileService:IProfileService
    {
        public IUnitOfWork Database { get; set; }
        public ProfileService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public List<ProfileDTO> Users()
        {
            var profiles = Database.ProfileRepository.All()
                .Include(p => p.User)
                .Include(p => p.Location)
                .ToList();
            var response = new List<ProfileDTO>();

            foreach(var p in profiles)
            {
                response.Add(new ProfileDTO
                {
                    UserName = p.User.UserName,
                    Email = p.User.Email,
                    PhoneNumber = p.User.PhoneNumber,
                    Birthday = p.Birthday,
                    Location = p.Location.Loc,
                    ImageUrl = p.Image?.Url,
                    
                });
            }

            return response;
        }

        public ProfileDTO GetProfile(User u)
        {

            var p = Database.ProfileRepository.GetById(u.Id);

            return new ProfileDTO
            {
                UserName = u.UserName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                Birthday = p.Birthday,
                Location=p.Location?.Loc,
                ImageUrl = p.Image?.Url,
                Gender=p.Gender
            };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
