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
    public class TemposLogisticosQueryWrite : QueryBase, ITemposLogisticosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TemposLogisticosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTemposLogisticosQuery(ITemposLogisticosEntity TemposLogisticos)
        {
            this.Query = $@" INSERT INTO [TemposLogisticos] ([TMP_TIPO_TEMPO], [TMP_TIPO_CARGA], [TMP_TEMPO_MEDIO_UNITARIO], [CLI_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@TMP_TIPO_TEMPO, @TMP_TIPO_CARGA, @TMP_TEMPO_MEDIO_UNITARIO, @CLI_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TMP_TIPO_TEMPO = TemposLogisticos.TMP_TIPO_TEMPO,
                TMP_TIPO_CARGA = TemposLogisticos.TMP_TIPO_CARGA,
                TMP_TEMPO_MEDIO_UNITARIO = TemposLogisticos.TMP_TEMPO_MEDIO_UNITARIO,
                CLI_ID = TemposLogisticos.CLI_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTemposLogisticosQuery(ITemposLogisticosEntity TemposLogisticos)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [TMP_TIPO_TEMPO] = @TMP_TIPO_TEMPO, [TMP_TIPO_CARGA] = @TMP_TIPO_CARGA, [TMP_TEMPO_MEDIO_UNITARIO] = @TMP_TEMPO_MEDIO_UNITARIO, [CLI_ID] = @CLI_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TMP_TIPO_TEMPO = TemposLogisticos.TMP_TIPO_TEMPO,
                TMP_TIPO_CARGA = TemposLogisticos.TMP_TIPO_CARGA,
                TMP_TEMPO_MEDIO_UNITARIO = TemposLogisticos.TMP_TEMPO_MEDIO_UNITARIO,
                CLI_ID = TemposLogisticos.CLI_ID,
                Changed = TemposLogisticos.Changed,
                UserId = _executionContext.UserId,
                Id = TemposLogisticos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTMP_TIPO_TEMPO(int id, string value)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [TMP_TIPO_TEMPO] = @TMP_TIPO_TEMPO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TMP_TIPO_TEMPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTMP_TIPO_CARGA(int id, string value)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [TMP_TIPO_CARGA] = @TMP_TIPO_CARGA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TMP_TIPO_CARGA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTMP_TEMPO_MEDIO_UNITARIO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [TMP_TEMPO_MEDIO_UNITARIO] = @TMP_TEMPO_MEDIO_UNITARIO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TMP_TEMPO_MEDIO_UNITARIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(int id, string value)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [CLI_ID] = @CLI_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CLI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [TemposLogisticos] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTemposLogisticosQuery(ITemposLogisticosEntity TemposLogisticos)
        {
            this.Query = $@" DELETE FROM [TemposLogisticos] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = TemposLogisticos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration