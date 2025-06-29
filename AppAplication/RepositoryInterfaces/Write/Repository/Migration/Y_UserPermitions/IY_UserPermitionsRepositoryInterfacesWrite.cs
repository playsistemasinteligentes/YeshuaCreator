using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_UserPermitions
{
    public partial interface IY_UserPermitionsWriteRepository
    {
        void Insert(IY_UserPermitionsEntity y_userpermitions);
        void Update(IY_UserPermitionsEntity y_userpermitions);
        void Delete(IY_UserPermitionsEntity y_userpermitions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration