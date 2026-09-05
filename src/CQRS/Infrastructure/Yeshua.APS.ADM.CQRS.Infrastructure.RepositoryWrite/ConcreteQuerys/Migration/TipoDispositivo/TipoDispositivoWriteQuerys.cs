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
    public class TipoDispositivoQueryWrite : QueryBase, ITipoDispositivoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoDispositivoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoDispositivoQuery(ITipoDispositivoEntity TipoDispositivo)
        {
            this.Query = $@" INSERT INTO [TipoDispositivo] ([TDI_ID], [TDI_DESCRICAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@TDI_ID, @TDI_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TDI_ID = TipoDispositivo.TDI_ID,
                TDI_DESCRICAO = TipoDispositivo.TDI_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoDispositivoQuery(ITipoDispositivoEntity TipoDispositivo)
        {
            this.Query = $@" UPDATE [TipoDispositivo] SET [TDI_ID] = @TDI_ID, [TDI_DESCRICAO] = @TDI_DESCRICAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TDI_ID = TipoDispositivo.TDI_ID,
                TDI_DESCRICAO = TipoDispositivo.TDI_DESCRICAO,
                Changed = TipoDispositivo.Changed,
                UserId = _executionContext.UserId,
                Id = TipoDispositivo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTDI_ID(int id, string value)
        {
            this.Query = $@" UPDATE [TipoDispositivo] SET [TDI_ID] = @TDI_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TDI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTDI_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [TipoDispositivo] SET [TDI_DESCRICAO] = @TDI_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TDI_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [TipoDispositivo] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [TipoDispositivo] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TipoDispositivo] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [TipoDispositivo] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoDispositivoQuery(ITipoDispositivoEntity TipoDispositivo)
        {
            this.Query = $@" DELETE FROM [TipoDispositivo] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = TipoDispositivo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration