using Affiliation.Domain;
using Affiliation.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Affiliation.Infrastructure
{
    public class Repository<TModel> : IRepository<TModel>
        where TModel : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TModel> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TModel>();
        }

        public IQueryable<TModel> All()
        {
            return _dbSet;
        }

        public void Delete(TModel model)
        {
            _dbSet.Remove(model);
        }

        public TModel Get(int id)
        {
            return _dbSet.Find(id);
        }

        public TModel Insert(TModel model)
        {
            var track = _dbSet.Add(model);
            _dbContext.SaveChanges();
            return track.Entity;
        }

        public void Update(TModel model)
        {
            _dbSet.Update(model);
            _dbContext.SaveChanges();
        }
    }
}
