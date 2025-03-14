using Repositorio.Outputs.DTOs.MovimentacaoFinanceira;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira
{
    public interface IMovimentacaoFinanceiraReadRepository
    {
        public IEnumerable<MovimentacaoFinanceiraReadDTO> getMovimentacaoFinanceira(object command);
        public MovimentacaoFinanceiraDTO getById();
        public IEnumerable<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceiraReadFKPacienteId(object command);
        public IEnumerable<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceiraReadFKServicoId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration