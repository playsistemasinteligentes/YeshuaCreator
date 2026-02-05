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
    public interface IMovimentoFinanceiroReadRepository
    {
        public DataPagination<MovimentoFinanceiroDTO> getMovimentoFinanceiro(ICommandRead command );
        public IEnumerable<MovimentoFinanceiroContaDebitoIdDTO> getMovimentoFinanceiroReadFKContaDebitoId(object command );
        public IEnumerable<MovimentoFinanceiroContaCreditoIdDTO> getMovimentoFinanceiroReadFKContaCreditoId(object command );
        public IEnumerable<MovimentoFinanceiroTenantIDDTO> getMovimentoFinanceiroReadFKTenantID(object command );
        public IEnumerable<MovimentoFinanceiroUserIdDTO> getMovimentoFinanceiroReadFKUserId(object command );
        public bool ExistsById(int value );
        public bool ExistsByIdOrigem(string value );
        public bool ExistsByContaDebitoId(int value );
        public bool ExistsByContaCreditoId(int value );
        public bool ExistsByValor(Decimal value );
        public bool ExistsByDataMovimento(DateTime value );
        public bool ExistsByDataVencimento(DateTime value );
        public bool ExistsByStatus(int value );
        public bool ExistsByTenantID(int value );
        public bool ExistsByDeleted(bool value );
        public bool ExistsByChanged(DateTime value );
        public bool ExistsByUserId(int value );
        public MovimentoFinanceiroDTO FirstById(int value );
        public MovimentoFinanceiroDTO FirstByIdOrigem(string value );
        public MovimentoFinanceiroDTO FirstByContaDebitoId(int value );
        public MovimentoFinanceiroDTO FirstByContaCreditoId(int value );
        public MovimentoFinanceiroDTO FirstByValor(Decimal value );
        public MovimentoFinanceiroDTO FirstByDataMovimento(DateTime value );
        public MovimentoFinanceiroDTO FirstByDataVencimento(DateTime value );
        public MovimentoFinanceiroDTO FirstByStatus(int value );
        public MovimentoFinanceiroDTO FirstByTenantID(int value );
        public MovimentoFinanceiroDTO FirstByDeleted(bool value );
        public MovimentoFinanceiroDTO FirstByChanged(DateTime value );
        public MovimentoFinanceiroDTO FirstByUserId(int value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllById(int value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByIdOrigem(string value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByContaDebitoId(int value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByContaCreditoId(int value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByValor(Decimal value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDataMovimento(DateTime value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDataVencimento(DateTime value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByStatus(int value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByTenantID(int value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByDeleted(bool value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByChanged(DateTime value );
        public IEnumerable<MovimentoFinanceiroDTO> GetAllByUserId(int value );
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration