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
    public class BoletimEstudoQueryWrite : QueryBase, IBoletimEstudoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public BoletimEstudoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirBoletimEstudoQuery(IBoletimEstudoEntity BoletimEstudo)
        {
            this.Query = $@" INSERT INTO [BoletimEstudo] ([BOL_ID], [BOL_ID_ORIGEM], [BOL_SOLVER], [BOL_INTEGRACAO], [BOL_SEQUENCIA], [GRP_PAP_GRAMATURA_PROGRAMADO], [GRP_ID_PROGRAMADO], [GRP_PAPEL1_PROGRAMADO], [GRP_PAPEL2_PROGRAMADO], [GRP_PAPEL3_PROGRAMADO], [GRP_PAPEL4_PROGRAMADO], [GRP_PAPEL5_PROGRAMADO], [BOL_STATUS_INTERFACE], [BOL_TIPO], [BOL_FORMATO], [BOL_GRAMATURA_PAPEIS_PROGRAMADOS], [BOL_GRAMATURA_PAPEIS_REALIZADO], [BOL_CUSTO_PAPEIS_PROGRAMADOS], [BOL_CUSTO_PAPEIS_REALIZADO], [BOL_GRAMATURA_RESINA_PROGRAMADOS], [BOL_CUSTO_RESINA_PROGRAMADOS], [BOL_REFILE_OBRIGATORIO], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@BOL_ID, @BOL_ID_ORIGEM, @BOL_SOLVER, @BOL_INTEGRACAO, @BOL_SEQUENCIA, @GRP_PAP_GRAMATURA_PROGRAMADO, @GRP_ID_PROGRAMADO, @GRP_PAPEL1_PROGRAMADO, @GRP_PAPEL2_PROGRAMADO, @GRP_PAPEL3_PROGRAMADO, @GRP_PAPEL4_PROGRAMADO, @GRP_PAPEL5_PROGRAMADO, @BOL_STATUS_INTERFACE, @BOL_TIPO, @BOL_FORMATO, @BOL_GRAMATURA_PAPEIS_PROGRAMADOS, @BOL_GRAMATURA_PAPEIS_REALIZADO, @BOL_CUSTO_PAPEIS_PROGRAMADOS, @BOL_CUSTO_PAPEIS_REALIZADO, @BOL_GRAMATURA_RESINA_PROGRAMADOS, @BOL_CUSTO_RESINA_PROGRAMADOS, @BOL_REFILE_OBRIGATORIO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                BOL_ID = BoletimEstudo.BOL_ID,
                BOL_ID_ORIGEM = BoletimEstudo.BOL_ID_ORIGEM,
                BOL_SOLVER = BoletimEstudo.BOL_SOLVER,
                BOL_INTEGRACAO = BoletimEstudo.BOL_INTEGRACAO,
                BOL_SEQUENCIA = BoletimEstudo.BOL_SEQUENCIA,
                GRP_PAP_GRAMATURA_PROGRAMADO = BoletimEstudo.GRP_PAP_GRAMATURA_PROGRAMADO,
                GRP_ID_PROGRAMADO = BoletimEstudo.GRP_ID_PROGRAMADO,
                GRP_PAPEL1_PROGRAMADO = BoletimEstudo.GRP_PAPEL1_PROGRAMADO,
                GRP_PAPEL2_PROGRAMADO = BoletimEstudo.GRP_PAPEL2_PROGRAMADO,
                GRP_PAPEL3_PROGRAMADO = BoletimEstudo.GRP_PAPEL3_PROGRAMADO,
                GRP_PAPEL4_PROGRAMADO = BoletimEstudo.GRP_PAPEL4_PROGRAMADO,
                GRP_PAPEL5_PROGRAMADO = BoletimEstudo.GRP_PAPEL5_PROGRAMADO,
                BOL_STATUS_INTERFACE = BoletimEstudo.BOL_STATUS_INTERFACE,
                BOL_TIPO = BoletimEstudo.BOL_TIPO,
                BOL_FORMATO = BoletimEstudo.BOL_FORMATO,
                BOL_GRAMATURA_PAPEIS_PROGRAMADOS = BoletimEstudo.BOL_GRAMATURA_PAPEIS_PROGRAMADOS,
                BOL_GRAMATURA_PAPEIS_REALIZADO = BoletimEstudo.BOL_GRAMATURA_PAPEIS_REALIZADO,
                BOL_CUSTO_PAPEIS_PROGRAMADOS = BoletimEstudo.BOL_CUSTO_PAPEIS_PROGRAMADOS,
                BOL_CUSTO_PAPEIS_REALIZADO = BoletimEstudo.BOL_CUSTO_PAPEIS_REALIZADO,
                BOL_GRAMATURA_RESINA_PROGRAMADOS = BoletimEstudo.BOL_GRAMATURA_RESINA_PROGRAMADOS,
                BOL_CUSTO_RESINA_PROGRAMADOS = BoletimEstudo.BOL_CUSTO_RESINA_PROGRAMADOS,
                BOL_REFILE_OBRIGATORIO = BoletimEstudo.BOL_REFILE_OBRIGATORIO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBoletimEstudoQuery(IBoletimEstudoEntity BoletimEstudo)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_ID] = @BOL_ID, [BOL_ID_ORIGEM] = @BOL_ID_ORIGEM, [BOL_SOLVER] = @BOL_SOLVER, [BOL_INTEGRACAO] = @BOL_INTEGRACAO, [BOL_SEQUENCIA] = @BOL_SEQUENCIA, [GRP_PAP_GRAMATURA_PROGRAMADO] = @GRP_PAP_GRAMATURA_PROGRAMADO, [GRP_ID_PROGRAMADO] = @GRP_ID_PROGRAMADO, [GRP_PAPEL1_PROGRAMADO] = @GRP_PAPEL1_PROGRAMADO, [GRP_PAPEL2_PROGRAMADO] = @GRP_PAPEL2_PROGRAMADO, [GRP_PAPEL3_PROGRAMADO] = @GRP_PAPEL3_PROGRAMADO, [GRP_PAPEL4_PROGRAMADO] = @GRP_PAPEL4_PROGRAMADO, [GRP_PAPEL5_PROGRAMADO] = @GRP_PAPEL5_PROGRAMADO, [BOL_STATUS_INTERFACE] = @BOL_STATUS_INTERFACE, [BOL_TIPO] = @BOL_TIPO, [BOL_FORMATO] = @BOL_FORMATO, [BOL_GRAMATURA_PAPEIS_PROGRAMADOS] = @BOL_GRAMATURA_PAPEIS_PROGRAMADOS, [BOL_GRAMATURA_PAPEIS_REALIZADO] = @BOL_GRAMATURA_PAPEIS_REALIZADO, [BOL_CUSTO_PAPEIS_PROGRAMADOS] = @BOL_CUSTO_PAPEIS_PROGRAMADOS, [BOL_CUSTO_PAPEIS_REALIZADO] = @BOL_CUSTO_PAPEIS_REALIZADO, [BOL_GRAMATURA_RESINA_PROGRAMADOS] = @BOL_GRAMATURA_RESINA_PROGRAMADOS, [BOL_CUSTO_RESINA_PROGRAMADOS] = @BOL_CUSTO_RESINA_PROGRAMADOS, [BOL_REFILE_OBRIGATORIO] = @BOL_REFILE_OBRIGATORIO, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_ID = BoletimEstudo.BOL_ID,
                BOL_ID_ORIGEM = BoletimEstudo.BOL_ID_ORIGEM,
                BOL_SOLVER = BoletimEstudo.BOL_SOLVER,
                BOL_INTEGRACAO = BoletimEstudo.BOL_INTEGRACAO,
                BOL_SEQUENCIA = BoletimEstudo.BOL_SEQUENCIA,
                GRP_PAP_GRAMATURA_PROGRAMADO = BoletimEstudo.GRP_PAP_GRAMATURA_PROGRAMADO,
                GRP_ID_PROGRAMADO = BoletimEstudo.GRP_ID_PROGRAMADO,
                GRP_PAPEL1_PROGRAMADO = BoletimEstudo.GRP_PAPEL1_PROGRAMADO,
                GRP_PAPEL2_PROGRAMADO = BoletimEstudo.GRP_PAPEL2_PROGRAMADO,
                GRP_PAPEL3_PROGRAMADO = BoletimEstudo.GRP_PAPEL3_PROGRAMADO,
                GRP_PAPEL4_PROGRAMADO = BoletimEstudo.GRP_PAPEL4_PROGRAMADO,
                GRP_PAPEL5_PROGRAMADO = BoletimEstudo.GRP_PAPEL5_PROGRAMADO,
                BOL_STATUS_INTERFACE = BoletimEstudo.BOL_STATUS_INTERFACE,
                BOL_TIPO = BoletimEstudo.BOL_TIPO,
                BOL_FORMATO = BoletimEstudo.BOL_FORMATO,
                BOL_GRAMATURA_PAPEIS_PROGRAMADOS = BoletimEstudo.BOL_GRAMATURA_PAPEIS_PROGRAMADOS,
                BOL_GRAMATURA_PAPEIS_REALIZADO = BoletimEstudo.BOL_GRAMATURA_PAPEIS_REALIZADO,
                BOL_CUSTO_PAPEIS_PROGRAMADOS = BoletimEstudo.BOL_CUSTO_PAPEIS_PROGRAMADOS,
                BOL_CUSTO_PAPEIS_REALIZADO = BoletimEstudo.BOL_CUSTO_PAPEIS_REALIZADO,
                BOL_GRAMATURA_RESINA_PROGRAMADOS = BoletimEstudo.BOL_GRAMATURA_RESINA_PROGRAMADOS,
                BOL_CUSTO_RESINA_PROGRAMADOS = BoletimEstudo.BOL_CUSTO_RESINA_PROGRAMADOS,
                BOL_REFILE_OBRIGATORIO = BoletimEstudo.BOL_REFILE_OBRIGATORIO,
                Changed = BoletimEstudo.Changed,
                UserId = _executionContext.UserId,
                Id = BoletimEstudo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_ID] = @BOL_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_ID_ORIGEM] = @BOL_ID_ORIGEM WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_ID_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_SOLVER(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_SOLVER] = @BOL_SOLVER WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_SOLVER = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_INTEGRACAO(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_INTEGRACAO] = @BOL_INTEGRACAO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_INTEGRACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_SEQUENCIA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_SEQUENCIA] = @BOL_SEQUENCIA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_SEQUENCIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAP_GRAMATURA_PROGRAMADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [GRP_PAP_GRAMATURA_PROGRAMADO] = @GRP_PAP_GRAMATURA_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRP_PAP_GRAMATURA_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [GRP_ID_PROGRAMADO] = @GRP_ID_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRP_ID_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL1_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [GRP_PAPEL1_PROGRAMADO] = @GRP_PAPEL1_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL1_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL2_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [GRP_PAPEL2_PROGRAMADO] = @GRP_PAPEL2_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL2_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL3_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [GRP_PAPEL3_PROGRAMADO] = @GRP_PAPEL3_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL3_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL4_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [GRP_PAPEL4_PROGRAMADO] = @GRP_PAPEL4_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL4_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL5_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [GRP_PAPEL5_PROGRAMADO] = @GRP_PAPEL5_PROGRAMADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL5_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_STATUS_INTERFACE(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_STATUS_INTERFACE] = @BOL_STATUS_INTERFACE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_STATUS_INTERFACE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_TIPO(int id, string value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_TIPO] = @BOL_TIPO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_TIPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_FORMATO(int id, int value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_FORMATO] = @BOL_FORMATO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_FORMATO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_GRAMATURA_PAPEIS_PROGRAMADOS] = @BOL_GRAMATURA_PAPEIS_PROGRAMADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_GRAMATURA_PAPEIS_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_GRAMATURA_PAPEIS_REALIZADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_GRAMATURA_PAPEIS_REALIZADO] = @BOL_GRAMATURA_PAPEIS_REALIZADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_GRAMATURA_PAPEIS_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_CUSTO_PAPEIS_PROGRAMADOS] = @BOL_CUSTO_PAPEIS_PROGRAMADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_CUSTO_PAPEIS_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_CUSTO_PAPEIS_REALIZADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_CUSTO_PAPEIS_REALIZADO] = @BOL_CUSTO_PAPEIS_REALIZADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_CUSTO_PAPEIS_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_GRAMATURA_RESINA_PROGRAMADOS] = @BOL_GRAMATURA_RESINA_PROGRAMADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_GRAMATURA_RESINA_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_CUSTO_RESINA_PROGRAMADOS] = @BOL_CUSTO_RESINA_PROGRAMADOS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_CUSTO_RESINA_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_REFILE_OBRIGATORIO(int id, int value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [BOL_REFILE_OBRIGATORIO] = @BOL_REFILE_OBRIGATORIO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                BOL_REFILE_OBRIGATORIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [BoletimEstudo] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteBoletimEstudoQuery(IBoletimEstudoEntity BoletimEstudo)
        {
            this.Query = $@" DELETE FROM [BoletimEstudo] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = BoletimEstudo.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration