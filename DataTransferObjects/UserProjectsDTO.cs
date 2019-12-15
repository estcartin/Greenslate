using System;

namespace Greenslate.DataTransferObjects
{
    public class UserProjectsDTO
    {
        public int Credits { get; set; }
        public string Status { get; set; }
        public int ProjectId { get; set; }
        public DateTime StartDate { get; set; }
        public string TimeToStart { get; set; }
        public DateTime EndDate { get; set; }
    }
}