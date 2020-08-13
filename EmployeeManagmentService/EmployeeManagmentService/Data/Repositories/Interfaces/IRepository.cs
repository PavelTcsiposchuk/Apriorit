using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IQueryable<TEntity> Get();
        IQueryable<TEntity> Get(int pageSize, int pageIndex);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
