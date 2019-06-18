using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaileOfFriend.DAL.Enteties;
using TaileOfFriend.DAL.Interfaces;

namespace TaileOfFriend.BLL.Services
{
    public class AdminService
    {
        public  IUnitOfWork Database { get; set; }

        public AdminService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public List<User> Users()
        {
            return Database.UserManager.Users.ToList();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
