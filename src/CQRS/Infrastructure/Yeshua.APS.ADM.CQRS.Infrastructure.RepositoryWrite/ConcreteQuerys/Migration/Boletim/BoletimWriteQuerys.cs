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
    public class BoletimQueryWrite : QueryBase, IBoletimQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public BoletimQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirBoletimQuery(IBoletimEntity Boletim)
        {
            this.Query = $@" INSERT INTO Boletim (BOL_ID, BOL_ID_ORIGEM, BOL_SOLVER, BOL_INTEGRACAO, BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE, BOL_TIPO, BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO, BOL_OBS, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@BOL_ID, @BOL_ID_ORIGEM, @BOL_SOLVER, @BOL_INTEGRACAO, @BOL_SEQUENCIA, @GRP_PAP_GRAMATURA_PROGRAMADO, @GRP_ID_PROGRAMADO, @GRP_PAPEL1_PROGRAMADO, @GRP_PAPEL2_PROGRAMADO, @GRP_PAPEL3_PROGRAMADO, @GRP_PAPEL4_PROGRAMADO, @GRP_PAPEL5_PROGRAMADO, @BOL_STATUS_INTERFACE, @BOL_TIPO, @BOL_FORMATO, @BOL_GRAMATURA_PAPEIS_PROGRAMADOS, @BOL_GRAMATURA_PAPEIS_REALIZADO, @BOL_CUSTO_PAPEIS_PROGRAMADOS, @BOL_CUSTO_PAPEIS_REALIZADO, @BOL_GRAMATURA_RESINA_PROGRAMADOS, @BOL_CUSTO_RESINA_PROGRAMADOS, @BOL_REFILE_OBRIGATORIO, @BOL_OBS, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                BOL_ID = Boletim.BOL_ID,
                BOL_ID_ORIGEM = Boletim.BOL_ID_ORIGEM,
                BOL_SOLVER = Boletim.BOL_SOLVER,
                BOL_INTEGRACAO = Boletim.BOL_INTEGRACAO,
                BOL_SEQUENCIA = Boletim.BOL_SEQUENCIA,
                GRP_PAP_GRAMATURA_PROGRAMADO = Boletim.GRP_PAP_GRAMATURA_PROGRAMADO,
                GRP_ID_PROGRAMADO = Boletim.GRP_ID_PROGRAMADO,
                GRP_PAPEL1_PROGRAMADO = Boletim.GRP_PAPEL1_PROGRAMADO,
                GRP_PAPEL2_PROGRAMADO = Boletim.GRP_PAPEL2_PROGRAMADO,
                GRP_PAPEL3_PROGRAMADO = Boletim.GRP_PAPEL3_PROGRAMADO,
                GRP_PAPEL4_PROGRAMADO = Boletim.GRP_PAPEL4_PROGRAMADO,
                GRP_PAPEL5_PROGRAMADO = Boletim.GRP_PAPEL5_PROGRAMADO,
                BOL_STATUS_INTERFACE = Boletim.BOL_STATUS_INTERFACE,
                BOL_TIPO = Boletim.BOL_TIPO,
                BOL_FORMATO = Boletim.BOL_FORMATO,
                BOL_GRAMATURA_PAPEIS_PROGRAMADOS = Boletim.BOL_GRAMATURA_PAPEIS_PROGRAMADOS,
                BOL_GRAMATURA_PAPEIS_REALIZADO = Boletim.BOL_GRAMATURA_PAPEIS_REALIZADO,
                BOL_CUSTO_PAPEIS_PROGRAMADOS = Boletim.BOL_CUSTO_PAPEIS_PROGRAMADOS,
                BOL_CUSTO_PAPEIS_REALIZADO = Boletim.BOL_CUSTO_PAPEIS_REALIZADO,
                BOL_GRAMATURA_RESINA_PROGRAMADOS = Boletim.BOL_GRAMATURA_RESINA_PROGRAMADOS,
                BOL_CUSTO_RESINA_PROGRAMADOS = Boletim.BOL_CUSTO_RESINA_PROGRAMADOS,
                BOL_REFILE_OBRIGATORIO = Boletim.BOL_REFILE_OBRIGATORIO,
                BOL_OBS = Boletim.BOL_OBS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBoletimQuery(IBoletimEntity Boletim)
        {
            this.Query = $@" UPDATE Boletim SET BOL_ID = @BOL_ID, BOL_ID_ORIGEM = @BOL_ID_ORIGEM, BOL_SOLVER = @BOL_SOLVER, BOL_INTEGRACAO = @BOL_INTEGRACAO, BOL_SEQUENCIA = @BOL_SEQUENCIA, GRP_PAP_GRAMATURA_PROGRAMADO = @GRP_PAP_GRAMATURA_PROGRAMADO, GRP_ID_PROGRAMADO = @GRP_ID_PROGRAMADO, GRP_PAPEL1_PROGRAMADO = @GRP_PAPEL1_PROGRAMADO, GRP_PAPEL2_PROGRAMADO = @GRP_PAPEL2_PROGRAMADO, GRP_PAPEL3_PROGRAMADO = @GRP_PAPEL3_PROGRAMADO, GRP_PAPEL4_PROGRAMADO = @GRP_PAPEL4_PROGRAMADO, GRP_PAPEL5_PROGRAMADO = @GRP_PAPEL5_PROGRAMADO, BOL_STATUS_INTERFACE = @BOL_STATUS_INTERFACE, BOL_TIPO = @BOL_TIPO, BOL_FORMATO = @BOL_FORMATO, BOL_GRAMATURA_PAPEIS_PROGRAMADOS = @BOL_GRAMATURA_PAPEIS_PROGRAMADOS, BOL_GRAMATURA_PAPEIS_REALIZADO = @BOL_GRAMATURA_PAPEIS_REALIZADO, BOL_CUSTO_PAPEIS_PROGRAMADOS = @BOL_CUSTO_PAPEIS_PROGRAMADOS, BOL_CUSTO_PAPEIS_REALIZADO = @BOL_CUSTO_PAPEIS_REALIZADO, BOL_GRAMATURA_RESINA_PROGRAMADOS = @BOL_GRAMATURA_RESINA_PROGRAMADOS, BOL_CUSTO_RESINA_PROGRAMADOS = @BOL_CUSTO_RESINA_PROGRAMADOS, BOL_REFILE_OBRIGATORIO = @BOL_REFILE_OBRIGATORIO, BOL_OBS = @BOL_OBS, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_ID = Boletim.BOL_ID,
                BOL_ID_ORIGEM = Boletim.BOL_ID_ORIGEM,
                BOL_SOLVER = Boletim.BOL_SOLVER,
                BOL_INTEGRACAO = Boletim.BOL_INTEGRACAO,
                BOL_SEQUENCIA = Boletim.BOL_SEQUENCIA,
                GRP_PAP_GRAMATURA_PROGRAMADO = Boletim.GRP_PAP_GRAMATURA_PROGRAMADO,
                GRP_ID_PROGRAMADO = Boletim.GRP_ID_PROGRAMADO,
                GRP_PAPEL1_PROGRAMADO = Boletim.GRP_PAPEL1_PROGRAMADO,
                GRP_PAPEL2_PROGRAMADO = Boletim.GRP_PAPEL2_PROGRAMADO,
                GRP_PAPEL3_PROGRAMADO = Boletim.GRP_PAPEL3_PROGRAMADO,
                GRP_PAPEL4_PROGRAMADO = Boletim.GRP_PAPEL4_PROGRAMADO,
                GRP_PAPEL5_PROGRAMADO = Boletim.GRP_PAPEL5_PROGRAMADO,
                BOL_STATUS_INTERFACE = Boletim.BOL_STATUS_INTERFACE,
                BOL_TIPO = Boletim.BOL_TIPO,
                BOL_FORMATO = Boletim.BOL_FORMATO,
                BOL_GRAMATURA_PAPEIS_PROGRAMADOS = Boletim.BOL_GRAMATURA_PAPEIS_PROGRAMADOS,
                BOL_GRAMATURA_PAPEIS_REALIZADO = Boletim.BOL_GRAMATURA_PAPEIS_REALIZADO,
                BOL_CUSTO_PAPEIS_PROGRAMADOS = Boletim.BOL_CUSTO_PAPEIS_PROGRAMADOS,
                BOL_CUSTO_PAPEIS_REALIZADO = Boletim.BOL_CUSTO_PAPEIS_REALIZADO,
                BOL_GRAMATURA_RESINA_PROGRAMADOS = Boletim.BOL_GRAMATURA_RESINA_PROGRAMADOS,
                BOL_CUSTO_RESINA_PROGRAMADOS = Boletim.BOL_CUSTO_RESINA_PROGRAMADOS,
                BOL_REFILE_OBRIGATORIO = Boletim.BOL_REFILE_OBRIGATORIO,
                BOL_OBS = Boletim.BOL_OBS,
                Changed = Boletim.Changed,
                UserId = _executionContext.UserId,
                Id = Boletim.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_ID = @BOL_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID_ORIGEM(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_ID_ORIGEM = @BOL_ID_ORIGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_ID_ORIGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_SOLVER(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_SOLVER = @BOL_SOLVER WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_SOLVER = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_INTEGRACAO(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_INTEGRACAO = @BOL_INTEGRACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_INTEGRACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_SEQUENCIA(int id, Decimal value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_SEQUENCIA = @BOL_SEQUENCIA WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_SEQUENCIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAP_GRAMATURA_PROGRAMADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Boletim SET GRP_PAP_GRAMATURA_PROGRAMADO = @GRP_PAP_GRAMATURA_PROGRAMADO WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_PAP_GRAMATURA_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_ID_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET GRP_ID_PROGRAMADO = @GRP_ID_PROGRAMADO WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_ID_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL1_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET GRP_PAPEL1_PROGRAMADO = @GRP_PAPEL1_PROGRAMADO WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL1_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL2_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET GRP_PAPEL2_PROGRAMADO = @GRP_PAPEL2_PROGRAMADO WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL2_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL3_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET GRP_PAPEL3_PROGRAMADO = @GRP_PAPEL3_PROGRAMADO WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL3_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL4_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET GRP_PAPEL4_PROGRAMADO = @GRP_PAPEL4_PROGRAMADO WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL4_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRP_PAPEL5_PROGRAMADO(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET GRP_PAPEL5_PROGRAMADO = @GRP_PAPEL5_PROGRAMADO WHERE Id = @Id ";
            this.Parameters = new
            {
                GRP_PAPEL5_PROGRAMADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_STATUS_INTERFACE(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_STATUS_INTERFACE = @BOL_STATUS_INTERFACE WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_STATUS_INTERFACE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_TIPO(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_TIPO = @BOL_TIPO WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_TIPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_FORMATO(int id, int value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_FORMATO = @BOL_FORMATO WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_FORMATO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_GRAMATURA_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_GRAMATURA_PAPEIS_PROGRAMADOS = @BOL_GRAMATURA_PAPEIS_PROGRAMADOS WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_GRAMATURA_PAPEIS_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_GRAMATURA_PAPEIS_REALIZADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_GRAMATURA_PAPEIS_REALIZADO = @BOL_GRAMATURA_PAPEIS_REALIZADO WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_GRAMATURA_PAPEIS_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_CUSTO_PAPEIS_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_CUSTO_PAPEIS_PROGRAMADOS = @BOL_CUSTO_PAPEIS_PROGRAMADOS WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_CUSTO_PAPEIS_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_CUSTO_PAPEIS_REALIZADO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_CUSTO_PAPEIS_REALIZADO = @BOL_CUSTO_PAPEIS_REALIZADO WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_CUSTO_PAPEIS_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_GRAMATURA_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_GRAMATURA_RESINA_PROGRAMADOS = @BOL_GRAMATURA_RESINA_PROGRAMADOS WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_GRAMATURA_RESINA_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_CUSTO_RESINA_PROGRAMADOS(int id, Decimal value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_CUSTO_RESINA_PROGRAMADOS = @BOL_CUSTO_RESINA_PROGRAMADOS WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_CUSTO_RESINA_PROGRAMADOS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_REFILE_OBRIGATORIO(int id, int value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_REFILE_OBRIGATORIO = @BOL_REFILE_OBRIGATORIO WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_REFILE_OBRIGATORIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_OBS(int id, string value)
        {
            this.Query = $@" UPDATE Boletim SET BOL_OBS = @BOL_OBS WHERE Id = @Id ";
            this.Parameters = new
            {
                BOL_OBS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Boletim SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Boletim SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Boletim SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Boletim SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteBoletimQuery(IBoletimEntity Boletim)
        {
            this.Query = $@" DELETE FROM Boletim WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Boletim.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration