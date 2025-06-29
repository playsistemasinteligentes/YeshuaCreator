using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_Perfil
{
    public partial interface IY_PerfilWriteRepository
    {
        void Insert(IY_PerfilEntity y_perfil);
        void Update(IY_PerfilEntity y_perfil);
        void Delete(IY_PerfilEntity y_perfil);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration