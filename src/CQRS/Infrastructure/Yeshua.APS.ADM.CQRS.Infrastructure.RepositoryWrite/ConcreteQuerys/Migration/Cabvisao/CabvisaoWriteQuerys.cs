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
    public class CabvisaoQueryWrite : QueryBase, ICabvisaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CabvisaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCabvisaoQuery(ICabvisaoEntity Cabvisao)
        {
            this.Query = $@" INSERT INTO Cabvisao (CAB_DESC, CAB_STATUS, USE_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.CAB_ID VALUES(@CAB_DESC, @CAB_STATUS, @USE_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CAB_DESC = Cabvisao.CAB_DESC,
                CAB_STATUS = Cabvisao.CAB_STATUS,
                USE_ID = Cabvisao.USE_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCabvisaoQuery(ICabvisaoEntity Cabvisao)
        {
            this.Query = $@" UPDATE Cabvisao SET CAB_DESC = @CAB_DESC, CAB_STATUS = @CAB_STATUS, USE_ID = @USE_ID, Changed = @Changed, UserId = @UserId WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                CAB_DESC = Cabvisao.CAB_DESC,
                CAB_STATUS = Cabvisao.CAB_STATUS,
                USE_ID = Cabvisao.USE_ID,
                Changed = Cabvisao.Changed,
                UserId = _executionContext.UserId,
                CAB_ID = Cabvisao.CAB_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAB_DESC(int cab_id, string value)
        {
            this.Query = $@" UPDATE Cabvisao SET CAB_DESC = @CAB_DESC WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                CAB_DESC = value,
                CAB_ID = cab_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAB_STATUS(int cab_id, int value)
        {
            this.Query = $@" UPDATE Cabvisao SET CAB_STATUS = @CAB_STATUS WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                CAB_STATUS = value,
                CAB_ID = cab_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int cab_id, int value)
        {
            this.Query = $@" UPDATE Cabvisao SET USE_ID = @USE_ID WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                USE_ID = value,
                CAB_ID = cab_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int cab_id, int value)
        {
            this.Query = $@" UPDATE Cabvisao SET TenantID = @TenantID WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                TenantID = value,
                CAB_ID = cab_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int cab_id, bool value)
        {
            this.Query = $@" UPDATE Cabvisao SET Deleted = @Deleted WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                Deleted = value,
                CAB_ID = cab_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int cab_id, DateTime value)
        {
            this.Query = $@" UPDATE Cabvisao SET Changed = @Changed WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                Changed = value,
                CAB_ID = cab_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int cab_id, int value)
        {
            this.Query = $@" UPDATE Cabvisao SET UserId = @UserId WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                UserId = value,
                CAB_ID = cab_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCabvisaoQuery(ICabvisaoEntity Cabvisao)
        {
            this.Query = $@" DELETE FROM Cabvisao WHERE CAB_ID = @CAB_ID ";
            this.Parameters = new
            {
                CAB_ID = Cabvisao.CAB_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration