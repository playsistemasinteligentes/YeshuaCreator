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
    public class TipoDispositivoMaquinaQueryWrite : QueryBase, ITipoDispositivoMaquinaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoDispositivoMaquinaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoDispositivoMaquinaQuery(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina)
        {
            this.Query = $@" INSERT INTO TipoDispositivoMaquina (TDI_ID, MAQ_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@TDI_ID, @MAQ_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TDI_ID = TipoDispositivoMaquina.TDI_ID,
                MAQ_ID = TipoDispositivoMaquina.MAQ_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoDispositivoMaquinaQuery(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina)
        {
            this.Query = $@" UPDATE TipoDispositivoMaquina SET TDI_ID = @TDI_ID, MAQ_ID = @MAQ_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                TDI_ID = TipoDispositivoMaquina.TDI_ID,
                MAQ_ID = TipoDispositivoMaquina.MAQ_ID,
                Changed = TipoDispositivoMaquina.Changed,
                UserId = _executionContext.UserId,
                Id = TipoDispositivoMaquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTDI_ID(int id, string value)
        {
            this.Query = $@" UPDATE TipoDispositivoMaquina SET TDI_ID = @TDI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TDI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int id, string value)
        {
            this.Query = $@" UPDATE TipoDispositivoMaquina SET MAQ_ID = @MAQ_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE TipoDispositivoMaquina SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE TipoDispositivoMaquina SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE TipoDispositivoMaquina SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE TipoDispositivoMaquina SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoDispositivoMaquinaQuery(ITipoDispositivoMaquinaEntity TipoDispositivoMaquina)
        {
            this.Query = $@" DELETE FROM TipoDispositivoMaquina WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = TipoDispositivoMaquina.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration