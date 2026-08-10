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
        void UpdatePacienteId(int id, int value);
        void UpdateServicoId(int id, int value);
        void UpdateValor(int id, Decimal value);
        void UpdateTipoMovimentacao(int id, int value);
        void UpdateDataMovimentacao(int id, DateTime value);
        void UpdateSaldoAtual(int id, Decimal value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration