using Repositorio.Outputs.DTOs.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Paciente
{
    public interface IPacienteReadRepository
    {
        public IEnumerable<PacienteReadDTO> getPaciente(object command);
        public PacienteDTO getById();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration