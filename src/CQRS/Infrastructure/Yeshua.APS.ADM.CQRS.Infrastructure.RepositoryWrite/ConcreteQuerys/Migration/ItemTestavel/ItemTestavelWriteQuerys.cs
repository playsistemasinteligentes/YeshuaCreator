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
    public class ItemTestavelQueryWrite : QueryBase, IItemTestavelQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ItemTestavelQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirItemTestavelQuery(IItemTestavelEntity ItemTestavel)
        {
            this.Query = $@" INSERT INTO [ItemTestavel] ([ITE_ID], [ITE_DESCRICAO], [ITE_OBS], [ITE_NUMERO_DE_TESTES], [ITE_CONDICIONAL_DE_AVALIACAO], [ITE_VALOR_DA_CONDICIONAL], [ITE_VALOR_CALCULADO_DA_CONDICIONAL], [ITE_TIPO_AVALIACAO_FINAL], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@ITE_ID, @ITE_DESCRICAO, @ITE_OBS, @ITE_NUMERO_DE_TESTES, @ITE_CONDICIONAL_DE_AVALIACAO, @ITE_VALOR_DA_CONDICIONAL, @ITE_VALOR_CALCULADO_DA_CONDICIONAL, @ITE_TIPO_AVALIACAO_FINAL, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ITE_ID = ItemTestavel.ITE_ID,
                ITE_DESCRICAO = ItemTestavel.ITE_DESCRICAO,
                ITE_OBS = ItemTestavel.ITE_OBS,
                ITE_NUMERO_DE_TESTES = ItemTestavel.ITE_NUMERO_DE_TESTES,
                ITE_CONDICIONAL_DE_AVALIACAO = ItemTestavel.ITE_CONDICIONAL_DE_AVALIACAO,
                ITE_VALOR_DA_CONDICIONAL = ItemTestavel.ITE_VALOR_DA_CONDICIONAL,
                ITE_VALOR_CALCULADO_DA_CONDICIONAL = ItemTestavel.ITE_VALOR_CALCULADO_DA_CONDICIONAL,
                ITE_TIPO_AVALIACAO_FINAL = ItemTestavel.ITE_TIPO_AVALIACAO_FINAL,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateItemTestavelQuery(IItemTestavelEntity ItemTestavel)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_ID] = @ITE_ID, [ITE_DESCRICAO] = @ITE_DESCRICAO, [ITE_OBS] = @ITE_OBS, [ITE_NUMERO_DE_TESTES] = @ITE_NUMERO_DE_TESTES, [ITE_CONDICIONAL_DE_AVALIACAO] = @ITE_CONDICIONAL_DE_AVALIACAO, [ITE_VALOR_DA_CONDICIONAL] = @ITE_VALOR_DA_CONDICIONAL, [ITE_VALOR_CALCULADO_DA_CONDICIONAL] = @ITE_VALOR_CALCULADO_DA_CONDICIONAL, [ITE_TIPO_AVALIACAO_FINAL] = @ITE_TIPO_AVALIACAO_FINAL, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_ID = ItemTestavel.ITE_ID,
                ITE_DESCRICAO = ItemTestavel.ITE_DESCRICAO,
                ITE_OBS = ItemTestavel.ITE_OBS,
                ITE_NUMERO_DE_TESTES = ItemTestavel.ITE_NUMERO_DE_TESTES,
                ITE_CONDICIONAL_DE_AVALIACAO = ItemTestavel.ITE_CONDICIONAL_DE_AVALIACAO,
                ITE_VALOR_DA_CONDICIONAL = ItemTestavel.ITE_VALOR_DA_CONDICIONAL,
                ITE_VALOR_CALCULADO_DA_CONDICIONAL = ItemTestavel.ITE_VALOR_CALCULADO_DA_CONDICIONAL,
                ITE_TIPO_AVALIACAO_FINAL = ItemTestavel.ITE_TIPO_AVALIACAO_FINAL,
                Changed = ItemTestavel.Changed,
                UserId = _executionContext.UserId,
                Id = ItemTestavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_ID(int id, int value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_ID] = @ITE_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_DESCRICAO] = @ITE_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_OBS(int id, string value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_OBS] = @ITE_OBS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_OBS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_NUMERO_DE_TESTES(int id, int value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_NUMERO_DE_TESTES] = @ITE_NUMERO_DE_TESTES WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_NUMERO_DE_TESTES = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_CONDICIONAL_DE_AVALIACAO(int id, string value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_CONDICIONAL_DE_AVALIACAO] = @ITE_CONDICIONAL_DE_AVALIACAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_CONDICIONAL_DE_AVALIACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_VALOR_DA_CONDICIONAL(int id, Decimal value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_VALOR_DA_CONDICIONAL] = @ITE_VALOR_DA_CONDICIONAL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_VALOR_DA_CONDICIONAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_VALOR_CALCULADO_DA_CONDICIONAL(int id, string value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_VALOR_CALCULADO_DA_CONDICIONAL] = @ITE_VALOR_CALCULADO_DA_CONDICIONAL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_VALOR_CALCULADO_DA_CONDICIONAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_TIPO_AVALIACAO_FINAL(int id, string value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [ITE_TIPO_AVALIACAO_FINAL] = @ITE_TIPO_AVALIACAO_FINAL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_TIPO_AVALIACAO_FINAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [ItemTestavel] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteItemTestavelQuery(IItemTestavelEntity ItemTestavel)
        {
            this.Query = $@" DELETE FROM [ItemTestavel] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = ItemTestavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration