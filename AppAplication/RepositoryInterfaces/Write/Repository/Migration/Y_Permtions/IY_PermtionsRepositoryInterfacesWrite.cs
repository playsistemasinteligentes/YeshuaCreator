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
        void Insert(IY_PermtionsEntity y_permtions);
        void Update(IY_PermtionsEntity y_permtions);
        void Delete(IY_PermtionsEntity y_permtions);
        public void UpdateDescription(IY_PermtionsEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration