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
    public class RodoviasQueryWrite : QueryBase, IRodoviasQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RodoviasQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRodoviasQuery(IRodoviasEntity Rodovias)
        {
            this.Query = $@" INSERT INTO Rodovias (ROD_DESCRICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ROD_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ROD_DESCRICAO = Rodovias.ROD_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRodoviasQuery(IRodoviasEntity Rodovias)
        {
            this.Query = $@" UPDATE Rodovias SET ROD_ID = @ROD_ID, ROD_DESCRICAO = @ROD_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ROD_ID = Rodovias.ROD_ID,
                ROD_DESCRICAO = Rodovias.ROD_DESCRICAO,
                Changed = Rodovias.Changed,
                UserId = _executionContext.UserId,
                Id = Rodovias.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROD_ID(int id, int value)
        {
            this.Query = $@" UPDATE Rodovias SET ROD_ID = @ROD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ROD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROD_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE Rodovias SET ROD_DESCRICAO = @ROD_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                ROD_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Rodovias SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Rodovias SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Rodovias SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Rodovias SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRodoviasQuery(IRodoviasEntity Rodovias)
        {
            this.Query = $@" DELETE FROM Rodovias WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Rodovias.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration