using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Y_Permtions
{
    public partial interface IY_PermtionsWriteRepository
    {
        void Insert(Y_PermtionsEntity y_permtions);
        void Update(Y_PermtionsEntity y_permtions);
        void Delete(Y_PermtionsEntity y_permtions);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration