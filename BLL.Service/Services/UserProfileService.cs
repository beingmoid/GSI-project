using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Service.Services
{
   
        public class UserProfileService : BaseService<UserProfile, int>, IUserProfileService
        {
            public UserProfileService(RequestScope scopeContext, IUserProfileRepository repository)
                : base(scopeContext, repository)
            {

            }
        }
        public interface IUserProfileService : IBaseService<UserProfile, int>
        {

        }
    
}
