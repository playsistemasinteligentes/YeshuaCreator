using Dominio.Entitys.GrupoServico;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output.Querys.GrupoServico
{
    public class GrupoServicoReadQuery : QueryBase
    {
        public QueryModel GrupoServicoQuery(Command.Commands.Read.GrupoServicoReadCommand Command)
        {
            this.Query = $@" select Id, Descricao from GrupoServico ";
            return new QueryModel(this.Query, null);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureReadQuerysMigration