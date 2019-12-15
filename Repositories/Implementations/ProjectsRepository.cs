using Greenslate.DataTransferObjects;
using Greenslate.Repositories.Interfaces;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Greenslate.Repositories.Implementations
{
    public class ProjectsRepository : IProjectsRepository
    {

        private readonly GreenslateContext dbContext;

        public ProjectsRepository()
        {
            dbContext = new GreenslateContext();
        }

        public IList<UserProjectsDTO> GetUserProjectData(int id)
        {
            var usingSql = bool.Parse(ConfigurationManager.AppSettings["GetDataFromStoreProc"]);

            return usingSql ? GetUserProjectDataFromStoreProc(id) : GetUserProjectFromLinq(id);
        }

        private IList<UserProjectsDTO> GetUserProjectDataFromStoreProc(int id)
        {
            var result = dbContext.GetUserProjectData(id).Select(p => new UserProjectsDTO()
            {
                ProjectId = p.ProjectId,
                StartDate = p.StartDate,
                EndDate = p.EndDate,
                Credits = p.Credits,
                Status = p.Status,
                TimeToStart = p.TimeToStart
            }); 

            return result.ToList();
        }

        private IList<UserProjectsDTO> GetUserProjectFromLinq(int id)
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