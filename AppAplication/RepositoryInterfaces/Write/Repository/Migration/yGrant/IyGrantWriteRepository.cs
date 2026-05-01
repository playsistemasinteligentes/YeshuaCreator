using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyGrantWriteRepository
    {
        void Insert(IyGrantEntity ygrant);
        void Update(IyGrantEntity ygrant);
        void Delete(IyGrantEntity ygrant);
        void UpdateDescription(string id, string value);
        void UpdateTenantID(string id, int value);
        void UpdateDeleted(string id, bool value);
        void UpdateChanged(string id, DateTime value);
        void UpdateUserId(string id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration