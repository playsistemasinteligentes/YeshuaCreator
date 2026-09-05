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
    public class ItensEstruturaImpressaoQueryWrite : QueryBase, IItensEstruturaImpressaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ItensEstruturaImpressaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirItensEstruturaImpressaoQuery(IItensEstruturaImpressaoEntity ItensEstruturaImpressao)
        {
            this.Query = $@" INSERT INTO [ItensEstruturaImpressao] ([IES_CUSTOM_FONT_SIZE], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@IES_CUSTOM_FONT_SIZE, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IES_CUSTOM_FONT_SIZE = ItensEstruturaImpressao.IES_CUSTOM_FONT_SIZE,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateItensEstruturaImpressaoQuery(IItensEstruturaImpressaoEntity ItensEstruturaImpressao)
        {
            this.Query = $@" UPDATE [ItensEstruturaImpressao] SET [IES_CUSTOM_FONT_SIZE] = @IES_CUSTOM_FONT_SIZE, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                IES_CUSTOM_FONT_SIZE = ItensEstruturaImpressao.IES_CUSTOM_FONT_SIZE,
                Changed = ItensEstruturaImpressao.Changed,
                UserId = _executionContext.UserId,
                Id = ItensEstruturaImpressao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIES_CUSTOM_FONT_SIZE(int id, int value)
        {
            this.Query = $@" UPDATE [ItensEstruturaImpressao] SET [IES_CUSTOM_FONT_SIZE] = @IES_CUSTOM_FONT_SIZE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                IES_CUSTOM_FONT_SIZE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ItensEstruturaImpressao] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ItensEstruturaImpressao] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItensEstruturaImpressao] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ItensEstruturaImpressao] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteItensEstruturaImpressaoQuery(IItensEstruturaImpressaoEntity ItensEstruturaImpressao)
        {
            this.Query = $@" DELETE FROM [ItensEstruturaImpressao] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ItensEstruturaImpressao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration