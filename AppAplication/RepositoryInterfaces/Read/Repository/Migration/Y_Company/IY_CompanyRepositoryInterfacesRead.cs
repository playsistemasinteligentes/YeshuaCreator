using Repositorio.Outputs.DTOs.Y_Company;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_Company
{
    public interface IY_CompanyReadRepository
    {
        public DataPagination<Y_CompanyDTO> getY_Company(ICommandRead command);
        public Y_CompanyDTO getById();
        public IEnumerable<Y_CompanyUserIDAdminDTO> getY_CompanyReadFKUserIDAdmin(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration