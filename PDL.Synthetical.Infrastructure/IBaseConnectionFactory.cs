using System.Data;

namespace PDL.Synthetical.Infrastructure
{
    public interface IBaseConnectionFactory
    {
        /// <summary>
        /// Gets the database connection
        /// </summary>
        IDbConnection DbConnection { get; }

        /// <summary>
        /// Gets the database transaction
        /// </summary>
        IDbTransaction DbTransaction { get; }

        /// <summary>
        /// commits this instance
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollbacks this inatance
        /// </summary>
        void Rollback();
    }
}