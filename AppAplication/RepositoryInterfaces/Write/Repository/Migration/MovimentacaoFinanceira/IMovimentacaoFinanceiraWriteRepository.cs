using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepository.Write
{
    public partial interface IMovimentacaoFinanceiraWriteRepository
    {
        void Insert(IMovimentacaoFinanceiraEntity movimentacaofinanceira);
        void Update(IMovimentacaoFinanceiraEntity movimentacaofinanceira);
        void Delete(IMovimentacaoFinanceiraEntity movimentacaofinanceira);
        public void UpdatePacienteId(IMovimentacaoFinanceiraEntity entity);
        public void UpdateServicoId(IMovimentacaoFinanceiraEntity entity);
        public void UpdateValor(IMovimentacaoFinanceiraEntity entity);
        public void UpdateTipoMovimentacao(IMovimentacaoFinanceiraEntity entity);
        public void UpdateDataMovimentacao(IMovimentacaoFinanceiraEntity entity);
        public void UpdateSaldoAtual(IMovimentacaoFinanceiraEntity entity);
        public void UpdateTenantID(IMovimentacaoFinanceiraEntity entity);
        public void UpdateDeleted(IMovimentacaoFinanceiraEntity entity);
        public void UpdateChanged(IMovimentacaoFinanceiraEntity entity);
        public void UpdateUserId(IMovimentacaoFinanceiraEntity entity);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration