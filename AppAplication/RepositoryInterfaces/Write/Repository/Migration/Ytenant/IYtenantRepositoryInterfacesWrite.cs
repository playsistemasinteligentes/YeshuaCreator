using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyTenantWriteRepository
    {
        void Insert(IyTenantEntity ytenant);
        void Update(IyTenantEntity ytenant);
        void Delete(IyTenantEntity ytenant);
        public void UpdateCnpjCpf(IyTenantEntity entity);
        public void UpdateNome(IyTenantEntity entity);
        public void UpdateUserId(IyTenantEntity entity);
        public void UpdateDeleted(IyTenantEntity entity);
        public void UpdateChanged(IyTenantEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration