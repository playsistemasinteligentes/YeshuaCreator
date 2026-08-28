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
    public class GrupoIndicadorQueryWrite : QueryBase, IGrupoIndicadorQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public GrupoIndicadorQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirGrupoIndicadorQuery(IGrupoIndicadorEntity GrupoIndicador)
        {
            this.Query = $@" INSERT INTO GrupoIndicador (GRU_ID, IND_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.GRU_IND_ID VALUES(@GRU_ID, @IND_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GRU_ID = GrupoIndicador.GRU_ID,
                IND_ID = GrupoIndicador.IND_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoIndicadorQuery(IGrupoIndicadorEntity GrupoIndicador)
        {
            this.Query = $@" UPDATE GrupoIndicador SET GRU_ID = @GRU_ID, IND_ID = @IND_ID, Changed = @Changed, UserId = @UserId WHERE GRU_IND_ID = @GRU_IND_ID ";
            this.Parameters = new
            {
                GRU_ID = GrupoIndicador.GRU_ID,
                IND_ID = GrupoIndicador.IND_ID,
                Changed = GrupoIndicador.Changed,
                UserId = _executionContext.UserId,
                GRU_IND_ID = GrupoIndicador.GRU_IND_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRU_ID(int gru_ind_id, int value)
        {
            this.Query = $@" UPDATE GrupoIndicador SET GRU_ID = @GRU_ID WHERE GRU_IND_ID = @GRU_IND_ID ";
            this.Parameters = new
            {
                GRU_ID = value,
                GRU_IND_ID = gru_ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIND_ID(int gru_ind_id, int value)
        {
            this.Query = $@" UPDATE GrupoIndicador SET IND_ID = @IND_ID WHERE GRU_IND_ID = @GRU_IND_ID ";
            this.Parameters = new
            {
                IND_ID = value,
                GRU_IND_ID = gru_ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int gru_ind_id, int value)
        {
            this.Query = $@" UPDATE GrupoIndicador SET TenantID = @TenantID WHERE GRU_IND_ID = @GRU_IND_ID ";
            this.Parameters = new
            {
                TenantID = value,
                GRU_IND_ID = gru_ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int gru_ind_id, bool value)
        {
            this.Query = $@" UPDATE GrupoIndicador SET Deleted = @Deleted WHERE GRU_IND_ID = @GRU_IND_ID ";
            this.Parameters = new
            {
                Deleted = value,
                GRU_IND_ID = gru_ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int gru_ind_id, DateTime value)
        {
            this.Query = $@" UPDATE GrupoIndicador SET Changed = @Changed WHERE GRU_IND_ID = @GRU_IND_ID ";
            this.Parameters = new
            {
                Changed = value,
                GRU_IND_ID = gru_ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int gru_ind_id, int value)
        {
            this.Query = $@" UPDATE GrupoIndicador SET UserId = @UserId WHERE GRU_IND_ID = @GRU_IND_ID ";
            this.Parameters = new
            {
                UserId = value,
                GRU_IND_ID = gru_ind_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoIndicadorQuery(IGrupoIndicadorEntity GrupoIndicador)
        {
            this.Query = $@" DELETE FROM GrupoIndicador WHERE GRU_IND_ID = @GRU_IND_ID ";
            this.Parameters = new
            {
                GRU_IND_ID = GrupoIndicador.GRU_IND_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration