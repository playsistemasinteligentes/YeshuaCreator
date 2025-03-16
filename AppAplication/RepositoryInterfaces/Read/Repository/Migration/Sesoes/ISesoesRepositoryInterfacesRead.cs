using Repositorio.Outputs.DTOs.Sesoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.Sesoes
{
    public interface ISesoesReadRepository
    {
        public IEnumerable<SesoesDTO> getSesoes(object command);
        public SesoesDTO getById();
        public IEnumerable<SesoesPacienteIdDTO> getSesoesReadFKPacienteId(object command);
        public IEnumerable<SesoesProfissionalIdDTO> getSesoesReadFKProfissionalId(object command);
        public IEnumerable<SesoesServicoIdDTO> getSesoesReadFKServicoId(object command);
        public IEnumerable<SesoesMovimentacaoFinanceiraIdDTO> getSesoesReadFKMovimentacaoFinanceiraId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration