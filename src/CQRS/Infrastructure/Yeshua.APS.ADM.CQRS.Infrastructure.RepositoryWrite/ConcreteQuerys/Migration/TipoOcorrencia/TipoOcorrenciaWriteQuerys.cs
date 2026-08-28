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
    public class TipoOcorrenciaQueryWrite : QueryBase, ITipoOcorrenciaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoOcorrenciaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoOcorrenciaQuery(ITipoOcorrenciaEntity TipoOcorrencia)
        {
            this.Query = $@" INSERT INTO TipoOcorrencia (Id, Descricao, Spr, TenantID, Deleted, Changed, UserId) VALUES(@Id, @Descricao, @Spr, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                Id = TipoOcorrencia.Id,
                Descricao = TipoOcorrencia.Descricao,
                Spr = TipoOcorrencia.Spr,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoOcorrenciaQuery(ITipoOcorrenciaEntity TipoOcorrencia)
        {
            this.Query = $@" UPDATE TipoOcorrencia SET Descricao = @Descricao, Spr = @Spr, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = TipoOcorrencia.Descricao,
                Spr = TipoOcorrencia.Spr,
                Changed = TipoOcorrencia.Changed,
                UserId = _executionContext.UserId,
                Id = TipoOcorrencia.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDescricao(int id, string value)
        {
            this.Query = $@" UPDATE TipoOcorrencia SET Descricao = @Descricao WHERE Id = @Id ";
            this.Parameters = new
            {
                Descricao = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSpr(int id, int value)
        {
            this.Query = $@" UPDATE TipoOcorrencia SET Spr = @Spr WHERE Id = @Id ";
            this.Parameters = new
            {
                Spr = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE TipoOcorrencia SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE TipoOcorrencia SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE TipoOcorrencia SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE TipoOcorrencia SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoOcorrenciaQuery(ITipoOcorrenciaEntity TipoOcorrencia)
        {
            this.Query = $@" DELETE FROM TipoOcorrencia WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = TipoOcorrencia.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration