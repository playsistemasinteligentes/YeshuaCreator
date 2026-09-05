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
    public class UniuserQueryWrite : QueryBase, IUniuserQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public UniuserQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirUniuserQuery(IUniuserEntity Uniuser)
        {
            this.Query = $@" INSERT INTO [Uniuser] ([UNI_ID], [USE_ID], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[USERGRU_ID] VALUES(@UNI_ID, @USE_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                UNI_ID = Uniuser.UNI_ID,
                USE_ID = Uniuser.USE_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUniuserQuery(IUniuserEntity Uniuser)
        {
            this.Query = $@" UPDATE [Uniuser] SET [UNI_ID] = @UNI_ID, [USE_ID] = @USE_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [USERGRU_ID] = @USERGRU_ID ";
            this.Parameters = new
            {
                UNI_ID = Uniuser.UNI_ID,
                USE_ID = Uniuser.USE_ID,
                Changed = Uniuser.Changed,
                UserId = _executionContext.UserId,
                USERGRU_ID = Uniuser.USERGRU_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUNI_ID(int usergru_id, int value)
        {
            this.Query = $@" UPDATE [Uniuser] SET [UNI_ID] = @UNI_ID WHERE [USERGRU_ID] = @USERGRU_ID ";
            this.Parameters = new
            {
                UNI_ID = value,
                USERGRU_ID = usergru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int usergru_id, int value)
        {
            this.Query = $@" UPDATE [Uniuser] SET [USE_ID] = @USE_ID WHERE [USERGRU_ID] = @USERGRU_ID ";
            this.Parameters = new
            {
                USE_ID = value,
                USERGRU_ID = usergru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int usergru_id, int value)
        {
            this.Query = $@" UPDATE [Uniuser] SET [TenantID] = @TenantID WHERE [USERGRU_ID] = @USERGRU_ID ";
            this.Parameters = new
            {
                TenantID = value,
                USERGRU_ID = usergru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int usergru_id, bool value)
        {
            this.Query = $@" UPDATE [Uniuser] SET [Deleted] = @Deleted WHERE [USERGRU_ID] = @USERGRU_ID ";
            this.Parameters = new
            {
                Deleted = value,
                USERGRU_ID = usergru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int usergru_id, DateTime value)
        {
            this.Query = $@" UPDATE [Uniuser] SET [Changed] = @Changed WHERE [USERGRU_ID] = @USERGRU_ID ";
            this.Parameters = new
            {
                Changed = value,
                USERGRU_ID = usergru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int usergru_id, int value)
        {
            this.Query = $@" UPDATE [Uniuser] SET [UserId] = @UserId WHERE [USERGRU_ID] = @USERGRU_ID ";
            this.Parameters = new
            {
                UserId = value,
                USERGRU_ID = usergru_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteUniuserQuery(IUniuserEntity Uniuser)
        {
            this.Query = $@" DELETE FROM [Uniuser] WHERE [USERGRU_ID] = @USERGRU_ID ";
            this.Parameters = new
            {
                USERGRU_ID = Uniuser.USERGRU_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration