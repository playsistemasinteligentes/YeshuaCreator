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
    public class CalendarioQueryWrite : QueryBase, ICalendarioQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CalendarioQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCalendarioQuery(ICalendarioEntity Calendario)
        {
            this.Query = $@" INSERT INTO Calendario (CAL_ID, CAL_DESCRICAO, CAL_DIVIDE_DIA_EM, TenantID, Deleted, Changed, UserId) VALUES(@CAL_ID, @CAL_DESCRICAO, @CAL_DIVIDE_DIA_EM, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CAL_ID = Calendario.CAL_ID,
                CAL_DESCRICAO = Calendario.CAL_DESCRICAO,
                CAL_DIVIDE_DIA_EM = Calendario.CAL_DIVIDE_DIA_EM,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCalendarioQuery(ICalendarioEntity Calendario)
        {
            this.Query = $@" UPDATE Calendario SET CAL_DESCRICAO = @CAL_DESCRICAO, CAL_DIVIDE_DIA_EM = @CAL_DIVIDE_DIA_EM, Changed = @Changed, UserId = @UserId WHERE CAL_ID = @CAL_ID ";
            this.Parameters = new
            {
                CAL_DESCRICAO = Calendario.CAL_DESCRICAO,
                CAL_DIVIDE_DIA_EM = Calendario.CAL_DIVIDE_DIA_EM,
                Changed = Calendario.Changed,
                UserId = _executionContext.UserId,
                CAL_ID = Calendario.CAL_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAL_DESCRICAO(int cal_id, string value)
        {
            this.Query = $@" UPDATE Calendario SET CAL_DESCRICAO = @CAL_DESCRICAO WHERE CAL_ID = @CAL_ID ";
            this.Parameters = new
            {
                CAL_DESCRICAO = value,
                CAL_ID = cal_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAL_DIVIDE_DIA_EM(int cal_id, int value)
        {
            this.Query = $@" UPDATE Calendario SET CAL_DIVIDE_DIA_EM = @CAL_DIVIDE_DIA_EM WHERE CAL_ID = @CAL_ID ";
            this.Parameters = new
            {
                CAL_DIVIDE_DIA_EM = value,
                CAL_ID = cal_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int cal_id, int value)
        {
            this.Query = $@" UPDATE Calendario SET TenantID = @TenantID WHERE CAL_ID = @CAL_ID ";
            this.Parameters = new
            {
                TenantID = value,
                CAL_ID = cal_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int cal_id, bool value)
        {
            this.Query = $@" UPDATE Calendario SET Deleted = @Deleted WHERE CAL_ID = @CAL_ID ";
            this.Parameters = new
            {
                Deleted = value,
                CAL_ID = cal_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int cal_id, DateTime value)
        {
            this.Query = $@" UPDATE Calendario SET Changed = @Changed WHERE CAL_ID = @CAL_ID ";
            this.Parameters = new
            {
                Changed = value,
                CAL_ID = cal_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int cal_id, int value)
        {
            this.Query = $@" UPDATE Calendario SET UserId = @UserId WHERE CAL_ID = @CAL_ID ";
            this.Parameters = new
            {
                UserId = value,
                CAL_ID = cal_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCalendarioQuery(ICalendarioEntity Calendario)
        {
            this.Query = $@" DELETE FROM Calendario WHERE CAL_ID = @CAL_ID ";
            this.Parameters = new
            {
                CAL_ID = Calendario.CAL_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration