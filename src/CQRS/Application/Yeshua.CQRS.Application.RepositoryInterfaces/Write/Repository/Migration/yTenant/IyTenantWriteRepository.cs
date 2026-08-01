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
        void UpdateCnpjCpf(int id, string value);
        void UpdateNome(int id, string value);
        void UpdateUserId(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration