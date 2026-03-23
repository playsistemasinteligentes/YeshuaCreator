using Repositorio.Outputs;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Read
{
    public partial interface IMovimentacaoFinanceiraReadRepository
    {
        public DataPagination<MovimentacaoFinanceiraDTO> getMovimentacaoFinanceira(ICommandRead command );
        public IEnumerable<MovimentacaoFinanceiraPacienteIdDTO> getMovimentacaoFinanceiraReadFKPacienteId(object command );
        public IEnumerable<MovimentacaoFinanceiraServicoIdDTO> getMovimentacaoFinanceiraReadFKServicoId(object command );
        public IEnumerable<MovimentacaoFinanceiraTenantIDDTO> getMovimentacaoFinanceiraReadFKTenantID(object command );
        public IEnumerable<MovimentacaoFinanceiraUserIdDTO> getMovimentacaoFinanceiraReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByPacienteId(int value );
        public bool ExistsByServicoId(int value );
        public bool ExistsByValor(Decimal value );
        public bool ExistsByTipoMovimentacao(int value );
        public bool ExistsByDataMovimentacao(DateTime value );
        public bool ExistsBySaldoAtual(Decimal value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MovimentacaoFinanceiraDTO FirstById(int value );
        public MovimentacaoFinanceiraDTO FirstByPacienteId(int value );
        public MovimentacaoFinanceiraDTO FirstByServicoId(int value );
        public MovimentacaoFinanceiraDTO FirstByValor(Decimal value );
        public MovimentacaoFinanceiraDTO FirstByTipoMovimentacao(int value );
        public MovimentacaoFinanceiraDTO FirstByDataMovimentacao(DateTime value );
        public MovimentacaoFinanceiraDTO FirstBySaldoAtual(Decimal value );
        public MovimentacaoFinanceiraDTO FirstByTenantID(int value );
        public MovimentacaoFinanceiraDTO FirstByDeleted(bool value );
        public MovimentacaoFinanceiraDTO FirstByChanged(DateTime value );
        public MovimentacaoFinanceiraDTO FirstByUserId(int value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllById(int value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByPacienteId(int value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByServicoId(int value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByValor(Decimal value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByTipoMovimentacao(int value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByDataMovimentacao(DateTime value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllBySaldoAtual(Decimal value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByTenantID(int value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByDeleted(bool value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MovimentacaoFinanceiraDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration