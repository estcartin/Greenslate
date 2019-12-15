using Greenslate.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Greenslate.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private GreenslateContext dbContext;

        public UsersRepository()
        {
            dbContext = new GreenslateContext();
        }

        public IList<User> GetAllUserNames()
        {
            var result = dbContext.Users.ToList();

            return result;
        }
    }
}