using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IyPerfilWriteRepository
    {
        void Insert(IyPerfilEntity yperfil);
        void Update(IyPerfilEntity yperfil);
        void Delete(IyPerfilEntity yperfil);
        public void UpdateDescription(IyPerfilEntity entity);
        public void UpdateTenantID(IyPerfilEntity entity);
        public void UpdateDeleted(IyPerfilEntity entity);
        public void UpdateChanged(IyPerfilEntity entity);
        public void UpdateUserId(IyPerfilEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration