using _247Pro.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _247Pro.Core.Repository
{
    public interface IRepository<T> where T : CoreEntity
    {
        Task<T> Add(T item);
        Task<bool> AddRange(List<T> items);
        Task<T> Update(T item);
        Task<bool> UpdateRange(List<T> items);
        Task<bool> Remove(Guid id);
        Task<bool> RemoveAll(Expression<Func<T, bool>> exp);
        Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includesParameters);
        Task<T> GetByParam(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includesParameters);
        IQueryable<T> GetDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includesParameters);
        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
        Task<bool> Any(Expression<Func<T, bool>> exp);
        Task<int> Save();

    }
}
