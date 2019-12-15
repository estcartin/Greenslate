using Greenslate.DataTransferObjects;
using Greenslate.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public IList<UserProjectsDTO> GetUserProjectFromCode(int id)
        {

            var projects = dbContext.UserProjects.Where(u => u.UserId == id)
                .Select(p => new UserProjectsDTO()
                {
                    ProjectId = p.ProjectId,
                    StartDate = p.Project.StartDate,
                    EndDate = p.Project.EndDate,
                    Credits = p.Project.Credits,
                    Status = p.IsActive ? "Active" : "Inactive",
                    TimeToStart = DbFunctions.DiffDays(p.Project.StartDate, p.AssignedDate) >= 0 
                        ? DbFunctions.DiffDays(p.Project.StartDate, p.AssignedDate).ToString() 
                        : "Started"
                });

            return projects.ToList();
        }
    }
}