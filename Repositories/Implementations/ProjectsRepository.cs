using Greenslate.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;

namespace Greenslate.Repositories.Implementations
{
    public class ProjectsRepository : IProjectsRepository
    {

        private GreenslateContext dbContext;

        public ProjectsRepository()
        {
            dbContext = new GreenslateContext();
        }

        public ObjectResult<GetUserProjectData_Result> GetUserProjectData(int id)
        {
            return dbContext.GetUserProjectData(id);
        }
    }
}