using Repositorio.Outputs.DTOs.Paciente;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Paciente
{
    public interface IPacienteReadRepository
    {
        public DataPagination<PacienteDTO> getPaciente(ICommandRead command);
        public PacienteDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration