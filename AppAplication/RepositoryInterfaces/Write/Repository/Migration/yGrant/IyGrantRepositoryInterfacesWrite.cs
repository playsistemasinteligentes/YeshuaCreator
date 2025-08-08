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
        public void UpdateDescription(IyGrantEntity entity);
        public void UpdateTenantID(IyGrantEntity entity);
        public void UpdateDeleted(IyGrantEntity entity);
        public void UpdateChanged(IyGrantEntity entity);
        public void UpdateUserId(IyGrantEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration