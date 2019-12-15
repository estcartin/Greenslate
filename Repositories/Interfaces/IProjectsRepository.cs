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
        IList<UserProjectsDTO> GetUserProjectData(int id);
    }
}
