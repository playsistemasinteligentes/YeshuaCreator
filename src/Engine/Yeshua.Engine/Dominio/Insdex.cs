using Migration.Dominio.Schemas.CQRS;
using System.Collections.Generic;
using System.Data.Common;

namespace Dominio
{
    public class Index
    {
        public Index(Entity entity)
        {
            Entity = entity;
        }

        public Entity Entity { get; set; }
        public List<Column> IndexColumns { get; set; }
        public List<Column> DisplayColumns { get; set; }

    }
}