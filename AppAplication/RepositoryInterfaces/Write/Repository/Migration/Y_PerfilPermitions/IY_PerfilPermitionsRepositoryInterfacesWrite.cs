using Dominio.Entitys.Y_PerfilPermitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_PerfilPermitions
{
    public partial interface IY_PerfilPermitionsWriteRepository
    {
        void Insert(Y_PerfilPermitionsEntity y_perfilpermitions);
        void Update(Y_PerfilPermitionsEntity y_perfilpermitions);
        void Delete(Y_PerfilPermitionsEntity y_perfilpermitions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration