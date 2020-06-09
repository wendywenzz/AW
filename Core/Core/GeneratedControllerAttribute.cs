using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class GeneratedControllerAttribute : Attribute
    {
        public GeneratedControllerAttribute(string route, bool authorize = true)
        {
            Route = route;
            Authorize = authorize;
        }

        public string Route { get; set; }
        public bool Authorize { get; set; }
    }
}
