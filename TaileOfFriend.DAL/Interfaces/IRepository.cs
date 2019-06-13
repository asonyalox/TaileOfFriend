
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaileOfFriend.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        IQueryable<T> All();
        void Insert(T item);
        void Update(T item);
        void Delete(T item);
        
    }
}
