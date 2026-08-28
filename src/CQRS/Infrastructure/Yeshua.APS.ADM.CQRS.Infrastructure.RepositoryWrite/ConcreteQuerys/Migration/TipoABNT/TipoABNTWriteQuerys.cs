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
    public class TipoABNTQueryWrite : QueryBase, ITipoABNTQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoABNTQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoABNTQuery(ITipoABNTEntity TipoABNT)
        {
            this.Query = $@" INSERT INTO TipoABNT (ABN_ID, ABN_DESCRICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ABN_ID, @ABN_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ABN_ID = TipoABNT.ABN_ID,
                ABN_DESCRICAO = TipoABNT.ABN_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoABNTQuery(ITipoABNTEntity TipoABNT)
        {
            this.Query = $@" UPDATE TipoABNT SET ABN_ID = @ABN_ID, ABN_DESCRICAO = @ABN_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ABN_ID = TipoABNT.ABN_ID,
                ABN_DESCRICAO = TipoABNT.ABN_DESCRICAO,
                Changed = TipoABNT.Changed,
                UserId = _executionContext.UserId,
                Id = TipoABNT.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateABN_ID(int id, string value)
        {
            this.Query = $@" UPDATE TipoABNT SET ABN_ID = @ABN_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ABN_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateABN_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE TipoABNT SET ABN_DESCRICAO = @ABN_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                ABN_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE TipoABNT SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE TipoABNT SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE TipoABNT SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE TipoABNT SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoABNTQuery(ITipoABNTEntity TipoABNT)
        {
            this.Query = $@" DELETE FROM TipoABNT WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = TipoABNT.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration