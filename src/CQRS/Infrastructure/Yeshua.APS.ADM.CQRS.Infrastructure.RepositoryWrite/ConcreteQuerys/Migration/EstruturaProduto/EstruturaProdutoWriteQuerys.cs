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
    public class EstruturaProdutoQueryWrite : QueryBase, IEstruturaProdutoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EstruturaProdutoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEstruturaProdutoQuery(IEstruturaProdutoEntity EstruturaProduto)
        {
            this.Query = $@" INSERT INTO EstruturaProduto (EST_DATA_VALIDADE, PRO_ID_PRODUTO, PRO_ID_COMPONENTE, EST_QUANT, EST_DATA_INCLUSAO, EST_BASE_PRODUCAO, EST_TIPO_REQUISICAO, EST_CODIGO_DE_EXCECAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@EST_DATA_VALIDADE, @PRO_ID_PRODUTO, @PRO_ID_COMPONENTE, @EST_QUANT, @EST_DATA_INCLUSAO, @EST_BASE_PRODUCAO, @EST_TIPO_REQUISICAO, @EST_CODIGO_DE_EXCECAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                EST_DATA_VALIDADE = EstruturaProduto.EST_DATA_VALIDADE,
                PRO_ID_PRODUTO = EstruturaProduto.PRO_ID_PRODUTO,
                PRO_ID_COMPONENTE = EstruturaProduto.PRO_ID_COMPONENTE,
                EST_QUANT = EstruturaProduto.EST_QUANT,
                EST_DATA_INCLUSAO = EstruturaProduto.EST_DATA_INCLUSAO,
                EST_BASE_PRODUCAO = EstruturaProduto.EST_BASE_PRODUCAO,
                EST_TIPO_REQUISICAO = EstruturaProduto.EST_TIPO_REQUISICAO,
                EST_CODIGO_DE_EXCECAO = EstruturaProduto.EST_CODIGO_DE_EXCECAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEstruturaProdutoQuery(IEstruturaProdutoEntity EstruturaProduto)
        {
            this.Query = $@" UPDATE EstruturaProduto SET EST_DATA_VALIDADE = @EST_DATA_VALIDADE, PRO_ID_PRODUTO = @PRO_ID_PRODUTO, PRO_ID_COMPONENTE = @PRO_ID_COMPONENTE, EST_QUANT = @EST_QUANT, EST_DATA_INCLUSAO = @EST_DATA_INCLUSAO, EST_BASE_PRODUCAO = @EST_BASE_PRODUCAO, EST_TIPO_REQUISICAO = @EST_TIPO_REQUISICAO, EST_CODIGO_DE_EXCECAO = @EST_CODIGO_DE_EXCECAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_DATA_VALIDADE = EstruturaProduto.EST_DATA_VALIDADE,
                PRO_ID_PRODUTO = EstruturaProduto.PRO_ID_PRODUTO,
                PRO_ID_COMPONENTE = EstruturaProduto.PRO_ID_COMPONENTE,
                EST_QUANT = EstruturaProduto.EST_QUANT,
                EST_DATA_INCLUSAO = EstruturaProduto.EST_DATA_INCLUSAO,
                EST_BASE_PRODUCAO = EstruturaProduto.EST_BASE_PRODUCAO,
                EST_TIPO_REQUISICAO = EstruturaProduto.EST_TIPO_REQUISICAO,
                EST_CODIGO_DE_EXCECAO = EstruturaProduto.EST_CODIGO_DE_EXCECAO,
                Changed = EstruturaProduto.Changed,
                UserId = _executionContext.UserId,
                Id = EstruturaProduto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_DATA_VALIDADE(int id, DateTime value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET EST_DATA_VALIDADE = @EST_DATA_VALIDADE WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_DATA_VALIDADE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_PRODUTO(int id, string value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET PRO_ID_PRODUTO = @PRO_ID_PRODUTO WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_PRODUTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_COMPONENTE(int id, string value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET PRO_ID_COMPONENTE = @PRO_ID_COMPONENTE WHERE Id = @Id ";
            this.Parameters = new
            {
                PRO_ID_COMPONENTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_QUANT(int id, Decimal value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET EST_QUANT = @EST_QUANT WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_QUANT = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_DATA_INCLUSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET EST_DATA_INCLUSAO = @EST_DATA_INCLUSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_DATA_INCLUSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_BASE_PRODUCAO(int id, Decimal value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET EST_BASE_PRODUCAO = @EST_BASE_PRODUCAO WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_BASE_PRODUCAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_TIPO_REQUISICAO(int id, string value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET EST_TIPO_REQUISICAO = @EST_TIPO_REQUISICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_TIPO_REQUISICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEST_CODIGO_DE_EXCECAO(int id, string value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET EST_CODIGO_DE_EXCECAO = @EST_CODIGO_DE_EXCECAO WHERE Id = @Id ";
            this.Parameters = new
            {
                EST_CODIGO_DE_EXCECAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE EstruturaProduto SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEstruturaProdutoQuery(IEstruturaProdutoEntity EstruturaProduto)
        {
            this.Query = $@" DELETE FROM EstruturaProduto WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = EstruturaProduto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration