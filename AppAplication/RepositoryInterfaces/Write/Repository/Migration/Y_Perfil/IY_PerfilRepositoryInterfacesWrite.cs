using Dominio.Entitys.Y_Perfil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_Perfil
{
    public partial interface IY_PerfilWriteRepository
    {
        void Insert(Y_PerfilEntity y_perfil);
        void Update(Y_PerfilEntity y_perfil);
        void Delete(Y_PerfilEntity y_perfil);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration