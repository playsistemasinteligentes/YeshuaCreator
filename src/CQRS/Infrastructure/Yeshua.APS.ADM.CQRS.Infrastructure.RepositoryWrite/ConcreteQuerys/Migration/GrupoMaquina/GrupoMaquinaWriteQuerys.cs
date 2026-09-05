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
    public class GrupoMaquinaQueryWrite : QueryBase, IGrupoMaquinaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public GrupoMaquinaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina)
        {
            this.Query = $@" INSERT INTO [GrupoMaquina] ([Id], [Descricao], [Status], [TenantID], [Deleted], [Changed], [UserId], [GMA_TIPO_PLANEJAMENTO]) VALUES(@Id, @Descricao, @Status, @TenantID, @Deleted, @Changed, @UserId, @GMA_TIPO_PLANEJAMENTO) ";
            this.Parameters = new
            {
                Id = GrupoMaquina.Id,
                Descricao = GrupoMaquina.Descricao,
                Status = GrupoMaquina.Status,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                GMA_TIPO_PLANEJAMENTO = GrupoMaquina.GMA_TIPO_PLANEJAMENTO,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina)
        {
            this.Query = $@" UPDATE [GrupoMaquina] SET [Descricao] = @Descricao, [Status] = @Status, [Changed] = @Changed, [UserId] = @UserId, [GMA_TIPO_PLANEJAMENTO] = @GMA_TIPO_PLANEJAMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Descricao = GrupoMaquina.Descricao,
                Status = GrupoMaquina.Status,
                Changed = GrupoMaquina.Changed,
                UserId = _executionContext.UserId,
                GMA_TIPO_PLANEJAMENTO = GrupoMaquina.GMA_TIPO_PLANEJAMENTO,
                Id = GrupoMaquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(string id, string value)
        {
            this.Query = $@" UPDATE [GrupoMaquina] SET [Descricao] = @Descricao WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateStatus(string id, string value)
        {
            this.Query = $@" UPDATE [GrupoMaquina] SET [Status] = @Status WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Status = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string id, int value)
        {
            this.Query = $@" UPDATE [GrupoMaquina] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string id, bool value)
        {
            this.Query = $@" UPDATE [GrupoMaquina] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string id, DateTime value)
        {
            this.Query = $@" UPDATE [GrupoMaquina] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string id, int value)
        {
            this.Query = $@" UPDATE [GrupoMaquina] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_TIPO_PLANEJAMENTO(string id, string value)
        {
            this.Query = $@" UPDATE [GrupoMaquina] SET [GMA_TIPO_PLANEJAMENTO] = @GMA_TIPO_PLANEJAMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GMA_TIPO_PLANEJAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina)
        {
            this.Query = $@" DELETE FROM [GrupoMaquina] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = GrupoMaquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration