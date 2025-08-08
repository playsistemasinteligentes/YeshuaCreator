using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyUserWriteRepository
    {
        void Insert(IyUserEntity yuser);
        void Update(IyUserEntity yuser);
        void Delete(IyUserEntity yuser);
        public void UpdateNome(IyUserEntity entity);
        public void UpdateEmail(IyUserEntity entity);
        public void UpdateSenha(IyUserEntity entity);
        public void UpdateTenantID(IyUserEntity entity);
        public void UpdateDeleted(IyUserEntity entity);
        public void UpdateChanged(IyUserEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration