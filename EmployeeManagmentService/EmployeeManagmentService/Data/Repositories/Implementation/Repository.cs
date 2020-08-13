using EmployeeManagmentService.Data.Contexts;
using EmployeeManagmentService.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentService.Data.Repositories.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
        {
            _context = context;
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Get(int pageSize, int pageIndex)
        {
            return _context.Set<TEntity>().Skip(pageIndex * pageSize).Take(pageSize);
        }

        public IQueryable<TEntity> Get()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

    }
}
