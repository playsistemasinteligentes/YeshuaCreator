using Repositorio.Outputs.DTOs.MovimentacaoFinanceira;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces.Read.Repository.MovimentacaoFinanceira
{
    public interface IMovimentacaoFinanceiraReadRepository
    {
        public DataPagination<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(ICommandRead command);
        public MovimentacaoFinanceiraDTO getById();
        public IEnumerable<MovimentacaoFinanceiraPacienteIdDTO> getMovimentacaoFinanceiraReadFKPacienteId(object command);
        public IEnumerable<MovimentacaoFinanceiraServicoIdDTO> getMovimentacaoFinanceiraReadFKServicoId(object command);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration