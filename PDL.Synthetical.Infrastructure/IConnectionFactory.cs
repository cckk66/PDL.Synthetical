using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDL.Synthetical.Infrastructure
{
    public interface IConnectionFactory : IBaseConnectionFactory
    {
        IDbConnection GetConnection { get; set; }
    }
}
