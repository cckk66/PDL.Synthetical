using PDL.Synthetical.Domain;
using PDL.Synthetical.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDL.Synthetical.Infrastructure;

namespace PDL.Synthetical.Repositories
{
    public class UserInfoRepository : RepositoryBase<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
        }


    }
}
