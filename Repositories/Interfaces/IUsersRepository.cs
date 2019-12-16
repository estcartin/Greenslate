using System.Collections.Generic;

namespace Greenslate.Repositories.Interfaces
{
    /// <summary>
    /// Interface IUsersRepository
    /// </summary>
    public interface IUsersRepository
    {
        /// <summary>
        /// Method used to retrieve a list of users in the database
        /// </summary>
        /// <returns>The list of users.</returns>
        IList<User> GetAllUserNames();

    }
}
