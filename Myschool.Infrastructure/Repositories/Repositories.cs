using Microsoft.EntityFrameworkCore;
using Myschool.Domain.Repositories;
using Myschool.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Myschool.Infrastructure.Repositories
{
    public abstract class Repositories<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly SchoolDbContext _context;
        DbSet<TEntity> _dbSet;
        public Repositories(SchoolDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await Task.FromResult(_dbSet.Remove(entity));
        }

        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public Task<List<TEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
