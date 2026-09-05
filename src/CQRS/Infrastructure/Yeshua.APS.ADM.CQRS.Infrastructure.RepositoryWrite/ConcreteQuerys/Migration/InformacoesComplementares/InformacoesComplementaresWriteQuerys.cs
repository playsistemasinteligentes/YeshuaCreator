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
    public class InformacoesComplementaresQueryWrite : QueryBase, IInformacoesComplementaresQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public InformacoesComplementaresQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirInformacoesComplementaresQuery(IInformacoesComplementaresEntity InformacoesComplementares)
        {
            this.Query = $@" INSERT INTO [InformacoesComplementares] ([INF_DESCRICAO], [INF_VALOR], [MET_ID], [INF_DATA], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[INF_ID] VALUES(@INF_DESCRICAO, @INF_VALOR, @MET_ID, @INF_DATA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                INF_DESCRICAO = InformacoesComplementares.INF_DESCRICAO,
                INF_VALOR = InformacoesComplementares.INF_VALOR,
                MET_ID = InformacoesComplementares.MET_ID,
                INF_DATA = InformacoesComplementares.INF_DATA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateInformacoesComplementaresQuery(IInformacoesComplementaresEntity InformacoesComplementares)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [INF_DESCRICAO] = @INF_DESCRICAO, [INF_VALOR] = @INF_VALOR, [MET_ID] = @MET_ID, [INF_DATA] = @INF_DATA, [Changed] = @Changed, [UserId] = @UserId WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                INF_DESCRICAO = InformacoesComplementares.INF_DESCRICAO,
                INF_VALOR = InformacoesComplementares.INF_VALOR,
                MET_ID = InformacoesComplementares.MET_ID,
                INF_DATA = InformacoesComplementares.INF_DATA,
                Changed = InformacoesComplementares.Changed,
                UserId = _executionContext.UserId,
                INF_ID = InformacoesComplementares.INF_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateINF_DESCRICAO(int inf_id, string value)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [INF_DESCRICAO] = @INF_DESCRICAO WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                INF_DESCRICAO = value,
                INF_ID = inf_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateINF_VALOR(int inf_id, Decimal value)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [INF_VALOR] = @INF_VALOR WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                INF_VALOR = value,
                INF_ID = inf_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_ID(int inf_id, int value)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [MET_ID] = @MET_ID WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                MET_ID = value,
                INF_ID = inf_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateINF_DATA(int inf_id, string value)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [INF_DATA] = @INF_DATA WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                INF_DATA = value,
                INF_ID = inf_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int inf_id, int value)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [TenantID] = @TenantID WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                TenantID = value,
                INF_ID = inf_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int inf_id, bool value)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [Deleted] = @Deleted WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                Deleted = value,
                INF_ID = inf_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int inf_id, DateTime value)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [Changed] = @Changed WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                Changed = value,
                INF_ID = inf_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int inf_id, int value)
        {
            this.Query = $@" UPDATE [InformacoesComplementares] SET [UserId] = @UserId WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                UserId = value,
                INF_ID = inf_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteInformacoesComplementaresQuery(IInformacoesComplementaresEntity InformacoesComplementares)
        {
            this.Query = $@" DELETE FROM [InformacoesComplementares] WHERE [INF_ID] = @INF_ID ";
            this.Parameters = new
            {
                INF_ID = InformacoesComplementares.INF_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration