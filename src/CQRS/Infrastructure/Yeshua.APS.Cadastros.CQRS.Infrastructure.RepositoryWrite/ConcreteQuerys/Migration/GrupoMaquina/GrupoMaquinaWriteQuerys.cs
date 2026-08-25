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
    public class GrupoMaquinaQueryWrite : QueryBase, IGrupoMaquinaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public GrupoMaquinaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina)
        {
            this.Query = $@" INSERT INTO GrupoMaquina (GMA_ID, GMA_DESCRICAO, GMA_STATUS, TenantID, Deleted, Changed, UserId) VALUES(@GMA_ID, @GMA_DESCRICAO, @GMA_STATUS, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GMA_ID = GrupoMaquina.GMA_ID,
                GMA_DESCRICAO = GrupoMaquina.GMA_DESCRICAO,
                GMA_STATUS = GrupoMaquina.GMA_STATUS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina)
        {
            this.Query = $@" UPDATE GrupoMaquina SET GMA_DESCRICAO = @GMA_DESCRICAO, GMA_STATUS = @GMA_STATUS, Changed = @Changed, UserId = @UserId WHERE GMA_ID = @GMA_ID ";
            this.Parameters = new
            {
                GMA_DESCRICAO = GrupoMaquina.GMA_DESCRICAO,
                GMA_STATUS = GrupoMaquina.GMA_STATUS,
                Changed = GrupoMaquina.Changed,
                UserId = _executionContext.UserId,
                GMA_ID = GrupoMaquina.GMA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_DESCRICAO(string gma_id, string value)
        {
            this.Query = $@" UPDATE GrupoMaquina SET GMA_DESCRICAO = @GMA_DESCRICAO WHERE GMA_ID = @GMA_ID ";
            this.Parameters = new
            {
                GMA_DESCRICAO = value,
                GMA_ID = gma_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_STATUS(string gma_id, string value)
        {
            this.Query = $@" UPDATE GrupoMaquina SET GMA_STATUS = @GMA_STATUS WHERE GMA_ID = @GMA_ID ";
            this.Parameters = new
            {
                GMA_STATUS = value,
                GMA_ID = gma_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string gma_id, int value)
        {
            this.Query = $@" UPDATE GrupoMaquina SET TenantID = @TenantID WHERE GMA_ID = @GMA_ID ";
            this.Parameters = new
            {
                TenantID = value,
                GMA_ID = gma_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string gma_id, bool value)
        {
            this.Query = $@" UPDATE GrupoMaquina SET Deleted = @Deleted WHERE GMA_ID = @GMA_ID ";
            this.Parameters = new
            {
                Deleted = value,
                GMA_ID = gma_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string gma_id, DateTime value)
        {
            this.Query = $@" UPDATE GrupoMaquina SET Changed = @Changed WHERE GMA_ID = @GMA_ID ";
            this.Parameters = new
            {
                Changed = value,
                GMA_ID = gma_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string gma_id, int value)
        {
            this.Query = $@" UPDATE GrupoMaquina SET UserId = @UserId WHERE GMA_ID = @GMA_ID ";
            this.Parameters = new
            {
                UserId = value,
                GMA_ID = gma_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoMaquinaQuery(IGrupoMaquinaEntity GrupoMaquina)
        {
            this.Query = $@" DELETE FROM GrupoMaquina WHERE GMA_ID = @GMA_ID ";
            this.Parameters = new
            {
                GMA_ID = GrupoMaquina.GMA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration