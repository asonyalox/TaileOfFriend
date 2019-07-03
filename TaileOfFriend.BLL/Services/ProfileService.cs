using AutoMapper;
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
    public class ProfileService : IProfileService
    {
        public IUnitOfWork Database { get; set; }
        private IMapper mapper { get; set; }

        public ProfileService(IUnitOfWork uow, IMapper _mapper)
        {
            Database = uow;
            mapper = _mapper;
        }

        public IEnumerable<ProfileDTO> Users()
        {
            var profiles = Database.ProfileRepository.AllProfilesWithAllFields();
            var responce = mapper.Map<IEnumerable<TaileOfFriend.DAL.Enteties.Profile>, IEnumerable<ProfileDTO>>(profiles);

            return responce;
        }

        public ProfileDTO GetById(string id)
        {
            var profile = Database.ProfileRepository.GetProfileWithFields(id);

            return mapper.Map<TaileOfFriend.DAL.Enteties.Profile, ProfileDTO>(profile);
        }

        public ProfileDTO GetProfile(User u)
        {
            var profile = Database.ProfileRepository.GetProfileWithFields(u.Id);

            return mapper.Map<TaileOfFriend.DAL.Enteties.Profile, ProfileDTO>(profile);
        }

        public async Task<User> FindById(string id)
        {
            var profile = Database.ProfileRepository.GetProfileWithFields(id);

            User user = await Database.UserManager.FindByIdAsync(profile.UserId);
            return user;
        }

        public async Task<OperationDetails> ChangeImage(string userId, Image newImage)
        {
            var profile = Database.ProfileRepository.GetProfileWithFields(userId);
            if (profile == null)
            {
                return new OperationDetails(false, "", "");
            }


            

            profile.Image = newImage;
            Database.ProfileRepository.Update(profile);

            

            await Database.SaveAsync();
            return new OperationDetails(true, "", "");

        }



        public async Task<OperationDetails> ChangeProfileInfo(ProfileDTO profile)
        {
            if (profile.Id == null)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }

            TaileOfFriend.DAL.Enteties.Profile oldProfile = Database.ProfileRepository.GetProfileWithFields(profile.Id);
            if (oldProfile == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            if (oldProfile.Location != null || oldProfile.Location == null)
            {
                if (Database.Locations.FindClone(profile.Location) == null)
                {
                    Database.Locations.Insert(new Location { Loc = profile.Location.Loc });
                    
                }


                oldProfile.Location = Database.Locations.FindClone(profile.Location);

            }
            oldProfile.UserName = profile.UserName;
            oldProfile.Birthday = profile.Birthday;

            Database.ProfileRepository.Update(oldProfile);

            await Database.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        



        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
