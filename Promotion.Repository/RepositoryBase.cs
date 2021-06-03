using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Promotion.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly PromotionContext _promotionContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase{T}"/> class.
        /// </summary>
        /// <param name="projectContext">projectContext.</param>
        public RepositoryBase(PromotionContext promotionContext)
        {
            this._promotionContext = promotionContext;
        }

        /// <summary>
        /// Get All records.
        /// </summary>
        /// <returns>list of records.</returns>
        public List<T> FindAll()
        {
            return this._promotionContext.Set<T>().AsNoTracking().ToList();
        }

        /// <summary>
        /// Get by id.
        /// </summary>
        /// <param name="expression">expression.</param>
        /// <returns>Get record by Id.</returns>
        public List<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._promotionContext.Set<T>().Where(expression).AsNoTracking().ToList();
        }

        /// <summary>
        /// Create new entity.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Create(T entity)
        {
            this._promotionContext.Set<T>().Add(entity);
            this.Save();
        }

        /// <summary>
        /// Update new entity.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Update(T entity)
        {
            this._promotionContext.Set<T>().Update(entity);
            this.Save();
        }

        /// <summary>
        /// Delete new entity.
        /// </summary>
        /// <param name="entity">entity.</param>
        public void Delete(T entity)
        {
            this._promotionContext.Set<T>().Remove(entity);
            this.Save();
        }

        /// <summary>
        /// Save changes.
        /// </summary>
        public void Save()
        {
            this._promotionContext.SaveChanges();
        }
    }
}
