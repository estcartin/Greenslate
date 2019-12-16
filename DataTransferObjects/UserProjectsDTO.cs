using System;

namespace Greenslate.DataTransferObjects
{
    /// <summary>
    /// Class UserProjectsDTO
    /// </summary>
    public class UserProjectsDTO
    {
        /// <summary>
        /// The Credits for the project
        /// </summary>
        public int Credits { get; set; }

        /// <summary>
        /// The Status of the project for the user
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// The project Id
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// The project start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The amount of days from the start of the project until the user was assigned to the project. 
        /// Started if they were assigned before.
        /// </summary>
        public string TimeToStart { get; set; }

        /// <summary>
        /// The project end date
        /// </summary>
        public DateTime EndDate { get; set; }
    }
}