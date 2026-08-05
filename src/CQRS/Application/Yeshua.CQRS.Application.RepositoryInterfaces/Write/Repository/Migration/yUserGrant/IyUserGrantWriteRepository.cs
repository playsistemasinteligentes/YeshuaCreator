using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyUserGrantWriteRepository
    {
        void Insert(IyUserGrantEntity yusergrant);
        void Update(IyUserGrantEntity yusergrant);
        void Delete(IyUserGrantEntity yusergrant);
        void UpdatePerfilId(int id, int value);
        void UpdateGrantId(int id, string value);
        void UpdateCanGrant(int id, bool value);
        void UpdateCanCreate(int id, bool value);
        void UpdateCanRead(int id, bool value);
        void UpdateCanUpdate(int id, bool value);
        void UpdateCanDelete(int id, bool value);
        void UpdateValidUntil(int id, DateTime value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration