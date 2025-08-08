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
        public void UpdatePerfilId(IyPerfilGrantEntity entity);
        public void UpdateGrantId(IyPerfilGrantEntity entity);
        public void UpdateGrant(IyPerfilGrantEntity entity);
        public void UpdateCreate(IyPerfilGrantEntity entity);
        public void UpdateRead(IyPerfilGrantEntity entity);
        public void UpdateUpdate(IyPerfilGrantEntity entity);
        public void UpdateDelete(IyPerfilGrantEntity entity);
        public void UpdateValidUntil(IyPerfilGrantEntity entity);
        public void UpdateTenantID(IyPerfilGrantEntity entity);
        public void UpdateDeleted(IyPerfilGrantEntity entity);
        public void UpdateChanged(IyPerfilGrantEntity entity);
        public void UpdateUserId(IyPerfilGrantEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration