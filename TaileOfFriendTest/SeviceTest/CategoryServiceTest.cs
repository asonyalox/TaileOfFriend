using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.BLL.Infrasrtucture;
using TaileOfFriend.BLL.Services;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;
using Xunit;

namespace TaileOfFriendTest.SeviceTest
{
    public class CategoryServiceTest
    {
        [Fact]
        public void AddCategory_titleIsEmpty_ReturnFalse()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);
            var newCategory = new Category { Name=null };

            //act
            var result =  service.AddCategory(newCategory.Name);
            
            //asert
            
             Assert.False( result.Succedeed);

        }

        [Fact]
        public void AddCategory_TitleNotEmpty_ReturnTrue()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);
            var newCategory = new Category { Name = "asdasdasd" };

            //act
            var result = service.AddCategory(newCategory.Name);

            //asert

            Assert.True(result.Succedeed);
        }

        [Fact]
        public async void  DeleteCategory_ReturnTrue()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);
            var newCategory = new Category { Id = 1 };

            //act
            var result = await service.DeleteAsync(newCategory.Id);

            //assert
             Assert.True(result.Succedeed);

        }

    }
}
