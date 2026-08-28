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
    public class T_HORARIO_RECEBIMENTOQueryWrite : QueryBase, IT_HORARIO_RECEBIMENTOQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_HORARIO_RECEBIMENTOQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_HORARIO_RECEBIMENTOQuery(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO)
        {
            this.Query = $@" INSERT INTO T_HORARIO_RECEBIMENTO (HRE_DIA_DA_SEMANA, HRE_HORA_INICIAL, HRE_HORA_FINAL, CLI_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.HRE_ID VALUES(@HRE_DIA_DA_SEMANA, @HRE_HORA_INICIAL, @HRE_HORA_FINAL, @CLI_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                HRE_DIA_DA_SEMANA = T_HORARIO_RECEBIMENTO.HRE_DIA_DA_SEMANA,
                HRE_HORA_INICIAL = T_HORARIO_RECEBIMENTO.HRE_HORA_INICIAL,
                HRE_HORA_FINAL = T_HORARIO_RECEBIMENTO.HRE_HORA_FINAL,
                CLI_ID = T_HORARIO_RECEBIMENTO.CLI_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_HORARIO_RECEBIMENTOQuery(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET HRE_DIA_DA_SEMANA = @HRE_DIA_DA_SEMANA, HRE_HORA_INICIAL = @HRE_HORA_INICIAL, HRE_HORA_FINAL = @HRE_HORA_FINAL, CLI_ID = @CLI_ID, Changed = @Changed, UserId = @UserId WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                HRE_DIA_DA_SEMANA = T_HORARIO_RECEBIMENTO.HRE_DIA_DA_SEMANA,
                HRE_HORA_INICIAL = T_HORARIO_RECEBIMENTO.HRE_HORA_INICIAL,
                HRE_HORA_FINAL = T_HORARIO_RECEBIMENTO.HRE_HORA_FINAL,
                CLI_ID = T_HORARIO_RECEBIMENTO.CLI_ID,
                Changed = T_HORARIO_RECEBIMENTO.Changed,
                UserId = _executionContext.UserId,
                HRE_ID = T_HORARIO_RECEBIMENTO.HRE_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHRE_DIA_DA_SEMANA(int hre_id, int value)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET HRE_DIA_DA_SEMANA = @HRE_DIA_DA_SEMANA WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                HRE_DIA_DA_SEMANA = value,
                HRE_ID = hre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHRE_HORA_INICIAL(int hre_id, DateTime value)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET HRE_HORA_INICIAL = @HRE_HORA_INICIAL WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                HRE_HORA_INICIAL = value,
                HRE_ID = hre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateHRE_HORA_FINAL(int hre_id, DateTime value)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET HRE_HORA_FINAL = @HRE_HORA_FINAL WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                HRE_HORA_FINAL = value,
                HRE_ID = hre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(int hre_id, string value)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET CLI_ID = @CLI_ID WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                CLI_ID = value,
                HRE_ID = hre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int hre_id, int value)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET TenantID = @TenantID WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                TenantID = value,
                HRE_ID = hre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int hre_id, bool value)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET Deleted = @Deleted WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                Deleted = value,
                HRE_ID = hre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int hre_id, DateTime value)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET Changed = @Changed WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                Changed = value,
                HRE_ID = hre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int hre_id, int value)
        {
            this.Query = $@" UPDATE T_HORARIO_RECEBIMENTO SET UserId = @UserId WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                UserId = value,
                HRE_ID = hre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_HORARIO_RECEBIMENTOQuery(IT_HORARIO_RECEBIMENTOEntity T_HORARIO_RECEBIMENTO)
        {
            this.Query = $@" DELETE FROM T_HORARIO_RECEBIMENTO WHERE HRE_ID = @HRE_ID ";
            this.Parameters = new
            {
                HRE_ID = T_HORARIO_RECEBIMENTO.HRE_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration