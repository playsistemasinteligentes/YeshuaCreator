using Dominio.Entitys.Servico;
using Microsoft.Data.SqlClient;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.Servico
{
    public class ServicoReadQuery : QueryBase
    {
        public QueryModel ServicoQuery(Command.Commands.Read.ServicoReadCommand Command)
        {
            var whereClauses = new List<string>();
            this.Query = $@" select Id, GrupoServicoId, Nome, Valor from Servico ";

            return new QueryModel(this.Query, null);
        }
        public QueryModel ServicoGrupoServicoIdQuery(Command.Patterns.Command.SearchFKCommand Command)
        {
            this.Query = $@" select Id, Descricao from GrupoServico ";
            this.Parameters = null;
            var whereClauses = new List<string>();
copiar esta funçaõ 

            if (!string.IsNullOrEmpty(Command.searchFK))
            {
                if (int.TryParse(Command.searchFK, out int numero))
                {
                    this.Parameters = new
                    {
                        Id = numero,
                    };
                    whereClauses.Add($" Id = @Id");
                }
                else
                {
                    this.Parameters = new { Descricao = $"%{Command.searchFK}%" };
                    whereClauses.Add($" Descricao like @Descricao ");
                }
            }

            if (whereClauses.Any())
                this.Query += " WHERE " + string.Join(" AND ", whereClauses);

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration