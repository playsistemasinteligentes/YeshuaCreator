using Repositorio.Outputs.DTOs.Atendimento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Atendimento
{
    public interface IAtendimentoReadRepository
    {
        public IEnumerable<AtendimentoDTO> getAllAtendimento();
        public AtendimentoDTO getById();
    }
}
