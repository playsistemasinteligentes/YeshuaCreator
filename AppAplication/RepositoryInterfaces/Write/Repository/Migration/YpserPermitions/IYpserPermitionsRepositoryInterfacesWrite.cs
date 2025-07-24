using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYpserPermitionsWriteRepository
    {
        void Insert(IYpserPermitionsEntity ypserpermitions);
        void Update(IYpserPermitionsEntity ypserpermitions);
        void Delete(IYpserPermitionsEntity ypserpermitions);
        public void UpdatePermitionsId(IYpserPermitionsEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration