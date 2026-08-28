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
    public class ObjetoControlavelQueryWrite : QueryBase, IObjetoControlavelQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ObjetoControlavelQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirObjetoControlavelQuery(IObjetoControlavelEntity ObjetoControlavel)
        {
            this.Query = $@" INSERT INTO ObjetoControlavel (OBJ_ID, OBJ_DESCRICAO, OBJ_TIPO, OBJ_GRUPO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@OBJ_ID, @OBJ_DESCRICAO, @OBJ_TIPO, @OBJ_GRUPO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                OBJ_ID = ObjetoControlavel.OBJ_ID,
                OBJ_DESCRICAO = ObjetoControlavel.OBJ_DESCRICAO,
                OBJ_TIPO = ObjetoControlavel.OBJ_TIPO,
                OBJ_GRUPO = ObjetoControlavel.OBJ_GRUPO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateObjetoControlavelQuery(IObjetoControlavelEntity ObjetoControlavel)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET OBJ_ID = @OBJ_ID, OBJ_DESCRICAO = @OBJ_DESCRICAO, OBJ_TIPO = @OBJ_TIPO, OBJ_GRUPO = @OBJ_GRUPO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                OBJ_ID = ObjetoControlavel.OBJ_ID,
                OBJ_DESCRICAO = ObjetoControlavel.OBJ_DESCRICAO,
                OBJ_TIPO = ObjetoControlavel.OBJ_TIPO,
                OBJ_GRUPO = ObjetoControlavel.OBJ_GRUPO,
                Changed = ObjetoControlavel.Changed,
                UserId = _executionContext.UserId,
                Id = ObjetoControlavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBJ_ID(int id, string value)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET OBJ_ID = @OBJ_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                OBJ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBJ_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET OBJ_DESCRICAO = @OBJ_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                OBJ_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBJ_TIPO(int id, string value)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET OBJ_TIPO = @OBJ_TIPO WHERE Id = @Id ";
            this.Parameters = new
            {
                OBJ_TIPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOBJ_GRUPO(int id, string value)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET OBJ_GRUPO = @OBJ_GRUPO WHERE Id = @Id ";
            this.Parameters = new
            {
                OBJ_GRUPO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE ObjetoControlavel SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteObjetoControlavelQuery(IObjetoControlavelEntity ObjetoControlavel)
        {
            this.Query = $@" DELETE FROM ObjetoControlavel WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ObjetoControlavel.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration