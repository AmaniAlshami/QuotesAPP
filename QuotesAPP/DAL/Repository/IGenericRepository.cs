using System;
using System.Linq.Expressions;

namespace QuotesAPP.DAL
{
	public interface IGenericRepository<TEntity> where TEntity : class
	{
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(object id);
        void Insert(TEntity model);
        void Update(TEntity model);
        void Delete(object model);
        void Save();
    }
}

