using Dominio.Entitys.Yuser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Yuser
{
    public partial interface IYuserWriteRepository
    {
        void Insert(YuserEntity yuser);
        void Update(YuserEntity yuser);
        void Delete(YuserEntity yuser);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration