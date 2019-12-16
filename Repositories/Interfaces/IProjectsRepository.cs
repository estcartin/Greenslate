using Greenslate.Common;
using Greenslate.DataTransferObjects;
using System.Collections.Generic;

namespace Greenslate.Repositories.Interfaces
{
    /// <summary>
    /// Interface IProjectsRepository
    /// </summary>
    public interface IProjectsRepository
    {
        /// <summary>
        /// Method used to retrieve a list of projects for the provided User Id
        /// </summary>
        /// <param name="userId">The user Id to retrieve project info for.</param>
        /// <returns>The list of projects for the user.</returns>
        Result<IList<UserProjectsDTO>> GetUserProjectData(int userId);
    }
}
