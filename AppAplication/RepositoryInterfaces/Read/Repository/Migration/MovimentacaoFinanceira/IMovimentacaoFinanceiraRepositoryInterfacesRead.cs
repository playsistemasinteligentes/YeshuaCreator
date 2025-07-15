using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Read.RepositoryInterfaces
{
    public interface IMovimentacaoFinanceiraReadRepository
    {
        public DataPagination<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(ICommandRead command);
        public MovimentacaoFinanceiraDTO getById();
        public IEnumerable<MovimentacaoFinanceiraPacienteIdDTO> getMovimentacaoFinanceiraReadFKPacienteId(object command);
        public IEnumerable<MovimentacaoFinanceiraServicoIdDTO> getMovimentacaoFinanceiraReadFKServicoId(object command);
        public bool ExistsById(int value);
        public bool ExistsByPacienteId(int value);
        public bool ExistsByServicoId(int value);
        public bool ExistsByValor(Decimal value);
        public bool ExistsByTipoMovimentacao(int value);
        public bool ExistsByDataMovimentacao(DateTime value);
        public bool ExistsBySaldoAtual(Decimal value);
        public MovimentacaoFinanceiraDTO FirstById(int value);
        public MovimentacaoFinanceiraDTO FirstByPacienteId(int value);
        public MovimentacaoFinanceiraDTO FirstByServicoId(int value);
        public MovimentacaoFinanceiraDTO FirstByValor(Decimal value);
        public MovimentacaoFinanceiraDTO FirstByTipoMovimentacao(int value);
        public MovimentacaoFinanceiraDTO FirstByDataMovimentacao(DateTime value);
        public MovimentacaoFinanceiraDTO FirstBySaldoAtual(Decimal value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration