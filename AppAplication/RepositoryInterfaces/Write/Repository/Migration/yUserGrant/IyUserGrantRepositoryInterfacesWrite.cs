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
        public void UpdatePerfilId(IyUserGrantEntity entity);
        public void UpdateGrantId(IyUserGrantEntity entity);
        public void UpdateGrant(IyUserGrantEntity entity);
        public void UpdateCreate(IyUserGrantEntity entity);
        public void UpdateRead(IyUserGrantEntity entity);
        public void UpdateUpdate(IyUserGrantEntity entity);
        public void UpdateDelete(IyUserGrantEntity entity);
        public void UpdateValidUntil(IyUserGrantEntity entity);
        public void UpdateTenantID(IyUserGrantEntity entity);
        public void UpdateDeleted(IyUserGrantEntity entity);
        public void UpdateChanged(IyUserGrantEntity entity);
        public void UpdateUserId(IyUserGrantEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration