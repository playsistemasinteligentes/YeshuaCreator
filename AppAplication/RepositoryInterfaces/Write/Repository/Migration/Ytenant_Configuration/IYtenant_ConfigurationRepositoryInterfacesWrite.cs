using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.Ytenant_Configuration
{
    public partial interface IYtenant_ConfigurationWriteRepository
    {
        void Insert(IYtenant_ConfigurationEntity ytenant_configuration);
        void Update(IYtenant_ConfigurationEntity ytenant_configuration);
        void Delete(IYtenant_ConfigurationEntity ytenant_configuration);
        public void UpdateAuditTrackerActived(IYtenant_ConfigurationEntity entity);
        public void UpdateAuditCRUDActived(IYtenant_ConfigurationEntity entity);
        public void UpdateTenantID(IYtenant_ConfigurationEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration