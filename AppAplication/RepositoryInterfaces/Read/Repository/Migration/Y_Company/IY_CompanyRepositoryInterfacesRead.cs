using Repositorio.Outputs.DTOs.Y_Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Y_Company
{
    public interface IY_CompanyReadRepository
    {
        public IEnumerable<Y_CompanyDTO> getY_Company(object command);
        public Y_CompanyDTO getById();
        public IEnumerable<Y_CompanyUserIDAdminDTO> getY_CompanyReadFKUserIDAdmin(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration