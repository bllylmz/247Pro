using _247Pro.Core.Entity;
using _247Pro.Core.Repository;
using _247Pro.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Transactions;

namespace _247Pro.Service.Repository.Base
{
    public class Repository<T> : IRepository<T> where T : CoreEntity
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }

        private DbSet<T> _entities;

        public DbSet<T> Entities
        {
            get 
            { 
                if(_entities == null)
                    _entities = _context.Set<T>();
                return _entities; 
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }

        public async Task<T> Add(T item)
        {
            try
            {
                if (item == null)
                    return null;
                await Entities.AddAsync(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AddRange(List<T> items)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    await Entities.AddRangeAsync(items);
                    int result = await Save();
                    if (result == items.Count)
                    {
                        ts.Complete();
                        return result > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> Update(T item)
        {
            try
            {
                if (item == null)
                    return null;

                Entities.Update(item);

                if (await Save() > 0)
                    return item;
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateRange(List<T> items)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    Entities.UpdateRange(items);
                    int result = await Save();
                    if (result == items.Count)
                    {
                        ts.Complete();
                        return result > 0;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> exp) => await Entities.AnyAsync(exp);

        public async Task<T> GetByParam(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includesParameters)
        {
            IQueryable<T> querable = TableNoTracking;
            foreach (Expression<Func<T, object>> includesParameter in includesParameters)
            {
                querable = querable.Include(includesParameter);
            }
            return await querable.FirstOrDefaultAsync(exp);
        }

        public async Task<T> GetById(Guid id, params Expression<Func<T, object>>[] includesParameters)
        {
            IQueryable<T> querable = TableNoTracking;
            foreach (Expression<Func<T, object>> includesParameter in includesParameters)
            {
                querable = querable.Include(includesParameter);
            }
            return await querable.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public IQueryable<T> GetDefault(Expression<Func<T, bool>> exp, params Expression<Func<T, object>>[] includesParameters)
        {
            IQueryable<T> querable = TableNoTracking;
            foreach (Expression<Func<T, object>> includesParameter in includesParameters)
            {
                querable = querable.Include(includesParameter);
            }
            return querable.Where(exp);
        }

        public async Task<bool> Remove(Guid id)
        {
            T entity = await GetById(id);
            if (entity == null)
                return false;

            Entities.Remove(entity);

            if (await Save() > 0)
                return true;
            else
                return false;
        }

        public async Task<bool> RemoveAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var collection = GetDefault(exp);
                    int count = 0;
                    foreach (var item in collection)
                    {
                        Entities.Remove(item);
                        if (await Save() > 0)
                            count++;
                    }
                    if (collection.Count() == count)
                    {
                        ts.Complete();
                        return true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<int> Save() => await _context.SaveChangesAsync();
    }
}
