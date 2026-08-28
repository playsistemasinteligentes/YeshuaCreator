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
    public class GrupoRecursoQueryWrite : QueryBase, IGrupoRecursoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public GrupoRecursoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirGrupoRecursoQuery(IGrupoRecursoEntity GrupoRecurso)
        {
            this.Query = $@" INSERT INTO GrupoRecurso (GRE_ID, GRE_DESCRICAO, TenantID, Deleted, Changed, UserId) VALUES(@GRE_ID, @GRE_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                GRE_ID = GrupoRecurso.GRE_ID,
                GRE_DESCRICAO = GrupoRecurso.GRE_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGrupoRecursoQuery(IGrupoRecursoEntity GrupoRecurso)
        {
            this.Query = $@" UPDATE GrupoRecurso SET GRE_DESCRICAO = @GRE_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE GRE_ID = @GRE_ID ";
            this.Parameters = new
            {
                GRE_DESCRICAO = GrupoRecurso.GRE_DESCRICAO,
                Changed = GrupoRecurso.Changed,
                UserId = _executionContext.UserId,
                GRE_ID = GrupoRecurso.GRE_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRE_DESCRICAO(string gre_id, string value)
        {
            this.Query = $@" UPDATE GrupoRecurso SET GRE_DESCRICAO = @GRE_DESCRICAO WHERE GRE_ID = @GRE_ID ";
            this.Parameters = new
            {
                GRE_DESCRICAO = value,
                GRE_ID = gre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string gre_id, int value)
        {
            this.Query = $@" UPDATE GrupoRecurso SET TenantID = @TenantID WHERE GRE_ID = @GRE_ID ";
            this.Parameters = new
            {
                TenantID = value,
                GRE_ID = gre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string gre_id, bool value)
        {
            this.Query = $@" UPDATE GrupoRecurso SET Deleted = @Deleted WHERE GRE_ID = @GRE_ID ";
            this.Parameters = new
            {
                Deleted = value,
                GRE_ID = gre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string gre_id, DateTime value)
        {
            this.Query = $@" UPDATE GrupoRecurso SET Changed = @Changed WHERE GRE_ID = @GRE_ID ";
            this.Parameters = new
            {
                Changed = value,
                GRE_ID = gre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string gre_id, int value)
        {
            this.Query = $@" UPDATE GrupoRecurso SET UserId = @UserId WHERE GRE_ID = @GRE_ID ";
            this.Parameters = new
            {
                UserId = value,
                GRE_ID = gre_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteGrupoRecursoQuery(IGrupoRecursoEntity GrupoRecurso)
        {
            this.Query = $@" DELETE FROM GrupoRecurso WHERE GRE_ID = @GRE_ID ";
            this.Parameters = new
            {
                GRE_ID = GrupoRecurso.GRE_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration