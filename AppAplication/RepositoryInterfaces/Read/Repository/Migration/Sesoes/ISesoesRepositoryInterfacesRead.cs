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
        public IEnumerable<SesoesReadDTO> getSesoes(object command);
        public SesoesDTO getById();
        public IEnumerable<SesoesDTO> getSesoesReadFKPacienteId(object command);
        public IEnumerable<SesoesDTO> getSesoesReadFKProfissionalId(object command);
        public IEnumerable<SesoesDTO> getSesoesReadFKServicoId(object command);
        public IEnumerable<SesoesDTO> getSesoesReadFKMovimentacaoFinanceiraId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration