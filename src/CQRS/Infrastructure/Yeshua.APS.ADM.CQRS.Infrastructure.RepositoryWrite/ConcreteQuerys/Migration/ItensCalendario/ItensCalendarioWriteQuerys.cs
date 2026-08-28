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
    public class ItensCalendarioQueryWrite : QueryBase, IItensCalendarioQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ItensCalendarioQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirItensCalendarioQuery(IItensCalendarioEntity ItensCalendario)
        {
            this.Query = $@" INSERT INTO ItensCalendario (ICA_DATA_DE, ICA_DATA_ATE, ICA_OBSERVACAO, ICA_TIPO, URM_ID, URN_ID, CAL_ID, MAQ_ID, PRO_ID, ICA_LIMPESA_MAQUINA, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ICA_ID VALUES(@ICA_DATA_DE, @ICA_DATA_ATE, @ICA_OBSERVACAO, @ICA_TIPO, @URM_ID, @URN_ID, @CAL_ID, @MAQ_ID, @PRO_ID, @ICA_LIMPESA_MAQUINA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ICA_DATA_DE = ItensCalendario.ICA_DATA_DE,
                ICA_DATA_ATE = ItensCalendario.ICA_DATA_ATE,
                ICA_OBSERVACAO = ItensCalendario.ICA_OBSERVACAO,
                ICA_TIPO = ItensCalendario.ICA_TIPO,
                URM_ID = ItensCalendario.URM_ID,
                URN_ID = ItensCalendario.URN_ID,
                CAL_ID = ItensCalendario.CAL_ID,
                MAQ_ID = ItensCalendario.MAQ_ID,
                PRO_ID = ItensCalendario.PRO_ID,
                ICA_LIMPESA_MAQUINA = ItensCalendario.ICA_LIMPESA_MAQUINA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateItensCalendarioQuery(IItensCalendarioEntity ItensCalendario)
        {
            this.Query = $@" UPDATE ItensCalendario SET ICA_DATA_DE = @ICA_DATA_DE, ICA_DATA_ATE = @ICA_DATA_ATE, ICA_OBSERVACAO = @ICA_OBSERVACAO, ICA_TIPO = @ICA_TIPO, URM_ID = @URM_ID, URN_ID = @URN_ID, CAL_ID = @CAL_ID, MAQ_ID = @MAQ_ID, PRO_ID = @PRO_ID, ICA_LIMPESA_MAQUINA = @ICA_LIMPESA_MAQUINA, Changed = @Changed, UserId = @UserId WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                ICA_DATA_DE = ItensCalendario.ICA_DATA_DE,
                ICA_DATA_ATE = ItensCalendario.ICA_DATA_ATE,
                ICA_OBSERVACAO = ItensCalendario.ICA_OBSERVACAO,
                ICA_TIPO = ItensCalendario.ICA_TIPO,
                URM_ID = ItensCalendario.URM_ID,
                URN_ID = ItensCalendario.URN_ID,
                CAL_ID = ItensCalendario.CAL_ID,
                MAQ_ID = ItensCalendario.MAQ_ID,
                PRO_ID = ItensCalendario.PRO_ID,
                ICA_LIMPESA_MAQUINA = ItensCalendario.ICA_LIMPESA_MAQUINA,
                Changed = ItensCalendario.Changed,
                UserId = _executionContext.UserId,
                ICA_ID = ItensCalendario.ICA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateICA_DATA_DE(int ica_id, DateTime value)
        {
            this.Query = $@" UPDATE ItensCalendario SET ICA_DATA_DE = @ICA_DATA_DE WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                ICA_DATA_DE = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateICA_DATA_ATE(int ica_id, DateTime value)
        {
            this.Query = $@" UPDATE ItensCalendario SET ICA_DATA_ATE = @ICA_DATA_ATE WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                ICA_DATA_ATE = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateICA_OBSERVACAO(int ica_id, string value)
        {
            this.Query = $@" UPDATE ItensCalendario SET ICA_OBSERVACAO = @ICA_OBSERVACAO WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                ICA_OBSERVACAO = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateICA_TIPO(int ica_id, int value)
        {
            this.Query = $@" UPDATE ItensCalendario SET ICA_TIPO = @ICA_TIPO WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                ICA_TIPO = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateURM_ID(int ica_id, string value)
        {
            this.Query = $@" UPDATE ItensCalendario SET URM_ID = @URM_ID WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                URM_ID = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateURN_ID(int ica_id, string value)
        {
            this.Query = $@" UPDATE ItensCalendario SET URN_ID = @URN_ID WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                URN_ID = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAL_ID(int ica_id, int value)
        {
            this.Query = $@" UPDATE ItensCalendario SET CAL_ID = @CAL_ID WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                CAL_ID = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int ica_id, string value)
        {
            this.Query = $@" UPDATE ItensCalendario SET MAQ_ID = @MAQ_ID WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                MAQ_ID = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePRO_ID(int ica_id, string value)
        {
            this.Query = $@" UPDATE ItensCalendario SET PRO_ID = @PRO_ID WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                PRO_ID = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateICA_LIMPESA_MAQUINA(int ica_id, int value)
        {
            this.Query = $@" UPDATE ItensCalendario SET ICA_LIMPESA_MAQUINA = @ICA_LIMPESA_MAQUINA WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                ICA_LIMPESA_MAQUINA = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int ica_id, int value)
        {
            this.Query = $@" UPDATE ItensCalendario SET TenantID = @TenantID WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                TenantID = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int ica_id, bool value)
        {
            this.Query = $@" UPDATE ItensCalendario SET Deleted = @Deleted WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                Deleted = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int ica_id, DateTime value)
        {
            this.Query = $@" UPDATE ItensCalendario SET Changed = @Changed WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                Changed = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int ica_id, int value)
        {
            this.Query = $@" UPDATE ItensCalendario SET UserId = @UserId WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                UserId = value,
                ICA_ID = ica_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteItensCalendarioQuery(IItensCalendarioEntity ItensCalendario)
        {
            this.Query = $@" DELETE FROM ItensCalendario WHERE ICA_ID = @ICA_ID ";
            this.Parameters = new
            {
                ICA_ID = ItensCalendario.ICA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration