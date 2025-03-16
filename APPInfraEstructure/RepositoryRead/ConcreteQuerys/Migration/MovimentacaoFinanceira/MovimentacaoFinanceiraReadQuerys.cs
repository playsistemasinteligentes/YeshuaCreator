using Dominio.Entitys.MovimentacaoFinanceira;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.MovimentacaoFinanceira
{
    public class MovimentacaoFinanceiraReadQuery : QueryBase
    {
        public QueryModel MovimentacaoFinanceiraQuery(Command.Commands.Read.MovimentacaoFinanceiraReadCommand Command)
        {
            this.Query = $@" select Id, PacienteId, ServicoId, Valor, TipoMovimentacao, DataMovimentacao, SaldoAtual from MovimentacaoFinanceira ";
            return new QueryModel(this.Query, null);
        }
        public QueryModel MovimentacaoFinanceiraPacienteIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Paciente ";
            return new QueryModel(this.Query, null);
        }
        public QueryModel MovimentacaoFinanceiraServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Nome from Servico ";
            return new QueryModel(this.Query, null);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration