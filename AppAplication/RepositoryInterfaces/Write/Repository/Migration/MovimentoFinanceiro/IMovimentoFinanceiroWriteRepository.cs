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
        void UpdateIdOrigem(int id, string value);
        void UpdateContaDebitoId(int id, int value);
        void UpdateValor(int id, Decimal value);
        void UpdateDataMovimento(int id, DateTime value);
        void UpdateDataVencimento(int id, DateTime value);
        void UpdateStatus(int id, int value);
        void UpdateTenantID(int id, int value);
        void UpdateDeleted(int id, bool value);
        void UpdateChanged(int id, DateTime value);
        void UpdateUserId(int id, int value);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration