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
    public class PlanoacaoQueryWrite : QueryBase, IPlanoacaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PlanoacaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPlanoacaoQuery(IPlanoacaoEntity Planoacao)
        {
            this.Query = $@" INSERT INTO Planoacao (PLA_DESCRICAO, MET_ID, PLA_STATUS, PLA_DATA, PLA_METAPERIODO, PLA_VLRPERIODO, PLA_METACULADO, PLA_VLRACUMULADO, PLA_REFERENCIA, USE_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.PLA_ID VALUES(@PLA_DESCRICAO, @MET_ID, @PLA_STATUS, @PLA_DATA, @PLA_METAPERIODO, @PLA_VLRPERIODO, @PLA_METACULADO, @PLA_VLRACUMULADO, @PLA_REFERENCIA, @USE_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PLA_DESCRICAO = Planoacao.PLA_DESCRICAO,
                MET_ID = Planoacao.MET_ID,
                PLA_STATUS = Planoacao.PLA_STATUS,
                PLA_DATA = Planoacao.PLA_DATA,
                PLA_METAPERIODO = Planoacao.PLA_METAPERIODO,
                PLA_VLRPERIODO = Planoacao.PLA_VLRPERIODO,
                PLA_METACULADO = Planoacao.PLA_METACULADO,
                PLA_VLRACUMULADO = Planoacao.PLA_VLRACUMULADO,
                PLA_REFERENCIA = Planoacao.PLA_REFERENCIA,
                USE_ID = Planoacao.USE_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePlanoacaoQuery(IPlanoacaoEntity Planoacao)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_DESCRICAO = @PLA_DESCRICAO, MET_ID = @MET_ID, PLA_STATUS = @PLA_STATUS, PLA_DATA = @PLA_DATA, PLA_METAPERIODO = @PLA_METAPERIODO, PLA_VLRPERIODO = @PLA_VLRPERIODO, PLA_METACULADO = @PLA_METACULADO, PLA_VLRACUMULADO = @PLA_VLRACUMULADO, PLA_REFERENCIA = @PLA_REFERENCIA, USE_ID = @USE_ID, Changed = @Changed, UserId = @UserId WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_DESCRICAO = Planoacao.PLA_DESCRICAO,
                MET_ID = Planoacao.MET_ID,
                PLA_STATUS = Planoacao.PLA_STATUS,
                PLA_DATA = Planoacao.PLA_DATA,
                PLA_METAPERIODO = Planoacao.PLA_METAPERIODO,
                PLA_VLRPERIODO = Planoacao.PLA_VLRPERIODO,
                PLA_METACULADO = Planoacao.PLA_METACULADO,
                PLA_VLRACUMULADO = Planoacao.PLA_VLRACUMULADO,
                PLA_REFERENCIA = Planoacao.PLA_REFERENCIA,
                USE_ID = Planoacao.USE_ID,
                Changed = Planoacao.Changed,
                UserId = _executionContext.UserId,
                PLA_ID = Planoacao.PLA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_DESCRICAO(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_DESCRICAO = @PLA_DESCRICAO WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_DESCRICAO = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMET_ID(int pla_id, int value)
        {
            this.Query = $@" UPDATE Planoacao SET MET_ID = @MET_ID WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                MET_ID = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_STATUS(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_STATUS = @PLA_STATUS WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_STATUS = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_DATA(int pla_id, DateTime value)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_DATA = @PLA_DATA WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_DATA = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_METAPERIODO(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_METAPERIODO = @PLA_METAPERIODO WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_METAPERIODO = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_VLRPERIODO(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_VLRPERIODO = @PLA_VLRPERIODO WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_VLRPERIODO = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_METACULADO(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_METACULADO = @PLA_METACULADO WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_METACULADO = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_VLRACUMULADO(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_VLRACUMULADO = @PLA_VLRACUMULADO WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_VLRACUMULADO = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePLA_REFERENCIA(int pla_id, string value)
        {
            this.Query = $@" UPDATE Planoacao SET PLA_REFERENCIA = @PLA_REFERENCIA WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_REFERENCIA = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int pla_id, int value)
        {
            this.Query = $@" UPDATE Planoacao SET USE_ID = @USE_ID WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                USE_ID = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int pla_id, int value)
        {
            this.Query = $@" UPDATE Planoacao SET TenantID = @TenantID WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                TenantID = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int pla_id, bool value)
        {
            this.Query = $@" UPDATE Planoacao SET Deleted = @Deleted WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                Deleted = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int pla_id, DateTime value)
        {
            this.Query = $@" UPDATE Planoacao SET Changed = @Changed WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                Changed = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int pla_id, int value)
        {
            this.Query = $@" UPDATE Planoacao SET UserId = @UserId WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                UserId = value,
                PLA_ID = pla_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePlanoacaoQuery(IPlanoacaoEntity Planoacao)
        {
            this.Query = $@" DELETE FROM Planoacao WHERE PLA_ID = @PLA_ID ";
            this.Parameters = new
            {
                PLA_ID = Planoacao.PLA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration