using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDL.Synthetical.Domain;
using PDL.Synthetical.Repositories;
using PDL.Synthetical.Infrastructure;
                      
namespace PDL.Synthetical.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository userInfoRepo;
        public UserInfoService(IUserInfoRepository userInfoRepo)
        {
            this.userInfoRepo = userInfoRepo;
        }
        public void Add(UserInfo entity)
        {
            userInfoRepo.Add(entity);
        }

        public void Delete(UserInfo entity)
        {
            userInfoRepo.Delete(entity);
        }

        public IEnumerable<UserInfo> GetPageList(int pageIndex, int pageSize, out long rowsCount, object predicate = null, bool buffer = true)
        {
            throw new NotImplementedException();
        }

        public void Update(UserInfo entity)
        {
            userInfoRepo.Update(entity);
        }
    }
}
