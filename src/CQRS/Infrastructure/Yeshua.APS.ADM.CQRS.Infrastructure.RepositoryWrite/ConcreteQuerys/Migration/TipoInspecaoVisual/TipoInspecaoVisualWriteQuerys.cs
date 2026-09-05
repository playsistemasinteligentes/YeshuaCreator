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
    public class TipoInspecaoVisualQueryWrite : QueryBase, ITipoInspecaoVisualQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoInspecaoVisualQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoInspecaoVisualQuery(ITipoInspecaoVisualEntity TipoInspecaoVisual)
        {
            this.Query = $@" INSERT INTO [TipoInspecaoVisual] ([TIV_ID], [TenantID], [Deleted], [Changed], [UserId], [TIV_NOME], [TIV_DESCRICAO], [TIV_FECHAMENTO], [TIV_AMOSTRA_ALEATORIA], [TIV_N_AMOSTRAS], [TIV_MEDIDA], [TIV_ESPECIFICACAO], [TIV_TOL_MAIS], [TIV_TOL_MENOS]) OUTPUT INSERTED.[Id] VALUES(@TIV_ID, @TenantID, @Deleted, @Changed, @UserId, @TIV_NOME, @TIV_DESCRICAO, @TIV_FECHAMENTO, @TIV_AMOSTRA_ALEATORIA, @TIV_N_AMOSTRAS, @TIV_MEDIDA, @TIV_ESPECIFICACAO, @TIV_TOL_MAIS, @TIV_TOL_MENOS) ";
            this.Parameters = new
            {
                TIV_ID = TipoInspecaoVisual.TIV_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
                TIV_NOME = TipoInspecaoVisual.TIV_NOME,
                TIV_DESCRICAO = TipoInspecaoVisual.TIV_DESCRICAO,
                TIV_FECHAMENTO = TipoInspecaoVisual.TIV_FECHAMENTO,
                TIV_AMOSTRA_ALEATORIA = TipoInspecaoVisual.TIV_AMOSTRA_ALEATORIA,
                TIV_N_AMOSTRAS = TipoInspecaoVisual.TIV_N_AMOSTRAS,
                TIV_MEDIDA = TipoInspecaoVisual.TIV_MEDIDA,
                TIV_ESPECIFICACAO = TipoInspecaoVisual.TIV_ESPECIFICACAO,
                TIV_TOL_MAIS = TipoInspecaoVisual.TIV_TOL_MAIS,
                TIV_TOL_MENOS = TipoInspecaoVisual.TIV_TOL_MENOS,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoInspecaoVisualQuery(ITipoInspecaoVisualEntity TipoInspecaoVisual)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_ID] = @TIV_ID, [Changed] = @Changed, [UserId] = @UserId, [TIV_NOME] = @TIV_NOME, [TIV_DESCRICAO] = @TIV_DESCRICAO, [TIV_FECHAMENTO] = @TIV_FECHAMENTO, [TIV_AMOSTRA_ALEATORIA] = @TIV_AMOSTRA_ALEATORIA, [TIV_N_AMOSTRAS] = @TIV_N_AMOSTRAS, [TIV_MEDIDA] = @TIV_MEDIDA, [TIV_ESPECIFICACAO] = @TIV_ESPECIFICACAO, [TIV_TOL_MAIS] = @TIV_TOL_MAIS, [TIV_TOL_MENOS] = @TIV_TOL_MENOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_ID = TipoInspecaoVisual.TIV_ID,
                Changed = TipoInspecaoVisual.Changed,
                UserId = _executionContext.UserId,
                TIV_NOME = TipoInspecaoVisual.TIV_NOME,
                TIV_DESCRICAO = TipoInspecaoVisual.TIV_DESCRICAO,
                TIV_FECHAMENTO = TipoInspecaoVisual.TIV_FECHAMENTO,
                TIV_AMOSTRA_ALEATORIA = TipoInspecaoVisual.TIV_AMOSTRA_ALEATORIA,
                TIV_N_AMOSTRAS = TipoInspecaoVisual.TIV_N_AMOSTRAS,
                TIV_MEDIDA = TipoInspecaoVisual.TIV_MEDIDA,
                TIV_ESPECIFICACAO = TipoInspecaoVisual.TIV_ESPECIFICACAO,
                TIV_TOL_MAIS = TipoInspecaoVisual.TIV_TOL_MAIS,
                TIV_TOL_MENOS = TipoInspecaoVisual.TIV_TOL_MENOS,
                Id = TipoInspecaoVisual.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_ID(int id, int value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_ID] = @TIV_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_NOME(int id, string value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_NOME] = @TIV_NOME WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_NOME = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_DESCRICAO] = @TIV_DESCRICAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_FECHAMENTO(int id, string value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_FECHAMENTO] = @TIV_FECHAMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_FECHAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_AMOSTRA_ALEATORIA(int id, string value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_AMOSTRA_ALEATORIA] = @TIV_AMOSTRA_ALEATORIA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_AMOSTRA_ALEATORIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_N_AMOSTRAS(int id, int value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_N_AMOSTRAS] = @TIV_N_AMOSTRAS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_N_AMOSTRAS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_MEDIDA(int id, string value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_MEDIDA] = @TIV_MEDIDA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_MEDIDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_ESPECIFICACAO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_ESPECIFICACAO] = @TIV_ESPECIFICACAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_ESPECIFICACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_TOL_MAIS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_TOL_MAIS] = @TIV_TOL_MAIS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_TOL_MAIS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_TOL_MENOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [TipoInspecaoVisual] SET [TIV_TOL_MENOS] = @TIV_TOL_MENOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIV_TOL_MENOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoInspecaoVisualQuery(ITipoInspecaoVisualEntity TipoInspecaoVisual)
        {
            this.Query = $@" DELETE FROM [TipoInspecaoVisual] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = TipoInspecaoVisual.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration