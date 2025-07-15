using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.YperfilPermitions
{
    public partial interface IYperfilPermitionsWriteRepository
    {
        void Insert(IYperfilPermitionsEntity yperfilpermitions);
        void Update(IYperfilPermitionsEntity yperfilpermitions);
        void Delete(IYperfilPermitionsEntity yperfilpermitions);
        public void UpdatePerfilId(IYperfilPermitionsEntity entity);
        public void UpdatePermitionsId(IYperfilPermitionsEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration