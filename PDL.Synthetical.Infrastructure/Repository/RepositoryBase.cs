using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using System.Linq.Expressions;

namespace PDL.Synthetical.Infrastructure.Repository
{
    public abstract class RepositoryBase<T> where T : class
    {
        private IDbConnection dbConnection;

        protected IConnectionFactory ConnectionFactory { get; private set; }

        protected RepositoryBase(IConnectionFactory connectionFactory)
        {
            ConnectionFactory = connectionFactory;
        }

        protected IDbConnection DbConnection
        {
            get { return dbConnection ?? (dbConnection = ConnectionFactory.GetConnection); }
        }

        public virtual void Add(T entity)
        {
            dbConnection.Insert(entity);
        }

        public virtual void Update(T entity)
        {
            dbConnection.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            dbConnection.Delete(entity);
        }

        public virtual T GetById(long id)
        {
            return dbConnection.Get<T>(id);
        }

        public virtual T GetById(int id)
        {
            return dbConnection.Get<T>(id);
        }

        public virtual T GetById(string id)
        {
            return dbConnection.Get<T>(id);
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await dbConnection.GetAsync<T>(id);
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await dbConnection.GetAsync<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbConnection.GetList<T>();
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbConnection.GetListAsync<T>();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbConnection.GetList<T>().AsQueryable().Where(where);
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await dbConnection.GetListAsync<T>();
        }

        public virtual IEnumerable<T> GetPageList(int pageIndex, int pageSize, out long rowsCount, object predicate = null,
            IList<ISort> sort = null, bool buffer = true)
        {
            if (sort == null) sort = new List<ISort>();
            rowsCount = dbConnection.Count<T>(predicate);
            return dbConnection.GetPage<T>(predicate, sort, pageIndex, pageSize, null, null, buffer);
        }


        /// <summary>
        /// insert batch data.
        /// </summary>
        /// <param name="entityList">isnert entity.</param>
        /// <returns>true/false</returns>
        public virtual bool AddBatch(IEnumerable<T> entityList)
        {
            bool isSuccess = false;
            foreach (var item in entityList)
            {
                dbConnection.Insert<T>(item);
            }
            isSuccess = true;
            return isSuccess;
        }

    }
}
