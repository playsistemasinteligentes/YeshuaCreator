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
            this.Query = $@" INSERT INTO GrupoServico (Descricao) OUTPUT INSERTED.Id VALUES(@Descricao) ";
            this.Parameters = new
            {
                Descricao = GrupoServico.Descricao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoServicoQuery(GrupoServicoEntity GrupoServico)
        {
            this.Query = $@" UPDATE GrupoServico SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = GrupoServico.Descricao,
                Id = GrupoServico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoServicoQuery(GrupoServicoEntity GrupoServico)
        {
            this.Query = $@" DELETE FROM GrupoServico WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = GrupoServico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureWriteQuerysMigration