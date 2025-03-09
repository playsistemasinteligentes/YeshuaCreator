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
        ReadFK = 5


    }
}
