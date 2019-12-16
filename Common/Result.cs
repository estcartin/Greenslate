using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Greenslate.Common
{
    public class Result<T>
    {

        public Status Status { get; set; } = new Status();

        public T Data { get; set; }

    }
}