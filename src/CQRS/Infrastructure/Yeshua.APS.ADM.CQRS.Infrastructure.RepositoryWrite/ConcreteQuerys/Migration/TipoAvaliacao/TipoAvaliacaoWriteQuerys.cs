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
    public class TipoAvaliacaoQueryWrite : QueryBase, ITipoAvaliacaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoAvaliacaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoAvaliacaoQuery(ITipoAvaliacaoEntity TipoAvaliacao)
        {
            this.Query = $@" INSERT INTO TipoAvaliacao (TA_DESC, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.TA_ID VALUES(@TA_DESC, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TA_DESC = TipoAvaliacao.TA_DESC,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoAvaliacaoQuery(ITipoAvaliacaoEntity TipoAvaliacao)
        {
            this.Query = $@" UPDATE TipoAvaliacao SET TA_DESC = @TA_DESC, Changed = @Changed, UserId = @UserId WHERE TA_ID = @TA_ID ";
            this.Parameters = new
            {
                TA_DESC = TipoAvaliacao.TA_DESC,
                Changed = TipoAvaliacao.Changed,
                UserId = _executionContext.UserId,
                TA_ID = TipoAvaliacao.TA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTA_DESC(int ta_id, string value)
        {
            this.Query = $@" UPDATE TipoAvaliacao SET TA_DESC = @TA_DESC WHERE TA_ID = @TA_ID ";
            this.Parameters = new
            {
                TA_DESC = value,
                TA_ID = ta_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int ta_id, int value)
        {
            this.Query = $@" UPDATE TipoAvaliacao SET TenantID = @TenantID WHERE TA_ID = @TA_ID ";
            this.Parameters = new
            {
                TenantID = value,
                TA_ID = ta_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int ta_id, bool value)
        {
            this.Query = $@" UPDATE TipoAvaliacao SET Deleted = @Deleted WHERE TA_ID = @TA_ID ";
            this.Parameters = new
            {
                Deleted = value,
                TA_ID = ta_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int ta_id, DateTime value)
        {
            this.Query = $@" UPDATE TipoAvaliacao SET Changed = @Changed WHERE TA_ID = @TA_ID ";
            this.Parameters = new
            {
                Changed = value,
                TA_ID = ta_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int ta_id, int value)
        {
            this.Query = $@" UPDATE TipoAvaliacao SET UserId = @UserId WHERE TA_ID = @TA_ID ";
            this.Parameters = new
            {
                UserId = value,
                TA_ID = ta_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoAvaliacaoQuery(ITipoAvaliacaoEntity TipoAvaliacao)
        {
            this.Query = $@" DELETE FROM TipoAvaliacao WHERE TA_ID = @TA_ID ";
            this.Parameters = new
            {
                TA_ID = TipoAvaliacao.TA_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration