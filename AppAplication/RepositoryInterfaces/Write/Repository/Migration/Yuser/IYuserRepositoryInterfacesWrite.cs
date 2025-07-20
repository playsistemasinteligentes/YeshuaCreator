using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IYuserWriteRepository
    {
        void Insert(IYuserEntity yuser);
        void Update(IYuserEntity yuser);
        void Delete(IYuserEntity yuser);
        public void UpdateNome(IYuserEntity entity);
        public void UpdateEmail(IYuserEntity entity);
        public void UpdateSenha(IYuserEntity entity);
        public void UpdateTenantID(IYuserEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration