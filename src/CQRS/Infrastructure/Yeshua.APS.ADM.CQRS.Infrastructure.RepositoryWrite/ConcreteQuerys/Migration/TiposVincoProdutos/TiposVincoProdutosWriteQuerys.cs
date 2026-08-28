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
    public class TiposVincoProdutosQueryWrite : QueryBase, ITiposVincoProdutosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TiposVincoProdutosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTiposVincoProdutosQuery(ITiposVincoProdutosEntity TiposVincoProdutos)
        {
            this.Query = $@" INSERT INTO TiposVincoProdutos (Id2, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@Id2, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id2 = TiposVincoProdutos.Id2,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTiposVincoProdutosQuery(ITiposVincoProdutosEntity TiposVincoProdutos)
        {
            this.Query = $@" UPDATE TiposVincoProdutos SET Id2 = @Id2, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Id2 = TiposVincoProdutos.Id2,
                Changed = TiposVincoProdutos.Changed,
                UserId = _executionContext.UserId,
                Id = TiposVincoProdutos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateId2(int id, int value)
        {
            this.Query = $@" UPDATE TiposVincoProdutos SET Id2 = @Id2 WHERE Id = @Id ";
            this.Parameters = new
            {
                Id2 = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE TiposVincoProdutos SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE TiposVincoProdutos SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE TiposVincoProdutos SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE TiposVincoProdutos SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTiposVincoProdutosQuery(ITiposVincoProdutosEntity TiposVincoProdutos)
        {
            this.Query = $@" DELETE FROM TiposVincoProdutos WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = TiposVincoProdutos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration