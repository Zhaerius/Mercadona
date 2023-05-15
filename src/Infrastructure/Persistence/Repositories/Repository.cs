using Application.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MercaDbContext context;
        private readonly DbSet<T> dbSet;

        public Repository(MercaDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }


        public virtual IQueryable<T> GetAll()
        {
            return dbSet;
        }

        public virtual T GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public virtual void Create(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            var entityToDelete = dbSet.Find(entity);
            dbSet.Remove(entityToDelete);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
