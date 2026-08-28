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
    public class RotaRealizadaQueryWrite : QueryBase, IRotaRealizadaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RotaRealizadaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRotaRealizadaQuery(IRotaRealizadaEntity RotaRealizada)
        {
            this.Query = $@" INSERT INTO RotaRealizada (CAR_ID, ROT_DATA_HORA, ROT_LAT, ROT_LONG, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.ROT_ID VALUES(@CAR_ID, @ROT_DATA_HORA, @ROT_LAT, @ROT_LONG, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CAR_ID = RotaRealizada.CAR_ID,
                ROT_DATA_HORA = RotaRealizada.ROT_DATA_HORA,
                ROT_LAT = RotaRealizada.ROT_LAT,
                ROT_LONG = RotaRealizada.ROT_LONG,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRotaRealizadaQuery(IRotaRealizadaEntity RotaRealizada)
        {
            this.Query = $@" UPDATE RotaRealizada SET CAR_ID = @CAR_ID, ROT_DATA_HORA = @ROT_DATA_HORA, ROT_LAT = @ROT_LAT, ROT_LONG = @ROT_LONG, Changed = @Changed, UserId = @UserId WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                CAR_ID = RotaRealizada.CAR_ID,
                ROT_DATA_HORA = RotaRealizada.ROT_DATA_HORA,
                ROT_LAT = RotaRealizada.ROT_LAT,
                ROT_LONG = RotaRealizada.ROT_LONG,
                Changed = RotaRealizada.Changed,
                UserId = _executionContext.UserId,
                ROT_ID = RotaRealizada.ROT_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID(int rot_id, string value)
        {
            this.Query = $@" UPDATE RotaRealizada SET CAR_ID = @CAR_ID WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                CAR_ID = value,
                ROT_ID = rot_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_DATA_HORA(int rot_id, DateTime value)
        {
            this.Query = $@" UPDATE RotaRealizada SET ROT_DATA_HORA = @ROT_DATA_HORA WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                ROT_DATA_HORA = value,
                ROT_ID = rot_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_LAT(int rot_id, Decimal value)
        {
            this.Query = $@" UPDATE RotaRealizada SET ROT_LAT = @ROT_LAT WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                ROT_LAT = value,
                ROT_ID = rot_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_LONG(int rot_id, Decimal value)
        {
            this.Query = $@" UPDATE RotaRealizada SET ROT_LONG = @ROT_LONG WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                ROT_LONG = value,
                ROT_ID = rot_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int rot_id, int value)
        {
            this.Query = $@" UPDATE RotaRealizada SET TenantID = @TenantID WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                TenantID = value,
                ROT_ID = rot_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int rot_id, bool value)
        {
            this.Query = $@" UPDATE RotaRealizada SET Deleted = @Deleted WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                Deleted = value,
                ROT_ID = rot_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int rot_id, DateTime value)
        {
            this.Query = $@" UPDATE RotaRealizada SET Changed = @Changed WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                Changed = value,
                ROT_ID = rot_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int rot_id, int value)
        {
            this.Query = $@" UPDATE RotaRealizada SET UserId = @UserId WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                UserId = value,
                ROT_ID = rot_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRotaRealizadaQuery(IRotaRealizadaEntity RotaRealizada)
        {
            this.Query = $@" DELETE FROM RotaRealizada WHERE ROT_ID = @ROT_ID ";
            this.Parameters = new
            {
                ROT_ID = RotaRealizada.ROT_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration