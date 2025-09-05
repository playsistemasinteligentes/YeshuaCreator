using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Migration.Dominio.Schemas.CQRS
{
    public enum CommandType
    {
        Crud = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
        Read = 4,
        ReadFK = 5,
        UseCaseGroup = 6,
        UseCase = 7,
        Agent = 8,
        Entity = 9,
        IEntity = 10,
        EntityDecorator = 11,
        Factory = 12,
        DependencyIngection = 13,
        ReadQuery = 14,
    }


    public enum Authorization
    {
        Free = 0,
        User = 1
    }
}
