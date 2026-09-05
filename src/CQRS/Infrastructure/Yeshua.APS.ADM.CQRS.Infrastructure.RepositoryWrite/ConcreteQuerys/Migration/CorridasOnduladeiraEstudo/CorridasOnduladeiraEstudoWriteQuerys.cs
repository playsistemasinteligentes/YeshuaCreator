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
    public class CorridasOnduladeiraEstudoQueryWrite : QueryBase, ICorridasOnduladeiraEstudoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CorridasOnduladeiraEstudoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCorridasOnduladeiraEstudoQuery(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo)
        {
            this.Query = $@" INSERT INTO [CorridasOnduladeiraEstudo] ([BOL_ID], [BOL_ID_ORIGEM], [PRO_LARGURA_PECA], [PRO_LARGURA_PECA_PROGRAMADO], [PRO_COMPRIMENTO_PECA], [PRO_COMPRIMENTO_PECA_PROGRAMADO], [PRO_UTILIZOU_REFILE_OBRIGATORIO], [PRO_VINCOS_RECALCULADOS], [COR_SOLVER], [COR_GRAMATURA_PAPEIS_PROGRAMADOS], [COR_CUSTO_PAPEIS_PROGRAMADOS], [COR_GRAMATURA_RESINA_PROGRAMADOS], [COR_CUSTO_RESINA_PROGRAMADOS], [COR_TOLERANCIA_MENOS], [COR_TOLERANCIA_MAIS], [COR_PILHAS_POR_PALETE], [COR_M_LINEAR_REALIZADO], [PRO_ID_PALETE], [COR_STATUS_PALETE], [COR_GRUPO_PRODUTIVO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@BOL_ID, @BOL_ID_ORIGEM, @PRO_LARGURA_PECA, @PRO_LARGURA_PECA_PROGRAMADO, @PRO_COMPRIMENTO_PECA, @PRO_COMPRIMENTO_PECA_PROGRAMADO, @PRO_UTILIZOU_REFILE_OBRIGATORIO, @PRO_VINCOS_RECALCULADOS, @COR_SOLVER, @COR_GRAMATURA_PAPEIS_PROGRAMADOS, @COR_CUSTO_PAPEIS_PROGRAMADOS, @COR_GRAMATURA_RESINA_PROGRAMADOS, @COR_CUSTO_RESINA_PROGRAMADOS, @COR_TOLERANCIA_MENOS, @COR_TOLERANCIA_MAIS, @COR_PILHAS_POR_PALETE, @COR_M_LINEAR_REALIZADO, @PRO_ID_PALETE, @COR_STATUS_PALETE, @COR_GRUPO_PRODUTIVO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                BOL_ID = CorridasOnduladeiraEstudo.BOL_ID,
                BOL_ID_ORIGEM = CorridasOnduladeiraEstudo.BOL_ID_ORIGEM,
                PRO_LARGURA_PECA = CorridasOnduladeiraEstudo.PRO_LARGURA_PECA,
                PRO_LARGURA_PECA_PROGRAMADO = CorridasOnduladeiraEstudo.PRO_LARGURA_PECA_PROGRAMADO,
                PRO_COMPRIMENTO_PECA = CorridasOnduladeiraEstudo.PRO_COMPRIMENTO_PECA,
                PRO_COMPRIMENTO_PECA_PROGRAMADO = CorridasOnduladeiraEstudo.PRO_COMPRIMENTO_PECA_PROGRAMADO,
                PRO_UTILIZOU_REFILE_OBRIGATORIO = CorridasOnduladeiraEstudo.PRO_UTILIZOU_REFILE_OBRIGATORIO,
                PRO_VINCOS_RECALCULADOS = CorridasOnduladeiraEstudo.PRO_VINCOS_RECALCULADOS,
                COR_SOLVER = CorridasOnduladeiraEstudo.COR_SOLVER,
                COR_GRAMATURA_PAPEIS_PROGRAMADOS = CorridasOnduladeiraEstudo.COR_GRAMATURA_PAPEIS_PROGRAMADOS,
                COR_CUSTO_PAPEIS_PROGRAMADOS = CorridasOnduladeiraEstudo.COR_CUSTO_PAPEIS_PROGRAMADOS,
                COR_GRAMATURA_RESINA_PROGRAMADOS = CorridasOnduladeiraEstudo.COR_GRAMATURA_RESINA_PROGRAMADOS,
                COR_CUSTO_RESINA_PROGRAMADOS = CorridasOnduladeiraEstudo.COR_CUSTO_RESINA_PROGRAMADOS,
                COR_TOLERANCIA_MENOS = CorridasOnduladeiraEstudo.COR_TOLERANCIA_MENOS,
                COR_TOLERANCIA_MAIS = CorridasOnduladeiraEstudo.COR_TOLERANCIA_MAIS,
                COR_PILHAS_POR_PALETE = CorridasOnduladeiraEstudo.COR_PILHAS_POR_PALETE,
                COR_M_LINEAR_REALIZADO = CorridasOnduladeiraEstudo.COR_M_LINEAR_REALIZADO,
                PRO_ID_PALETE = CorridasOnduladeiraEstudo.PRO_ID_PALETE,
                COR_STATUS_PALETE = CorridasOnduladeiraEstudo.COR_STATUS_PALETE,
                COR_GRUPO_PRODUTIVO = CorridasOnduladeiraEstudo.COR_GRUPO_PRODUTIVO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCorridasOnduladeiraEstudoQuery(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [BOL_ID] = @BOL_ID, [BOL_ID_ORIGEM] = @BOL_ID_ORIGEM, [PRO_LARGURA_PECA] = @PRO_LARGURA_PECA, [PRO_LARGURA_PECA_PROGRAMADO] = @PRO_LARGURA_PECA_PROGRAMADO, [PRO_COMPRIMENTO_PECA] = @PRO_COMPRIMENTO_PECA, [PRO_COMPRIMENTO_PECA_PROGRAMADO] = @PRO_COMPRIMENTO_PECA_PROGRAMADO, [PRO_UTILIZOU_REFILE_OBRIGATORIO] = @PRO_UTILIZOU_REFILE_OBRIGATORIO, [PRO_VINCOS_RECALCULADOS] = @PRO_VINCOS_RECALCULADOS, [COR_SOLVER] = @COR_SOLVER, [COR_GRAMATURA_PAPEIS_PROGRAMADOS] = @COR_GRAMATURA_PAPEIS_PROGRAMADOS, [COR_CUSTO_PAPEIS_PROGRAMADOS] = @COR_CUSTO_PAPEIS_PROGRAMADOS, [COR_GRAMATURA_RESINA_PROGRAMADOS] = @COR_GRAMATURA_RESINA_PROGRAMADOS, [COR_CUSTO_RESINA_PROGRAMADOS] = @COR_CUSTO_RESINA_PROGRAMADOS, [COR_TOLERANCIA_MENOS] = @COR_TOLERANCIA_MENOS, [COR_TOLERANCIA_MAIS] = @COR_TOLERANCIA_MAIS, [COR_PILHAS_POR_PALETE] = @COR_PILHAS_POR_PALETE, [COR_M_LINEAR_REALIZADO] = @COR_M_LINEAR_REALIZADO, [PRO_ID_PALETE] = @PRO_ID_PALETE, [COR_STATUS_PALETE] = @COR_STATUS_PALETE, [COR_GRUPO_PRODUTIVO] = @COR_GRUPO_PRODUTIVO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_ID = CorridasOnduladeiraEstudo.BOL_ID,
                BOL_ID_ORIGEM = CorridasOnduladeiraEstudo.BOL_ID_ORIGEM,
                PRO_LARGURA_PECA = CorridasOnduladeiraEstudo.PRO_LARGURA_PECA,
                PRO_LARGURA_PECA_PROGRAMADO = CorridasOnduladeiraEstudo.PRO_LARGURA_PECA_PROGRAMADO,
                PRO_COMPRIMENTO_PECA = CorridasOnduladeiraEstudo.PRO_COMPRIMENTO_PECA,
                PRO_COMPRIMENTO_PECA_PROGRAMADO = CorridasOnduladeiraEstudo.PRO_COMPRIMENTO_PECA_PROGRAMADO,
                PRO_UTILIZOU_REFILE_OBRIGATORIO = CorridasOnduladeiraEstudo.PRO_UTILIZOU_REFILE_OBRIGATORIO,
                PRO_VINCOS_RECALCULADOS = CorridasOnduladeiraEstudo.PRO_VINCOS_RECALCULADOS,
                COR_SOLVER = CorridasOnduladeiraEstudo.COR_SOLVER,
                COR_GRAMATURA_PAPEIS_PROGRAMADOS = CorridasOnduladeiraEstudo.COR_GRAMATURA_PAPEIS_PROGRAMADOS,
                COR_CUSTO_PAPEIS_PROGRAMADOS = CorridasOnduladeiraEstudo.COR_CUSTO_PAPEIS_PROGRAMADOS,
                COR_GRAMATURA_RESINA_PROGRAMADOS = CorridasOnduladeiraEstudo.COR_GRAMATURA_RESINA_PROGRAMADOS,
                COR_CUSTO_RESINA_PROGRAMADOS = CorridasOnduladeiraEstudo.COR_CUSTO_RESINA_PROGRAMADOS,
                COR_TOLERANCIA_MENOS = CorridasOnduladeiraEstudo.COR_TOLERANCIA_MENOS,
                COR_TOLERANCIA_MAIS = CorridasOnduladeiraEstudo.COR_TOLERANCIA_MAIS,
                COR_PILHAS_POR_PALETE = CorridasOnduladeiraEstudo.COR_PILHAS_POR_PALETE,
                COR_M_LINEAR_REALIZADO = CorridasOnduladeiraEstudo.COR_M_LINEAR_REALIZADO,
                PRO_ID_PALETE = CorridasOnduladeiraEstudo.PRO_ID_PALETE,
                COR_STATUS_PALETE = CorridasOnduladeiraEstudo.COR_STATUS_PALETE,
                COR_GRUPO_PRODUTIVO = CorridasOnduladeiraEstudo.COR_GRUPO_PRODUTIVO,
                Changed = CorridasOnduladeiraEstudo.Changed,
                UserId = _executionContext.UserId,
                Id = CorridasOnduladeiraEstudo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [BOL_ID] = @BOL_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [BOL_ID_ORIGEM] = @BOL_ID_ORIGEM WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_ID_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LARGURA_PECA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [PRO_LARGURA_PECA] = @PRO_LARGURA_PECA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_LARGURA_PECA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_LARGURA_PECA_PROGRAMADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [PRO_LARGURA_PECA_PROGRAMADO] = @PRO_LARGURA_PECA_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_LARGURA_PECA_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRIMENTO_PECA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [PRO_COMPRIMENTO_PECA] = @PRO_COMPRIMENTO_PECA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_COMPRIMENTO_PECA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_COMPRIMENTO_PECA_PROGRAMADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [PRO_COMPRIMENTO_PECA_PROGRAMADO] = @PRO_COMPRIMENTO_PECA_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_COMPRIMENTO_PECA_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_UTILIZOU_REFILE_OBRIGATORIO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [PRO_UTILIZOU_REFILE_OBRIGATORIO] = @PRO_UTILIZOU_REFILE_OBRIGATORIO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_UTILIZOU_REFILE_OBRIGATORIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_VINCOS_RECALCULADOS(int id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [PRO_VINCOS_RECALCULADOS] = @PRO_VINCOS_RECALCULADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_VINCOS_RECALCULADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SOLVER(int id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_SOLVER] = @COR_SOLVER WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_SOLVER = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_GRAMATURA_PAPEIS_PROGRAMADOS] = @COR_GRAMATURA_PAPEIS_PROGRAMADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_GRAMATURA_PAPEIS_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_CUSTO_PAPEIS_PROGRAMADOS] = @COR_CUSTO_PAPEIS_PROGRAMADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_CUSTO_PAPEIS_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_GRAMATURA_RESINA_PROGRAMADOS] = @COR_GRAMATURA_RESINA_PROGRAMADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_GRAMATURA_RESINA_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_CUSTO_RESINA_PROGRAMADOS] = @COR_CUSTO_RESINA_PROGRAMADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_CUSTO_RESINA_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_TOLERANCIA_MENOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_TOLERANCIA_MENOS] = @COR_TOLERANCIA_MENOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_TOLERANCIA_MENOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_TOLERANCIA_MAIS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_TOLERANCIA_MAIS] = @COR_TOLERANCIA_MAIS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_TOLERANCIA_MAIS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_PILHAS_POR_PALETE(int id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_PILHAS_POR_PALETE] = @COR_PILHAS_POR_PALETE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_PILHAS_POR_PALETE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_M_LINEAR_REALIZADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_M_LINEAR_REALIZADO] = @COR_M_LINEAR_REALIZADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_M_LINEAR_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID_PALETE(int id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [PRO_ID_PALETE] = @PRO_ID_PALETE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                PRO_ID_PALETE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_STATUS_PALETE(int id, string value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_STATUS_PALETE] = @COR_STATUS_PALETE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_STATUS_PALETE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_GRUPO_PRODUTIVO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [COR_GRUPO_PRODUTIVO] = @COR_GRUPO_PRODUTIVO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                COR_GRUPO_PRODUTIVO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [CorridasOnduladeiraEstudo] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCorridasOnduladeiraEstudoQuery(ICorridasOnduladeiraEstudoEntity CorridasOnduladeiraEstudo)
        {
            this.Query = $@" DELETE FROM [CorridasOnduladeiraEstudo] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = CorridasOnduladeiraEstudo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration