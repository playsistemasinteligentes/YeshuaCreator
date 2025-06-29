using Dominio.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Inputs.Repositorio.MovimentacaoFinanceira
{
    public partial interface IMovimentacaoFinanceiraWriteRepository
    {
        void Insert(IMovimentacaoFinanceiraEntity movimentacaofinanceira);
        void Update(IMovimentacaoFinanceiraEntity movimentacaofinanceira);
        void Delete(IMovimentacaoFinanceiraEntity movimentacaofinanceira);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration