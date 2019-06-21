using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Infrasrtucture;
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

        public async Task<OperationDetails> ChangeImage(string userId, Image newImage)
        {
            var profile = Database.ProfileRepository.GetProfileWithFields(userId);
            if (profile == null)
            {
                return new OperationDetails(false, "", "");
            }

            
            int oldImageId = profile.Image.Id;

            profile.Image = newImage;
            Database.ProfileRepository.Update(profile);

            var oldImage = Database.Images.GetById(oldImageId);
            if (oldImage != null)
            {
                Database.Images.Delete(oldImage);
            }
            
            await Database.SaveAsync();
            return new OperationDetails(true, "", "");
            
        }

        public async Task<OperationDetails> ChangeLocation(string userId, Location newLocation)
        {
            var profile = Database.ProfileRepository.GetProfileWithFields(userId);
            if (profile == null)
            {
                return new OperationDetails(false,"","");
            }

            profile.Location = newLocation;
            Database.ProfileRepository.Update(profile);

            await Database.SaveAsync();
            return new OperationDetails(true, "", "");
        }

        

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
