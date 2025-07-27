using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYuserPermitionsWriteRepository
    {
        void Insert(IYuserPermitionsEntity yuserpermitions);
        void Update(IYuserPermitionsEntity yuserpermitions);
        void Delete(IYuserPermitionsEntity yuserpermitions);
        public void UpdatePermitionsId(IYuserPermitionsEntity entity);
        public void UpdateUserId(IYuserPermitionsEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration