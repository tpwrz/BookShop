using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BookShop.Application.Repositories;
using BookShop.Domain;
using BookShop.Domain.Models;
using BookShop.Infrastructure.Persistance.Extentions;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Infrastructure.Persistance.Repositories
{
   public
        class EFRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        ProjectContext _context;
        DbSet<TEntity> _dbSet;

        public EFRepository(ProjectContext context)
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

        private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        {
            IQueryable<TEntity> entities = _context.Set<TEntity>();
            foreach (var includeProperty in includeProperties)
            {
                entities = entities.Include(includeProperty);
            }
            return entities;
        }

        public async Task<PaginatedResult<TEntity>> GetPagedData(PagedRequest pagedRequest, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().CreatePaginatedResult<TEntity>(pagedRequest, cancellationToken);
        }

        public async Task<PaginatedResult<TEntity>> GetPagedDataWithInclude(PagedRequest pagedRequest, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = IncludeProperties(includeProperties);
            return await query.CreatePaginatedResult<TEntity>(pagedRequest, cancellationToken);
        }

        
    }
}

