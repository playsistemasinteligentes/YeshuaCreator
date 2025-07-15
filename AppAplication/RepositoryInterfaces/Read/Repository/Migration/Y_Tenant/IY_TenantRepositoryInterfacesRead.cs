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
    public interface IY_TenantReadRepository
    {
        public DataPagination<Y_TenantDTO> getY_Tenant(ICommandRead command);
        public Y_TenantDTO getById();
        public IEnumerable<Y_TenantUserIDAdminDTO> getY_TenantReadFKUserIDAdmin(object command);
        public bool ExistsById(int value);
        public bool ExistsByCnpjCpf(int value);
        public bool ExistsByNome(string value);
        public bool ExistsByUserIDAdmin(int value);
        public Y_TenantDTO FirstById(int value);
        public Y_TenantDTO FirstByCnpjCpf(int value);
        public Y_TenantDTO FirstByNome(string value);
        public Y_TenantDTO FirstByUserIDAdmin(int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration