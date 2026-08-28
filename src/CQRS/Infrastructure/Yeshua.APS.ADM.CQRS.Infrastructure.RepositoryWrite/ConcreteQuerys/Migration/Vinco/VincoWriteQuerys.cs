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
    public class VincoQueryWrite : QueryBase, IVincoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public VincoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirVincoQuery(IVincoEntity Vinco)
        {
            this.Query = $@" INSERT INTO Vinco (VIN_ID, VIN_DESCRICAO, VIN_ID_DESLOCAMENTO, TenantID, Deleted, Changed, UserId) VALUES(@VIN_ID, @VIN_DESCRICAO, @VIN_ID_DESLOCAMENTO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                VIN_ID = Vinco.VIN_ID,
                VIN_DESCRICAO = Vinco.VIN_DESCRICAO,
                VIN_ID_DESLOCAMENTO = Vinco.VIN_ID_DESLOCAMENTO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVincoQuery(IVincoEntity Vinco)
        {
            this.Query = $@" UPDATE Vinco SET VIN_DESCRICAO = @VIN_DESCRICAO, VIN_ID_DESLOCAMENTO = @VIN_ID_DESLOCAMENTO, Changed = @Changed, UserId = @UserId WHERE VIN_ID = @VIN_ID ";
            this.Parameters = new
            {
                VIN_DESCRICAO = Vinco.VIN_DESCRICAO,
                VIN_ID_DESLOCAMENTO = Vinco.VIN_ID_DESLOCAMENTO,
                Changed = Vinco.Changed,
                UserId = _executionContext.UserId,
                VIN_ID = Vinco.VIN_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVIN_DESCRICAO(int vin_id, string value)
        {
            this.Query = $@" UPDATE Vinco SET VIN_DESCRICAO = @VIN_DESCRICAO WHERE VIN_ID = @VIN_ID ";
            this.Parameters = new
            {
                VIN_DESCRICAO = value,
                VIN_ID = vin_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVIN_ID_DESLOCAMENTO(int vin_id, string value)
        {
            this.Query = $@" UPDATE Vinco SET VIN_ID_DESLOCAMENTO = @VIN_ID_DESLOCAMENTO WHERE VIN_ID = @VIN_ID ";
            this.Parameters = new
            {
                VIN_ID_DESLOCAMENTO = value,
                VIN_ID = vin_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int vin_id, int value)
        {
            this.Query = $@" UPDATE Vinco SET TenantID = @TenantID WHERE VIN_ID = @VIN_ID ";
            this.Parameters = new
            {
                TenantID = value,
                VIN_ID = vin_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int vin_id, bool value)
        {
            this.Query = $@" UPDATE Vinco SET Deleted = @Deleted WHERE VIN_ID = @VIN_ID ";
            this.Parameters = new
            {
                Deleted = value,
                VIN_ID = vin_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int vin_id, DateTime value)
        {
            this.Query = $@" UPDATE Vinco SET Changed = @Changed WHERE VIN_ID = @VIN_ID ";
            this.Parameters = new
            {
                Changed = value,
                VIN_ID = vin_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int vin_id, int value)
        {
            this.Query = $@" UPDATE Vinco SET UserId = @UserId WHERE VIN_ID = @VIN_ID ";
            this.Parameters = new
            {
                UserId = value,
                VIN_ID = vin_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteVincoQuery(IVincoEntity Vinco)
        {
            this.Query = $@" DELETE FROM Vinco WHERE VIN_ID = @VIN_ID ";
            this.Parameters = new
            {
                VIN_ID = Vinco.VIN_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration