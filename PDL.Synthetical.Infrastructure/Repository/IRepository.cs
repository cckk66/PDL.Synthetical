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
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(long id);
        T GetById(int id);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        //IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order);

        Task<T> GetByIdAsync(long id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where);

        #region Add By Isaac

        /// <summary>
        /// 无状态查询
        /// </summary>
        /// <param name="exp">表达式</param>
        /// <returns></returns>
        IQueryable<T> FindAllNoTracking(Expression<Func<T, bool>> exp);
        /// <summary>
        /// 无状态查询
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAllNoTracking();
        /// <summary>
        /// 查找所有数据信息
        /// </summary>
        /// <returns></returns>
        IQueryable<T> FindAll();
        /// <summary>
        /// 执行SQL语句。
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="prm">参数集合</param>
        /// <returns></returns>
        IEnumerable<T> ExcuteSql(string sql, params KeyValuePair<string, object>[] prm);
        /// <summary>
        /// 执行SQL语句。返回指定类型
        /// </summary>
        /// <typeparam name="P">返回类型</typeparam>
        /// <param name="sql">执行的SQL语句</param>
        /// <param name="prm">参数</param>
        /// <returns>返回数据。</returns>
        IEnumerable<P> ExcuteSql<P>(string sql, params KeyValuePair<string, object>[] prm) where P : class, new();

        /// <summary>
        /// 得到分页数据信息
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="sortPredicate">排序字段</param>
        /// <param name="sortOrder">排序方式</param>
        /// <param name="pageNumber">当前页码</param>
        /// <param name="pageSize">页容量</param>
        /// <returns>分页数据结果</returns>
        //PagedResult<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, dynamic>> sortPredicate, string order, int pageNumber, int pageSize);

        /// <summary>
        /// 获取分页数据信息
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="pagination">分页信息</param>
        /// <returns></returns>
        //PagedResult<T> GetAll(Expression<Func<T, bool>> predicate, Pagination pagination);

        //Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, Pagination pagination);
        Task<IEnumerable<T>> GetAllAsync();
        void AddCommandTimeout(int timeout = 120);
        #endregion
    }
}
