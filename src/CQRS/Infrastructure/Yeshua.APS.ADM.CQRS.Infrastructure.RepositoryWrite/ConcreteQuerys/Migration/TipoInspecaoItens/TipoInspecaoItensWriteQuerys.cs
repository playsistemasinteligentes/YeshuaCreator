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
    public class TipoInspecaoItensQueryWrite : QueryBase, ITipoInspecaoItensQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TipoInspecaoItensQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTipoInspecaoItensQuery(ITipoInspecaoItensEntity TipoInspecaoItens)
        {
            this.Query = $@" INSERT INTO TipoInspecaoItens (TII_ID, TIV_ID, ITI_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@TII_ID, @TIV_ID, @ITI_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                TII_ID = TipoInspecaoItens.TII_ID,
                TIV_ID = TipoInspecaoItens.TIV_ID,
                ITI_ID = TipoInspecaoItens.ITI_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTipoInspecaoItensQuery(ITipoInspecaoItensEntity TipoInspecaoItens)
        {
            this.Query = $@" UPDATE TipoInspecaoItens SET TII_ID = @TII_ID, TIV_ID = @TIV_ID, ITI_ID = @ITI_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                TII_ID = TipoInspecaoItens.TII_ID,
                TIV_ID = TipoInspecaoItens.TIV_ID,
                ITI_ID = TipoInspecaoItens.ITI_ID,
                Changed = TipoInspecaoItens.Changed,
                UserId = _executionContext.UserId,
                Id = TipoInspecaoItens.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTII_ID(int id, int value)
        {
            this.Query = $@" UPDATE TipoInspecaoItens SET TII_ID = @TII_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TII_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_ID(int id, int value)
        {
            this.Query = $@" UPDATE TipoInspecaoItens SET TIV_ID = @TIV_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TIV_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITI_ID(int id, int value)
        {
            this.Query = $@" UPDATE TipoInspecaoItens SET ITI_ID = @ITI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ITI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE TipoInspecaoItens SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE TipoInspecaoItens SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE TipoInspecaoItens SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE TipoInspecaoItens SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTipoInspecaoItensQuery(ITipoInspecaoItensEntity TipoInspecaoItens)
        {
            this.Query = $@" DELETE FROM TipoInspecaoItens WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = TipoInspecaoItens.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration