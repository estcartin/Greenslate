using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Greenslate.Common
{
    /// <summary>
    /// Class Status that gives a detailed status of the different backend operations
    /// </summary>
    public class Status
    {
        /// <summary>
        /// Status code of the operation, SUCCESS if the operation was completed correctly
        /// </summary>
        public StatusCode StatusCode { get; set; }

        /// <summary>
        /// Detailed description of any error that could have happened. Empty string if the operation was completed correctly
        /// </summary>
        public string StatusDesc { get; set; }

        /// <summary>
        /// True if the operation was completed correctly, false otherwise
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Prepares the Status with the success state.
        /// </summary>
        public void SetSuccessfulStatus()
        {
            IsSuccessful = true;
            StatusCode = StatusCode.SUCCESS;
            StatusDesc = "";
        }

        /// <summary>
        /// Prepares the Status with the error state and a description of what happened.
        /// </summary>
        /// <param name="statusCode">Error Status Code.</param>
        /// <param name="statusDesc">Error Description.</param>
        /// <returns>The detailed description of the error.</returns>
        public string SetErrorStatus(StatusCode statusCode, string statusDesc)
        {
            IsSuccessful = false;
            StatusCode = statusCode;
            StatusDesc = statusDesc;
            return statusDesc;
        }

        /// <summary>
        /// Prepares the Status with the given state, description and code
        /// </summary>
        /// <param name="isSuccessful">True if the operation was successful, false otherwise</param>
        /// <param name="statusCode">Code of the status of the operation.</param>
        /// <param name="statusDesc">Description of the status of the operation.</param>
        /// <returns></returns>
        public string SetStatus(bool isSuccessful, StatusCode statusCode, string statusDesc)
        {
            IsSuccessful = isSuccessful;
            StatusCode = statusCode;
            StatusDesc = statusDesc;
            return statusDesc;
        }

    }
}