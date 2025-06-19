using Repositorio.Outputs.DTOs.Clinica;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Clinica
{
    public interface IClinicaReadRepository
    {
        public DataPagination<ClinicaDTO> getClinica(ICommandRead command);
        public ClinicaDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration