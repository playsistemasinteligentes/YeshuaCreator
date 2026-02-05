using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IMovimentoFinanceiroWriteRepository
    {
        void Insert(IMovimentoFinanceiroEntity movimentofinanceiro);
        void Update(IMovimentoFinanceiroEntity movimentofinanceiro);
        void Delete(IMovimentoFinanceiroEntity movimentofinanceiro);
        public void UpdateIdOrigem(IMovimentoFinanceiroEntity entity);
        public void UpdateContaDebitoId(IMovimentoFinanceiroEntity entity);
        public void UpdateContaCreditoId(IMovimentoFinanceiroEntity entity);
        public void UpdateValor(IMovimentoFinanceiroEntity entity);
        public void UpdateDataMovimento(IMovimentoFinanceiroEntity entity);
        public void UpdateDataVencimento(IMovimentoFinanceiroEntity entity);
        public void UpdateStatus(IMovimentoFinanceiroEntity entity);
        public void UpdateTenantID(IMovimentoFinanceiroEntity entity);
        public void UpdateDeleted(IMovimentoFinanceiroEntity entity);
        public void UpdateChanged(IMovimentoFinanceiroEntity entity);
        public void UpdateUserId(IMovimentoFinanceiroEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration