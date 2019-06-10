
using System;
using System.Collections.Generic;
using System.Text;

namespace TaileOfFriend.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        
    }
}
