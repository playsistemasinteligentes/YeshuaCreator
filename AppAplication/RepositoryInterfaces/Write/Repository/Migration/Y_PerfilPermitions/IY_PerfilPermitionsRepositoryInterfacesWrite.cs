using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_PerfilPermitions
{
    public partial interface IY_PerfilPermitionsWriteRepository
    {
        void Insert(IY_PerfilPermitionsEntity y_perfilpermitions);
        void Update(IY_PerfilPermitionsEntity y_perfilpermitions);
        void Delete(IY_PerfilPermitionsEntity y_perfilpermitions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration