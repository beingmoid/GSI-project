using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{

        public class UserProfileRepository : EFRepository<UserProfile, int>, IUserProfileRepository
        {
            public UserProfileRepository(RequestScope<EfContext> requestScope)
                : base(requestScope)
            {

            }
        }
        public interface IUserProfileRepository : IEFRepository<UserProfile, int>
        {

        }
    
}
