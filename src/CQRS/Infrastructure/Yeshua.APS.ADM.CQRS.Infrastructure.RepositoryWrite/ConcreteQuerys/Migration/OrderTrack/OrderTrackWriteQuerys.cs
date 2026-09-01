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
    public class OrderTrackQueryWrite : QueryBase, IOrderTrackQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public OrderTrackQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirOrderTrackQuery(IOrderTrackEntity OrderTrack)
        {
            this.Query = $@" INSERT INTO OrderTrack (OTK_ID, OTK_SEQUENCIA, OTK_VERSSAO, ORD_ID, OTK_EVENTO, OTK_DATA_NECESSIDADE_DE, OTK_DATA_NECESSIDADE_ATE, OTK_DATA_PREVISTA, OTK_DATA_REALIZADA, FPR_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@OTK_ID, @OTK_SEQUENCIA, @OTK_VERSSAO, @ORD_ID, @OTK_EVENTO, @OTK_DATA_NECESSIDADE_DE, @OTK_DATA_NECESSIDADE_ATE, @OTK_DATA_PREVISTA, @OTK_DATA_REALIZADA, @FPR_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                OTK_ID = OrderTrack.OTK_ID,
                OTK_SEQUENCIA = OrderTrack.OTK_SEQUENCIA,
                OTK_VERSSAO = OrderTrack.OTK_VERSSAO,
                ORD_ID = OrderTrack.ORD_ID,
                OTK_EVENTO = OrderTrack.OTK_EVENTO,
                OTK_DATA_NECESSIDADE_DE = OrderTrack.OTK_DATA_NECESSIDADE_DE,
                OTK_DATA_NECESSIDADE_ATE = OrderTrack.OTK_DATA_NECESSIDADE_ATE,
                OTK_DATA_PREVISTA = OrderTrack.OTK_DATA_PREVISTA,
                OTK_DATA_REALIZADA = OrderTrack.OTK_DATA_REALIZADA,
                FPR_ID = OrderTrack.FPR_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOrderTrackQuery(IOrderTrackEntity OrderTrack)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_ID = @OTK_ID, OTK_SEQUENCIA = @OTK_SEQUENCIA, OTK_VERSSAO = @OTK_VERSSAO, ORD_ID = @ORD_ID, OTK_EVENTO = @OTK_EVENTO, OTK_DATA_NECESSIDADE_DE = @OTK_DATA_NECESSIDADE_DE, OTK_DATA_NECESSIDADE_ATE = @OTK_DATA_NECESSIDADE_ATE, OTK_DATA_PREVISTA = @OTK_DATA_PREVISTA, OTK_DATA_REALIZADA = @OTK_DATA_REALIZADA, FPR_ID = @FPR_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_ID = OrderTrack.OTK_ID,
                OTK_SEQUENCIA = OrderTrack.OTK_SEQUENCIA,
                OTK_VERSSAO = OrderTrack.OTK_VERSSAO,
                ORD_ID = OrderTrack.ORD_ID,
                OTK_EVENTO = OrderTrack.OTK_EVENTO,
                OTK_DATA_NECESSIDADE_DE = OrderTrack.OTK_DATA_NECESSIDADE_DE,
                OTK_DATA_NECESSIDADE_ATE = OrderTrack.OTK_DATA_NECESSIDADE_ATE,
                OTK_DATA_PREVISTA = OrderTrack.OTK_DATA_PREVISTA,
                OTK_DATA_REALIZADA = OrderTrack.OTK_DATA_REALIZADA,
                FPR_ID = OrderTrack.FPR_ID,
                Changed = OrderTrack.Changed,
                UserId = _executionContext.UserId,
                Id = OrderTrack.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_ID(int id, int value)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_ID = @OTK_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_SEQUENCIA(int id, Decimal value)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_SEQUENCIA = @OTK_SEQUENCIA WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_SEQUENCIA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_VERSSAO(int id, int value)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_VERSSAO = @OTK_VERSSAO WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_VERSSAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE OrderTrack SET ORD_ID = @ORD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_EVENTO(int id, string value)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_EVENTO = @OTK_EVENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_EVENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_DATA_NECESSIDADE_DE(int id, DateTime value)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_DATA_NECESSIDADE_DE = @OTK_DATA_NECESSIDADE_DE WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_DATA_NECESSIDADE_DE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_DATA_NECESSIDADE_ATE(int id, DateTime value)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_DATA_NECESSIDADE_ATE = @OTK_DATA_NECESSIDADE_ATE WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_DATA_NECESSIDADE_ATE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_DATA_PREVISTA(int id, DateTime value)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_DATA_PREVISTA = @OTK_DATA_PREVISTA WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_DATA_PREVISTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOTK_DATA_REALIZADA(int id, DateTime value)
        {
            this.Query = $@" UPDATE OrderTrack SET OTK_DATA_REALIZADA = @OTK_DATA_REALIZADA WHERE Id = @Id ";
            this.Parameters = new
            {
                OTK_DATA_REALIZADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_ID(int id, int value)
        {
            this.Query = $@" UPDATE OrderTrack SET FPR_ID = @FPR_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                FPR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE OrderTrack SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE OrderTrack SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE OrderTrack SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE OrderTrack SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteOrderTrackQuery(IOrderTrackEntity OrderTrack)
        {
            this.Query = $@" DELETE FROM OrderTrack WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = OrderTrack.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration