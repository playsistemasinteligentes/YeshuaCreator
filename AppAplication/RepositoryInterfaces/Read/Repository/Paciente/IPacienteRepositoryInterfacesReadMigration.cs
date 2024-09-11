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
        public IEnumerable<PacienteDTO> GetAllPacientes();
        public PacienteDTO GetById();
    }
}
