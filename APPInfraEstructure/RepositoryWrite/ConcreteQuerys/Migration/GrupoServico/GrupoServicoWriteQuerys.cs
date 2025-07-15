using Dominio.Entitys;
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
        public QueryModel InserirGrupoServicoQuery(IGrupoServicoEntity GrupoServico)
        {
            this.Query = $@" INSERT INTO GrupoServico (Descricao) OUTPUT INSERTED.Id VALUES(@Descricao) ";
            this.Parameters = new
            {
                Descricao = GrupoServico.Descricao,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoServicoQuery(IGrupoServicoEntity GrupoServico)
        {
            this.Query = $@" UPDATE GrupoServico SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = GrupoServico.Descricao,
                Id = GrupoServico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(IGrupoServicoEntity entity)
        {
            this.Query = $@" UPDATE GrupoServico SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = entity.Descricao,
                Id = entity.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoServicoQuery(IGrupoServicoEntity GrupoServico)
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