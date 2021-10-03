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
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await _context.SaveChangesAsync();
            //await _dbSet.AddAsync(entity);
           // _context.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
