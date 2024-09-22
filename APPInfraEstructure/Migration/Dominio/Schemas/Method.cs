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
        public Method(Entity entity, string name, string description)
        {
            Entity = entity;
            Name = name;
            Description = description;
        }

        public Entity Entity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
