// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration
// </yeshua>

using Dominio.Entitys;
using Shered.DB;
using Command.Write;
using IQuery.Write;
using Aplication.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query.Write
{
    public class GrupoSegmentoQueryWrite : QueryBase, IGrupoSegmentoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public GrupoSegmentoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirGrupoSegmentoQuery(IGrupoSegmentoEntity GrupoSegmento)
        {
            this.Query = $@" INSERT INTO [GrupoSegmento] ([GRS_ID], [GRS_DESCRICAO], [GRS_INTEGRACAO_ERP], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@GRS_ID, @GRS_DESCRICAO, @GRS_INTEGRACAO_ERP, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GRS_ID = GrupoSegmento.GRS_ID,
                GRS_DESCRICAO = GrupoSegmento.GRS_DESCRICAO,
                GRS_INTEGRACAO_ERP = GrupoSegmento.GRS_INTEGRACAO_ERP,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoSegmentoQuery(IGrupoSegmentoEntity GrupoSegmento)
        {
            this.Query = $@" UPDATE [GrupoSegmento] SET [GRS_ID] = @GRS_ID, [GRS_DESCRICAO] = @GRS_DESCRICAO, [GRS_INTEGRACAO_ERP] = @GRS_INTEGRACAO_ERP, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRS_ID = GrupoSegmento.GRS_ID,
                GRS_DESCRICAO = GrupoSegmento.GRS_DESCRICAO,
                GRS_INTEGRACAO_ERP = GrupoSegmento.GRS_INTEGRACAO_ERP,
                Changed = GrupoSegmento.Changed,
                UserId = _executionContext.UserId,
                Id = GrupoSegmento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRS_ID(int id, string value)
        {
            this.Query = $@" UPDATE [GrupoSegmento] SET [GRS_ID] = @GRS_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRS_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRS_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [GrupoSegmento] SET [GRS_DESCRICAO] = @GRS_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRS_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRS_INTEGRACAO_ERP(int id, string value)
        {
            this.Query = $@" UPDATE [GrupoSegmento] SET [GRS_INTEGRACAO_ERP] = @GRS_INTEGRACAO_ERP WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRS_INTEGRACAO_ERP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [GrupoSegmento] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [GrupoSegmento] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [GrupoSegmento] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [GrupoSegmento] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoSegmentoQuery(IGrupoSegmentoEntity GrupoSegmento)
        {
            this.Query = $@" DELETE FROM [GrupoSegmento] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = GrupoSegmento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration