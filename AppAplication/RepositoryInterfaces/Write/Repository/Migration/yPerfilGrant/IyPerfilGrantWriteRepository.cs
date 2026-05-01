using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyPerfilGrantWriteRepository
    {
        void Insert(IyPerfilGrantEntity yperfilgrant);
        void Update(IyPerfilGrantEntity yperfilgrant);
        void Delete(IyPerfilGrantEntity yperfilgrant);
        void UpdatePerfilId(int id, int value);
        void UpdateGrantId(int id, string value);
        void UpdateGrant(int id, bool value);
        void UpdateCreate(int id, bool value);
        void UpdateRead(int id, bool value);
        void UpdateUpdate(int id, bool value);
        void UpdateDelete(int id, bool value);
        void UpdateValidUntil(int id, DateTime value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration