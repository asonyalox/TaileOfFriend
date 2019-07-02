using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.BLL.Services;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;
using Xunit;

namespace TaileOfFriendTest.ServiceTest
{
  public  class LocationServiceTest
    {
        [Fact]
        public async void CreateAsync_LocNull_returnFalse()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();

            var service = new LocationService(mock.Object);
            var newLocation = new Location { Loc = null };
            mock.Setup(uow => uow.Locations.Insert(It.IsAny<Location>()));

            //act
            var result = await service.CreateAsync(newLocation);

            //assert
            Assert.False(result.Succedeed);
        }

        [Fact]
        public async void CreateAsync_LocNotNull_returnTrue()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();

            var service = new LocationService(mock.Object);
            var newLocation = new Location { Loc = "Test" };
            mock.Setup(uow => uow.Locations.Insert(It.IsAny<Location>()));

            //act
            var result = await service.CreateAsync(newLocation);

            //assert
            Assert.True(result.Succedeed);
        }

        [Fact]
        public async void DeleteLocation_ReturnTrue()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new LocationService(mock.Object);

            mock.Setup(uow => uow.Locations.GetById(1))
                .Returns(new Location() { Id = 1, Loc = "Test" });
            //act
            var result = await service.DeleteAsync(1);



            //assert
            Assert.True(result.Succedeed);

        }
    }
}
