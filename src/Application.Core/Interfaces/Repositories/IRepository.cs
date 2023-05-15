using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        public T GetById(Guid id);
        public IQueryable<T> GetAll();
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void SaveChanges();
    }
}
