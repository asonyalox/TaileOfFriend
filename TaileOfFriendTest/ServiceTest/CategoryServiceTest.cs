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
            mock.Setup(uow => uow.Categories.Insert(newCategory));
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
            mock.Setup(uow => uow.Categories.Insert(newCategory));
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

            mock.Setup(uow => uow.Categories.GetById(1))
                .Returns(new Category() { Id = 1, Name = "Test" });
            //act
            var result = await service.DeleteAsync(1);

            //assert
             Assert.True(result.Succedeed);

        }

        private List<Category> GetTestCategory()
        {
            var categories = new List<Category> {
            new Category { Id = 1, Name = "Test" },
            new Category { Id=2,Name="Test2"},
            };
            return categories;
        }
        /*
        [Fact]
        public void Categories_returnList()
        {
            //arrange
            var mock = new Mock<IUnitOfWork>();
            var service = new CategoryService(mock.Object);

            mock.Setup(uow => uow.Categories.GetAll())
                .Returns(GetTestCategory());

            //act
            var result = service.Categories();

            //assert
            Assert.l(List<Category>);

        }
        */
    }
}
