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
    public class VisoesQueryWrite : QueryBase, IVisoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public VisoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirVisoesQuery(IVisoesEntity Visoes)
        {
            this.Query = $@" INSERT INTO Visoes (VIS_PLANID, VIS_FORMULA, CAB_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.VIS_ID VALUES(@VIS_PLANID, @VIS_FORMULA, @CAB_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                VIS_PLANID = Visoes.VIS_PLANID,
                VIS_FORMULA = Visoes.VIS_FORMULA,
                CAB_ID = Visoes.CAB_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVisoesQuery(IVisoesEntity Visoes)
        {
            this.Query = $@" UPDATE Visoes SET VIS_PLANID = @VIS_PLANID, VIS_FORMULA = @VIS_FORMULA, CAB_ID = @CAB_ID, Changed = @Changed, UserId = @UserId WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                VIS_PLANID = Visoes.VIS_PLANID,
                VIS_FORMULA = Visoes.VIS_FORMULA,
                CAB_ID = Visoes.CAB_ID,
                Changed = Visoes.Changed,
                UserId = _executionContext.UserId,
                VIS_ID = Visoes.VIS_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVIS_PLANID(int vis_id, int value)
        {
            this.Query = $@" UPDATE Visoes SET VIS_PLANID = @VIS_PLANID WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                VIS_PLANID = value,
                VIS_ID = vis_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVIS_FORMULA(int vis_id, string value)
        {
            this.Query = $@" UPDATE Visoes SET VIS_FORMULA = @VIS_FORMULA WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                VIS_FORMULA = value,
                VIS_ID = vis_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAB_ID(int vis_id, int value)
        {
            this.Query = $@" UPDATE Visoes SET CAB_ID = @CAB_ID WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                CAB_ID = value,
                VIS_ID = vis_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int vis_id, int value)
        {
            this.Query = $@" UPDATE Visoes SET TenantID = @TenantID WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                TenantID = value,
                VIS_ID = vis_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int vis_id, bool value)
        {
            this.Query = $@" UPDATE Visoes SET Deleted = @Deleted WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                Deleted = value,
                VIS_ID = vis_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int vis_id, DateTime value)
        {
            this.Query = $@" UPDATE Visoes SET Changed = @Changed WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                Changed = value,
                VIS_ID = vis_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int vis_id, int value)
        {
            this.Query = $@" UPDATE Visoes SET UserId = @UserId WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                UserId = value,
                VIS_ID = vis_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteVisoesQuery(IVisoesEntity Visoes)
        {
            this.Query = $@" DELETE FROM Visoes WHERE VIS_ID = @VIS_ID ";
            this.Parameters = new
            {
                VIS_ID = Visoes.VIS_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration