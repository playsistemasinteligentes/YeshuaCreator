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
    public class SegmentosProdutosQueryWrite : QueryBase, ISegmentosProdutosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public SegmentosProdutosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirSegmentosProdutosQuery(ISegmentosProdutosEntity SegmentosProdutos)
        {
            this.Query = $@" INSERT INTO [SegmentosProdutos] ([GRS_ID], [PRO_ID], [SEG_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@GRS_ID, @PRO_ID, @SEG_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GRS_ID = SegmentosProdutos.GRS_ID,
                PRO_ID = SegmentosProdutos.PRO_ID,
                SEG_ID = SegmentosProdutos.SEG_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSegmentosProdutosQuery(ISegmentosProdutosEntity SegmentosProdutos)
        {
            this.Query = $@" UPDATE [SegmentosProdutos] SET [GRS_ID] = @GRS_ID, [PRO_ID] = @PRO_ID, [SEG_ID] = @SEG_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRS_ID = SegmentosProdutos.GRS_ID,
                PRO_ID = SegmentosProdutos.PRO_ID,
                SEG_ID = SegmentosProdutos.SEG_ID,
                Changed = SegmentosProdutos.Changed,
                UserId = _executionContext.UserId,
                Id = SegmentosProdutos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRS_ID(int id, string value)
        {
            this.Query = $@" UPDATE [SegmentosProdutos] SET [GRS_ID] = @GRS_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRS_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [SegmentosProdutos] SET [PRO_ID] = @PRO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEG_ID(int id, string value)
        {
            this.Query = $@" UPDATE [SegmentosProdutos] SET [SEG_ID] = @SEG_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                SEG_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [SegmentosProdutos] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [SegmentosProdutos] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [SegmentosProdutos] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [SegmentosProdutos] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteSegmentosProdutosQuery(ISegmentosProdutosEntity SegmentosProdutos)
        {
            this.Query = $@" DELETE FROM [SegmentosProdutos] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = SegmentosProdutos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration