using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Dominio.Schemas
{
    public class Method
    {
        public Method(Hub hub, string name, string description)
        {
            Hub = hub;
            Name = name;
            Description = description;
        }

        public Hub Hub { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
