using BookShop.Domain.Models;
using BookShop.Infrastructure.Persistance.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Find(int id);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);

        void Add(TEntity entity);

        TEntity Update(TEntity entity);

        IQueryable<TEntity> GetAll();

        void Save();
        Task<PaginatedResult<TEntity>> GetPagedData(PagedRequest pagedRequest, CancellationToken cancellationToken);

        Task<PaginatedResult<TEntity>> GetPagedDataWithInclude(PagedRequest pagedRequest, CancellationToken cancellationToken, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
