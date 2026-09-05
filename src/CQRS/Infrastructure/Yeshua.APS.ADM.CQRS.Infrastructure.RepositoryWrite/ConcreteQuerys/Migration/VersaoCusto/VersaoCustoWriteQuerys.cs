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
    public class VersaoCustoQueryWrite : QueryBase, IVersaoCustoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public VersaoCustoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirVersaoCustoQuery(IVersaoCustoEntity VersaoCusto)
        {
            this.Query = $@" INSERT INTO [VersaoCusto] ([VER_ID], [VER_STATUS], [VER_OBS], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@VER_ID, @VER_STATUS, @VER_OBS, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                VER_ID = VersaoCusto.VER_ID,
                VER_STATUS = VersaoCusto.VER_STATUS,
                VER_OBS = VersaoCusto.VER_OBS,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVersaoCustoQuery(IVersaoCustoEntity VersaoCusto)
        {
            this.Query = $@" UPDATE [VersaoCusto] SET [VER_ID] = @VER_ID, [VER_STATUS] = @VER_STATUS, [VER_OBS] = @VER_OBS, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VER_ID = VersaoCusto.VER_ID,
                VER_STATUS = VersaoCusto.VER_STATUS,
                VER_OBS = VersaoCusto.VER_OBS,
                Changed = VersaoCusto.Changed,
                UserId = _executionContext.UserId,
                Id = VersaoCusto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_ID(int id, int value)
        {
            this.Query = $@" UPDATE [VersaoCusto] SET [VER_ID] = @VER_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VER_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE [VersaoCusto] SET [VER_STATUS] = @VER_STATUS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VER_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVER_OBS(int id, string value)
        {
            this.Query = $@" UPDATE [VersaoCusto] SET [VER_OBS] = @VER_OBS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VER_OBS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [VersaoCusto] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [VersaoCusto] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [VersaoCusto] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [VersaoCusto] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteVersaoCustoQuery(IVersaoCustoEntity VersaoCusto)
        {
            this.Query = $@" DELETE FROM [VersaoCusto] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = VersaoCusto.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration