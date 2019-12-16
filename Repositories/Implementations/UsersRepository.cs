using Greenslate.Repositories.Interfaces;
using log4net;
using System.Collections.Generic;
using System.Linq;

namespace Greenslate.Repositories.Implementations
{
    /// <summary>
    /// Class UsersRepository, implements IUsersRepository
    /// </summary>
    public class UsersRepository : IUsersRepository
    {
        /// <summary>
        /// The database context created from Entity Framework DB First.
        /// </summary>
        private readonly GreenslateContext dbContext;

        /// <summary>
        /// Log4net logger interface
        /// </summary>
        private readonly ILog logger;

        /// <summary>
        /// Constructor for this page.
        /// </summary>
        /// <param name="log">Log4net injection performed by Unity</param>
        public UsersRepository(ILog log)
        {
            dbContext = new GreenslateContext();
            logger = log;
        }

        /// <summary>
        /// Method used to retrieve a list of users in the database
        /// </summary>
        /// <returns>The list of all users names.</returns>
        public IList<User> GetAllUserNames()
        {
            return dbContext.Users.ToList();
        }
    }
}