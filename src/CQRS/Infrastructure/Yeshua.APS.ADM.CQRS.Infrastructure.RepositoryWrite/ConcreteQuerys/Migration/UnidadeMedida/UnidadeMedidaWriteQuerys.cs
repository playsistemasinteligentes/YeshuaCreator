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
    public class UnidadeMedidaQueryWrite : QueryBase, IUnidadeMedidaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public UnidadeMedidaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirUnidadeMedidaQuery(IUnidadeMedidaEntity UnidadeMedida)
        {
            this.Query = $@" INSERT INTO [UnidadeMedida] ([UNI_ID], [UNI_DESCRICAO], [UNI_ESCALA_TEMPO], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@UNI_ID, @UNI_DESCRICAO, @UNI_ESCALA_TEMPO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                UNI_ID = UnidadeMedida.UNI_ID,
                UNI_DESCRICAO = UnidadeMedida.UNI_DESCRICAO,
                UNI_ESCALA_TEMPO = UnidadeMedida.UNI_ESCALA_TEMPO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUnidadeMedidaQuery(IUnidadeMedidaEntity UnidadeMedida)
        {
            this.Query = $@" UPDATE [UnidadeMedida] SET [UNI_DESCRICAO] = @UNI_DESCRICAO, [UNI_ESCALA_TEMPO] = @UNI_ESCALA_TEMPO, [Changed] = @Changed, [UserId] = @UserId WHERE [UNI_ID] = @UNI_ID ";
            this.Parameters = new
            {
                UNI_DESCRICAO = UnidadeMedida.UNI_DESCRICAO,
                UNI_ESCALA_TEMPO = UnidadeMedida.UNI_ESCALA_TEMPO,
                Changed = UnidadeMedida.Changed,
                UserId = _executionContext.UserId,
                UNI_ID = UnidadeMedida.UNI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_DESCRICAO(string uni_id, string value)
        {
            this.Query = $@" UPDATE [UnidadeMedida] SET [UNI_DESCRICAO] = @UNI_DESCRICAO WHERE [UNI_ID] = @UNI_ID ";
            this.Parameters = new
            {
                UNI_DESCRICAO = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_ESCALA_TEMPO(string uni_id, string value)
        {
            this.Query = $@" UPDATE [UnidadeMedida] SET [UNI_ESCALA_TEMPO] = @UNI_ESCALA_TEMPO WHERE [UNI_ID] = @UNI_ID ";
            this.Parameters = new
            {
                UNI_ESCALA_TEMPO = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string uni_id, int value)
        {
            this.Query = $@" UPDATE [UnidadeMedida] SET [TenantID] = @TenantID WHERE [UNI_ID] = @UNI_ID ";
            this.Parameters = new
            {
                TenantID = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string uni_id, bool value)
        {
            this.Query = $@" UPDATE [UnidadeMedida] SET [Deleted] = @Deleted WHERE [UNI_ID] = @UNI_ID ";
            this.Parameters = new
            {
                Deleted = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string uni_id, DateTime value)
        {
            this.Query = $@" UPDATE [UnidadeMedida] SET [Changed] = @Changed WHERE [UNI_ID] = @UNI_ID ";
            this.Parameters = new
            {
                Changed = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string uni_id, int value)
        {
            this.Query = $@" UPDATE [UnidadeMedida] SET [UserId] = @UserId WHERE [UNI_ID] = @UNI_ID ";
            this.Parameters = new
            {
                UserId = value,
                UNI_ID = uni_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteUnidadeMedidaQuery(IUnidadeMedidaEntity UnidadeMedida)
        {
            this.Query = $@" DELETE FROM [UnidadeMedida] WHERE [UNI_ID] = @UNI_ID ";
            this.Parameters = new
            {
                UNI_ID = UnidadeMedida.UNI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration