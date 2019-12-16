using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Greenslate.Models
{
    /// <summary>
    /// ViewModel IndexViewModel which holds data relevant to the Index page.
    /// </summary>
    public class IndexViewModel
    {
        /// <summary>
        /// List of Users loaded from the DB.
        /// </summary>
        public IList<User> Users { get; set; }

        /// <summary>
        /// SelectList of formatted user names and Ids.
        /// </summary>
        public SelectList Names 
        {
            get 
            {
                var names = Users.Select(n => new
                {
                    n.Id,
                    Name = $"{n.FirstName} {n.LastName}"
                });
                return new SelectList(names, "Id", "Name");
            }
        }
    }
}