using Greenslate.DataTransferObjects;
using Greenslate.Repositories.Interfaces;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using log4net;
using Greenslate.Common;

namespace Greenslate.Repositories.Implementations
{
    /// <summary>
    /// Class ProjectsRepository, implements IProjectsRepository
    /// </summary>
    public class ProjectsRepository : IProjectsRepository
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
        public ProjectsRepository(ILog log)
        {
            dbContext = new GreenslateContext();
            logger = log;
        }

        /// <summary>
        /// Method used to retrieve a list of projects for the provided User Id
        /// </summary>
        /// <param name="userId">The user Id to retrieve project info for.</param>
        /// <returns>The list of projects for the user.</returns>
        public Result<IList<UserProjectsDTO>> GetUserProjectData(int userId)
        {
            var result = new Result<IList<UserProjectsDTO>>();

            if (userId <= 0) 
            {
                logger.Error("ProjectsRepository:GetUserProjectData - Parameter userId is null.");
                result.Status.SetErrorStatus(result.Status.StatusCode = StatusCode.INVALID_PARAMETER, 
                    result.Status.StatusDesc = "Argument userId cannot be equal or less than 0");
                return result;
            }

            try
            {
                // Read config for method type selection.
                var usingSql = bool.Parse(ConfigurationManager.AppSettings["GetDataFromStoreProc"]);

                // Attempt read user projects from db.
                result.Data = usingSql ? GetUserProjectDataFromStoreProc(userId) : GetUserProjectFromLinq(userId);

                // Set success status.
                result.Status.SetSuccessfulStatus();
                logger.Debug("ProjectsRepository:GetUserProjectData - Ended succesfully");
            }
            catch (Exception e)
            {
                logger.ErrorFormat("ProjectsRepository:GetUserProjectData - Error while trying to read user projects from DB. ErrorDesc: {0} StackTrace:{1}", e.Message, e.StackTrace);
                result.Status.SetErrorStatus(StatusCode.GENERAL_ERROR, e.Message);
            }

            return result;
        }

        /// <summary>
        /// Method used to retrieve a list of projects for the provided User Id using the database stored procedure.
        /// </summary>
        /// <param name="userId">The user Id to retrieve project info for.</param>
        /// <returns>The list of projects for the user.</returns>
        private IList<UserProjectsDTO> GetUserProjectDataFromStoreProc(int userId)
        {
            logger.Debug("ProjectsRepository:GetUserProjectDataFromStoreProc - Using Store Procs");
            var result = dbContext.GetUserProjectData(userId).Select(p => new UserProjectsDTO()
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

        /// <summary>
        /// Method used to retrieve a list of projects for the provided User Id using Entity Framework and the entities with Linq.
        /// </summary>
        /// <param name="userId">The user Id to retrieve project info for.</param>
        /// <returns>The list of projects for the user.</returns>
        private IList<UserProjectsDTO> GetUserProjectFromLinq(int userId)
        {
            logger.Debug("ProjectsRepository:GetUserProjectFromLinq - Using Linq");

            var projects = dbContext.UserProjects.Where(u => u.UserId == userId)
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