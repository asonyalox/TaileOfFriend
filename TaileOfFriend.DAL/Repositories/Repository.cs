using System;
using System.Collections.Generic;
using System.Text;
using TaileOfFriend.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TaileOfFriend.DAL.Enteties;

namespace TaileOfFriend.DAL.Repositories
{
    public class Repository<T>:IRepository<T> where T:class
    {
        protected readonly TaileOfFriendContext context;
        protected readonly DbSet<T> dbset;

        public IQueryable<T> Entities { get; private set; }
        public IQueryable<T> All() => dbset;

        public Repository(TaileOfFriendContext mainDbContext)
        {
            context = mainDbContext;
            dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual T GetById(int id)
        {
            return dbset.Find(id);
        }
        public virtual void Insert(T item)
        {
            dbset.Add(item);
        }

        public virtual void Update(T item)
        {
            try
            {
                dbset.Attach(item);
            }
            finally
            {
                dbset.Update(item);
            }
        }

        public virtual void Delete(T item)
        {
            if (context.Entry(item).State == EntityState.Detached)
            {
                dbset.Attach(item);
            }
            dbset.Remove(item);
        }

        
    }
}
