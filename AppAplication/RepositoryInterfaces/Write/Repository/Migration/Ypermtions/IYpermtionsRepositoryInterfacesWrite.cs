using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Ypermtions
{
    public partial interface IYpermtionsWriteRepository
    {
        void Insert(IYpermtionsEntity ypermtions);
        void Update(IYpermtionsEntity ypermtions);
        void Delete(IYpermtionsEntity ypermtions);
        public void UpdateDescription(IYpermtionsEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration