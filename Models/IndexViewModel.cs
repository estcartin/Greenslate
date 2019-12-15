using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Greenslate.Models
{
    public class IndexViewModel
    {
        public IList<User> UserNames { get; set; }

        public SelectList Names 
        {
            get 
            {
                var names = UserNames.Select(n => new
                {
                    n.Id,
                    Name = $"{n.FirstName} {n.LastName}"
                });
                return new SelectList(names, "Id", "Name");
            }
        }
    }
}