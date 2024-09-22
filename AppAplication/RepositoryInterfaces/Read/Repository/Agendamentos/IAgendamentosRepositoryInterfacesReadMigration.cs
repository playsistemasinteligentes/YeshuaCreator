using Repositorio.Outputs.DTOs.Agendamentos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Agendamentos
{
    public interface IAgendamentosReadRepository
    {
        public IEnumerable<AgendamentosDTO> getAllAgendamentos();
        public AgendamentosDTO getById();
    }
}
