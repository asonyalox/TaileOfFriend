using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaileOfFriend.BLL.DTO;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.BLL.Services;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;
using Xunit;

namespace TaileOfFriendTest
{
    
    public class UserServiceTest
    {
        private UserService userService;

        

        [Fact]
        public async Task<OperationDetails> CreateAsync_EmailNotExisting_ReturnTrue()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new UserService(mock.Object);
            var newUser = new UserDTO { Email = "asonyalox@gmail.com" };

            //act
            var result = await service.CreateAsync(newUser);

            //assert
           return Assert.IsType<OperationDetails>(result);
        }
    }
}
