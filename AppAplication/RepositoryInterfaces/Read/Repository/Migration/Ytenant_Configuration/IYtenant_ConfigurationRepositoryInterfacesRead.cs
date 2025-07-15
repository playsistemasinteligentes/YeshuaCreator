using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.RepositoryInterfaces
{
    public interface IYtenant_ConfigurationReadRepository
    {
        public DataPagination<Ytenant_ConfigurationDTO> getYtenant_Configuration(ICommandRead command);
        public Ytenant_ConfigurationDTO getById();
        public IEnumerable<Ytenant_ConfigurationTenantIDDTO> getYtenant_ConfigurationReadFKTenantID(object command);
        public bool ExistsById(int value);
        public bool ExistsByAuditTrackerActived(int value);
        public bool ExistsByAuditCRUDActived(int value);
        public bool ExistsByTenantID(int value);
        public Ytenant_ConfigurationDTO FirstById(int value);
        public Ytenant_ConfigurationDTO FirstByAuditTrackerActived(int value);
        public Ytenant_ConfigurationDTO FirstByAuditCRUDActived(int value);
        public Ytenant_ConfigurationDTO FirstByTenantID(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration