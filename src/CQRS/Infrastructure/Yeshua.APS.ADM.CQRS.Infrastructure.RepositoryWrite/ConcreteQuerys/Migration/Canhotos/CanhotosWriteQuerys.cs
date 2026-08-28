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
    public class CanhotosQueryWrite : QueryBase, ICanhotosQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CanhotosQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCanhotosQuery(ICanhotosEntity Canhotos)
        {
            this.Query = $@" INSERT INTO Canhotos (CAR_ID, ORD_ID, NOT_ID, CAN_DATA_ENTREGA, CAN_IMG, CAN_LAT_ENTREGA, CAN_LONG_ENTREGA, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CAR_ID, @ORD_ID, @NOT_ID, @CAN_DATA_ENTREGA, @CAN_IMG, @CAN_LAT_ENTREGA, @CAN_LONG_ENTREGA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CAR_ID = Canhotos.CAR_ID,
                ORD_ID = Canhotos.ORD_ID,
                NOT_ID = Canhotos.NOT_ID,
                CAN_DATA_ENTREGA = Canhotos.CAN_DATA_ENTREGA,
                CAN_IMG = Canhotos.CAN_IMG,
                CAN_LAT_ENTREGA = Canhotos.CAN_LAT_ENTREGA,
                CAN_LONG_ENTREGA = Canhotos.CAN_LONG_ENTREGA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCanhotosQuery(ICanhotosEntity Canhotos)
        {
            this.Query = $@" UPDATE Canhotos SET CAR_ID = @CAR_ID, ORD_ID = @ORD_ID, NOT_ID = @NOT_ID, CAN_DATA_ENTREGA = @CAN_DATA_ENTREGA, CAN_IMG = @CAN_IMG, CAN_LAT_ENTREGA = @CAN_LAT_ENTREGA, CAN_LONG_ENTREGA = @CAN_LONG_ENTREGA, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID = Canhotos.CAR_ID,
                ORD_ID = Canhotos.ORD_ID,
                NOT_ID = Canhotos.NOT_ID,
                CAN_DATA_ENTREGA = Canhotos.CAN_DATA_ENTREGA,
                CAN_IMG = Canhotos.CAN_IMG,
                CAN_LAT_ENTREGA = Canhotos.CAN_LAT_ENTREGA,
                CAN_LONG_ENTREGA = Canhotos.CAN_LONG_ENTREGA,
                Changed = Canhotos.Changed,
                UserId = _executionContext.UserId,
                Id = Canhotos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID(int id, string value)
        {
            this.Query = $@" UPDATE Canhotos SET CAR_ID = @CAR_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE Canhotos SET ORD_ID = @ORD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateNOT_ID(int id, string value)
        {
            this.Query = $@" UPDATE Canhotos SET NOT_ID = @NOT_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                NOT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAN_DATA_ENTREGA(int id, DateTime value)
        {
            this.Query = $@" UPDATE Canhotos SET CAN_DATA_ENTREGA = @CAN_DATA_ENTREGA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAN_DATA_ENTREGA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAN_IMG(int id, string value)
        {
            this.Query = $@" UPDATE Canhotos SET CAN_IMG = @CAN_IMG WHERE Id = @Id ";
            this.Parameters = new
            {
                CAN_IMG = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAN_LAT_ENTREGA(int id, Decimal value)
        {
            this.Query = $@" UPDATE Canhotos SET CAN_LAT_ENTREGA = @CAN_LAT_ENTREGA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAN_LAT_ENTREGA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAN_LONG_ENTREGA(int id, Decimal value)
        {
            this.Query = $@" UPDATE Canhotos SET CAN_LONG_ENTREGA = @CAN_LONG_ENTREGA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAN_LONG_ENTREGA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Canhotos SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Canhotos SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Canhotos SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Canhotos SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCanhotosQuery(ICanhotosEntity Canhotos)
        {
            this.Query = $@" DELETE FROM Canhotos WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Canhotos.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration