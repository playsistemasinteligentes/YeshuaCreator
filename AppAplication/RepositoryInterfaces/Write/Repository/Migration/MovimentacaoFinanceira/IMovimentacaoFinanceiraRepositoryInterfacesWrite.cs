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
        void Insert(MovimentacaoFinanceiraEntity movimentacaofinanceira);
        void Update(MovimentacaoFinanceiraEntity movimentacaofinanceira);
        void Delete(MovimentacaoFinanceiraEntity movimentacaofinanceira);
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesWriteMigration