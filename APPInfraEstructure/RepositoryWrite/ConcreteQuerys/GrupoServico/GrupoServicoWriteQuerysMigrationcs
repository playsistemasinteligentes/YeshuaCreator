using Dominio.Entitys.GrupoServico;
using Shered.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input.Querys.GrupoServico
{
    public class GrupoServicoWriteQuery : QueryBase
    {
        public QueryModel InserirGrupoServicoQuery(GrupoServicoEntity GrupoServico)
        {
            this.Query = $@" INSERT INTO GrupoServico (Descricao) VALUES(@Descricao) ";
            this.Parameters = new
            {
                Descricao = GrupoServico.Descricao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
