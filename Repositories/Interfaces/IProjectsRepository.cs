using Greenslate.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenslate.Repositories.Interfaces
{
    public interface IProjectsRepository
    {
        ObjectResult<GetUserProjectData_Result> GetUserProjectData(int id);

        IList<UserProjectsDTO> GetUserProjectFromCode(int id);
    }
}
