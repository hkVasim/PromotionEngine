using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Promotion.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        void Create(T entity);
        void Delete(T entity);
        List<T> FindAll();
        List<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Save();
        void Update(T entity);
    }
}