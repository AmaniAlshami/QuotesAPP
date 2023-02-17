using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace QuotesAPP.DAL
{
	public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity :class
	{
        internal QuoteContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(QuoteContext context)
		{
            this.context = new QuoteContext();
            this.dbSet = context.Set<TEntity>();
        }


        public virtual void Delete(object id)
        {
            TEntity existing = dbSet.Find(id);
            dbSet.Remove(existing); ;
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity model)
        {
            dbSet.Add(model);
        }

        public virtual void Save()
        {
            this.context.SaveChanges();
        }

        public virtual void Update(TEntity model)
        {
            dbSet.Attach(model);
            dbSet.Update(model);
            //this.context.Entry(model).State = EntityState.Modified;
        }

   
    }
}

