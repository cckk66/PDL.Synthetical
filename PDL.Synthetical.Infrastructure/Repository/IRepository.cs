using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PDL.Synthetical.Infrastructure.Repository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        void Updadte(T entity);
        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);
        /// <summary>
        /// Get eintiy by long id.
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns></returns>
        T GetById(long Id);
        /// <summary>
        /// Get entity by int id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetById(int Id);
        /// <summary>
        /// Get entity by string id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        T GetById(string Id);
        /// <summary>
        /// Get async entity by long id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(long Id);
        /// <summary>
        /// Get async enity by int id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int Id);
        /// <summary>
        /// Get async entity by string id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(string Id);
        /// <summary>
        /// Get all entity.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
        /// <summary>
        /// Get async all entity.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync();
        /// <summary>
        /// Get list entity by experesson.
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);

        /// <summary>
        /// Get async list entity by expression
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);

        /// <summary>
        /// Get page list entity.
        /// </summary>
        /// <param name="pageIndex">pageIndex</param>
        /// <param name="pageSize">pageSize</param>
        /// <param name="rowsCount">rowsCount</param>
        /// <param name="predicate">predicate</param>
        /// <param name="sort">sort</param>
        /// <param name="buffer">buffer</param>
        /// <returns></returns>
        IEnumerable<T> GetPageList(int pageIndex, int pageSize, out long rowsCount, object predicate = null, IList<ISort> sort = null, bool buffer = true);

        /// <summary>
        /// batch insert list entity.
        /// </summary>
        /// <param name="entityList">list entity</param>
        /// <returns></returns>
        bool AddBatch(IEnumerable<T> entityList);
    }
}
