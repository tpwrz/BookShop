using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Repositories;
using BookShop.Domain;
using BookShop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Persistance.Repositories
{
   public
        class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public TEntity Find(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.OrderByDescending(x => x.Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public TEntity Update(TEntity entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}

