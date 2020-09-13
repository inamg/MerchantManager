using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using ServiceStack;

namespace Andromeda.MerchantManager.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoContext _context;
        private readonly IMongoCollection<TEntity> _dbSet;

        protected BaseRepository(IMongoContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<TEntity>(typeof(TEntity).Name);
        }

        public virtual void Add(TEntity obj)
        {
            _context.AddCommand(() => _dbSet.InsertOneAsync(obj));
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var data = await _dbSet.FindAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return data.SingleOrDefault();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var all = await _dbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return all.ToList();
        }

        public virtual void Update(TEntity obj)
        {
            _context.AddCommand(() => _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", obj.GetId()), obj));
        }

        public virtual void Remove(Guid id)
        {
            _context.AddCommand(() => _dbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));
        }
    }
}