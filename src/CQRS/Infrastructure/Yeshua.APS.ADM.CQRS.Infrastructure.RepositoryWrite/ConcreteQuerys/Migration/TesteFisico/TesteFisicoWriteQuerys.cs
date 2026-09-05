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
    public class TesteFisicoQueryWrite : QueryBase, ITesteFisicoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TesteFisicoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTesteFisicoQuery(ITesteFisicoEntity TesteFisico)
        {
            this.Query = $@" INSERT INTO [TesteFisico] ([TES_ID], [ITE_ID], [USR_ID], [TES_NOME_TECNICO], [TES_AMOSTRA], [TES_OP], [TES_VALOR_NUMERICO], [TES_VALOR_DATA], [TES_VALOR_TEXTO], [TES_EMISSAO], [ORD_ID], [PRO_ID], [MAQ_ID], [FPR_SEQ_REPETICAO], [FPR_SEQ_TRANFORMACAO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@TES_ID, @ITE_ID, @USR_ID, @TES_NOME_TECNICO, @TES_AMOSTRA, @TES_OP, @TES_VALOR_NUMERICO, @TES_VALOR_DATA, @TES_VALOR_TEXTO, @TES_EMISSAO, @ORD_ID, @PRO_ID, @MAQ_ID, @FPR_SEQ_REPETICAO, @FPR_SEQ_TRANFORMACAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TES_ID = TesteFisico.TES_ID,
                ITE_ID = TesteFisico.ITE_ID,
                USR_ID = TesteFisico.USR_ID,
                TES_NOME_TECNICO = TesteFisico.TES_NOME_TECNICO,
                TES_AMOSTRA = TesteFisico.TES_AMOSTRA,
                TES_OP = TesteFisico.TES_OP,
                TES_VALOR_NUMERICO = TesteFisico.TES_VALOR_NUMERICO,
                TES_VALOR_DATA = TesteFisico.TES_VALOR_DATA,
                TES_VALOR_TEXTO = TesteFisico.TES_VALOR_TEXTO,
                TES_EMISSAO = TesteFisico.TES_EMISSAO,
                ORD_ID = TesteFisico.ORD_ID,
                PRO_ID = TesteFisico.PRO_ID,
                MAQ_ID = TesteFisico.MAQ_ID,
                FPR_SEQ_REPETICAO = TesteFisico.FPR_SEQ_REPETICAO,
                FPR_SEQ_TRANFORMACAO = TesteFisico.FPR_SEQ_TRANFORMACAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTesteFisicoQuery(ITesteFisicoEntity TesteFisico)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_ID] = @TES_ID, [ITE_ID] = @ITE_ID, [USR_ID] = @USR_ID, [TES_NOME_TECNICO] = @TES_NOME_TECNICO, [TES_AMOSTRA] = @TES_AMOSTRA, [TES_OP] = @TES_OP, [TES_VALOR_NUMERICO] = @TES_VALOR_NUMERICO, [TES_VALOR_DATA] = @TES_VALOR_DATA, [TES_VALOR_TEXTO] = @TES_VALOR_TEXTO, [TES_EMISSAO] = @TES_EMISSAO, [ORD_ID] = @ORD_ID, [PRO_ID] = @PRO_ID, [MAQ_ID] = @MAQ_ID, [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO, [FPR_SEQ_TRANFORMACAO] = @FPR_SEQ_TRANFORMACAO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_ID = TesteFisico.TES_ID,
                ITE_ID = TesteFisico.ITE_ID,
                USR_ID = TesteFisico.USR_ID,
                TES_NOME_TECNICO = TesteFisico.TES_NOME_TECNICO,
                TES_AMOSTRA = TesteFisico.TES_AMOSTRA,
                TES_OP = TesteFisico.TES_OP,
                TES_VALOR_NUMERICO = TesteFisico.TES_VALOR_NUMERICO,
                TES_VALOR_DATA = TesteFisico.TES_VALOR_DATA,
                TES_VALOR_TEXTO = TesteFisico.TES_VALOR_TEXTO,
                TES_EMISSAO = TesteFisico.TES_EMISSAO,
                ORD_ID = TesteFisico.ORD_ID,
                PRO_ID = TesteFisico.PRO_ID,
                MAQ_ID = TesteFisico.MAQ_ID,
                FPR_SEQ_REPETICAO = TesteFisico.FPR_SEQ_REPETICAO,
                FPR_SEQ_TRANFORMACAO = TesteFisico.FPR_SEQ_TRANFORMACAO,
                Changed = TesteFisico.Changed,
                UserId = _executionContext.UserId,
                Id = TesteFisico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_ID(int id, int value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_ID] = @TES_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITE_ID(int id, int value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [ITE_ID] = @ITE_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITE_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSR_ID(int id, int value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [USR_ID] = @USR_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                USR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_NOME_TECNICO(int id, string value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_NOME_TECNICO] = @TES_NOME_TECNICO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_NOME_TECNICO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_AMOSTRA(int id, int value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_AMOSTRA] = @TES_AMOSTRA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_AMOSTRA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_OP(int id, string value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_OP] = @TES_OP WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_OP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_VALOR_NUMERICO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_VALOR_NUMERICO] = @TES_VALOR_NUMERICO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_VALOR_NUMERICO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_VALOR_DATA(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_VALOR_DATA] = @TES_VALOR_DATA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_VALOR_DATA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_VALOR_TEXTO(int id, string value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_VALOR_TEXTO] = @TES_VALOR_TEXTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_VALOR_TEXTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTES_EMISSAO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TES_EMISSAO] = @TES_EMISSAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TES_EMISSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [ORD_ID] = @ORD_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [PRO_ID] = @PRO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int id, string value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [MAQ_ID] = @MAQ_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                MAQ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int id, int value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_TRANFORMACAO(int id, int value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [FPR_SEQ_TRANFORMACAO] = @FPR_SEQ_TRANFORMACAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                FPR_SEQ_TRANFORMACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [TesteFisico] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTesteFisicoQuery(ITesteFisicoEntity TesteFisico)
        {
            this.Query = $@" DELETE FROM [TesteFisico] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = TesteFisico.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration