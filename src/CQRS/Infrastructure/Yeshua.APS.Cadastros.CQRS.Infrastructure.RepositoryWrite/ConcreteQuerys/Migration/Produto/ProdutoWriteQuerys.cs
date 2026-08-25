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
    public class ProdutoQueryWrite : QueryBase, IProdutoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ProdutoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirProdutoQuery(IProdutoEntity Produto)
        {
            this.Query = $@" INSERT INTO Produto (PRO_ID, PRO_DESCRICAO, PRO_STATUS, TenantID, Deleted, Changed, UserId) VALUES(@PRO_ID, @PRO_DESCRICAO, @PRO_STATUS, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PRO_ID = Produto.PRO_ID,
                PRO_DESCRICAO = Produto.PRO_DESCRICAO,
                PRO_STATUS = Produto.PRO_STATUS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateProdutoQuery(IProdutoEntity Produto)
        {
            this.Query = $@" UPDATE Produto SET PRO_DESCRICAO = @PRO_DESCRICAO, PRO_STATUS = @PRO_STATUS, Changed = @Changed, UserId = @UserId WHERE PRO_ID = @PRO_ID ";
            this.Parameters = new
            {
                PRO_DESCRICAO = Produto.PRO_DESCRICAO,
                PRO_STATUS = Produto.PRO_STATUS,
                Changed = Produto.Changed,
                UserId = _executionContext.UserId,
                PRO_ID = Produto.PRO_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_DESCRICAO(string pro_id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_DESCRICAO = @PRO_DESCRICAO WHERE PRO_ID = @PRO_ID ";
            this.Parameters = new
            {
                PRO_DESCRICAO = value,
                PRO_ID = pro_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_STATUS(string pro_id, string value)
        {
            this.Query = $@" UPDATE Produto SET PRO_STATUS = @PRO_STATUS WHERE PRO_ID = @PRO_ID ";
            this.Parameters = new
            {
                PRO_STATUS = value,
                PRO_ID = pro_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string pro_id, int value)
        {
            this.Query = $@" UPDATE Produto SET TenantID = @TenantID WHERE PRO_ID = @PRO_ID ";
            this.Parameters = new
            {
                TenantID = value,
                PRO_ID = pro_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string pro_id, bool value)
        {
            this.Query = $@" UPDATE Produto SET Deleted = @Deleted WHERE PRO_ID = @PRO_ID ";
            this.Parameters = new
            {
                Deleted = value,
                PRO_ID = pro_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string pro_id, DateTime value)
        {
            this.Query = $@" UPDATE Produto SET Changed = @Changed WHERE PRO_ID = @PRO_ID ";
            this.Parameters = new
            {
                Changed = value,
                PRO_ID = pro_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string pro_id, int value)
        {
            this.Query = $@" UPDATE Produto SET UserId = @UserId WHERE PRO_ID = @PRO_ID ";
            this.Parameters = new
            {
                UserId = value,
                PRO_ID = pro_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteProdutoQuery(IProdutoEntity Produto)
        {
            this.Query = $@" DELETE FROM Produto WHERE PRO_ID = @PRO_ID ";
            this.Parameters = new
            {
                PRO_ID = Produto.PRO_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration