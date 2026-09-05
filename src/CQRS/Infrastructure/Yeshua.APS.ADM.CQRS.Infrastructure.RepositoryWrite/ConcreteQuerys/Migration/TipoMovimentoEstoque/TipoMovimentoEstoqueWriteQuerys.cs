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
    public class TipoMovimentoEstoqueQueryWrite : QueryBase, ITipoMovimentoEstoqueQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoMovimentoEstoqueQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoMovimentoEstoqueQuery(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque)
        {
            this.Query = $@" INSERT INTO [TipoMovimentoEstoque] ([TIP_ID], [TIP_DESCRICAO], [TIP_TYPE], [SPR], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@TIP_ID, @TIP_DESCRICAO, @TIP_TYPE, @SPR, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TIP_ID = TipoMovimentoEstoque.TIP_ID,
                TIP_DESCRICAO = TipoMovimentoEstoque.TIP_DESCRICAO,
                TIP_TYPE = TipoMovimentoEstoque.TIP_TYPE,
                SPR = TipoMovimentoEstoque.SPR,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoMovimentoEstoqueQuery(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque)
        {
            this.Query = $@" UPDATE [TipoMovimentoEstoque] SET [TIP_DESCRICAO] = @TIP_DESCRICAO, [TIP_TYPE] = @TIP_TYPE, [SPR] = @SPR, [Changed] = @Changed, [UserId] = @UserId WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                TIP_DESCRICAO = TipoMovimentoEstoque.TIP_DESCRICAO,
                TIP_TYPE = TipoMovimentoEstoque.TIP_TYPE,
                SPR = TipoMovimentoEstoque.SPR,
                Changed = TipoMovimentoEstoque.Changed,
                UserId = _executionContext.UserId,
                TIP_ID = TipoMovimentoEstoque.TIP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_DESCRICAO(string tip_id, string value)
        {
            this.Query = $@" UPDATE [TipoMovimentoEstoque] SET [TIP_DESCRICAO] = @TIP_DESCRICAO WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                TIP_DESCRICAO = value,
                TIP_ID = tip_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_TYPE(string tip_id, int value)
        {
            this.Query = $@" UPDATE [TipoMovimentoEstoque] SET [TIP_TYPE] = @TIP_TYPE WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                TIP_TYPE = value,
                TIP_ID = tip_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSPR(string tip_id, int value)
        {
            this.Query = $@" UPDATE [TipoMovimentoEstoque] SET [SPR] = @SPR WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                SPR = value,
                TIP_ID = tip_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string tip_id, int value)
        {
            this.Query = $@" UPDATE [TipoMovimentoEstoque] SET [TenantID] = @TenantID WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                TenantID = value,
                TIP_ID = tip_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string tip_id, bool value)
        {
            this.Query = $@" UPDATE [TipoMovimentoEstoque] SET [Deleted] = @Deleted WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                Deleted = value,
                TIP_ID = tip_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string tip_id, DateTime value)
        {
            this.Query = $@" UPDATE [TipoMovimentoEstoque] SET [Changed] = @Changed WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                Changed = value,
                TIP_ID = tip_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string tip_id, int value)
        {
            this.Query = $@" UPDATE [TipoMovimentoEstoque] SET [UserId] = @UserId WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                UserId = value,
                TIP_ID = tip_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoMovimentoEstoqueQuery(ITipoMovimentoEstoqueEntity TipoMovimentoEstoque)
        {
            this.Query = $@" DELETE FROM [TipoMovimentoEstoque] WHERE [TIP_ID] = @TIP_ID ";
            this.Parameters = new
            {
                TIP_ID = TipoMovimentoEstoque.TIP_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration