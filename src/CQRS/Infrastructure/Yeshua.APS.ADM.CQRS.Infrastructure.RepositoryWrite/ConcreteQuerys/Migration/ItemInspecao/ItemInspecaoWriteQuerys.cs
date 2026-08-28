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
    public class ItemInspecaoQueryWrite : QueryBase, IItemInspecaoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public ItemInspecaoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirItemInspecaoQuery(IItemInspecaoEntity ItemInspecao)
        {
            this.Query = $@" INSERT INTO ItemInspecao (ITI_DESC, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@ITI_DESC, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ITI_DESC = ItemInspecao.ITI_DESC,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateItemInspecaoQuery(IItemInspecaoEntity ItemInspecao)
        {
            this.Query = $@" UPDATE ItemInspecao SET ITI_ID = @ITI_ID, ITI_DESC = @ITI_DESC, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                ITI_ID = ItemInspecao.ITI_ID,
                ITI_DESC = ItemInspecao.ITI_DESC,
                Changed = ItemInspecao.Changed,
                UserId = _executionContext.UserId,
                Id = ItemInspecao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITI_ID(int id, int value)
        {
            this.Query = $@" UPDATE ItemInspecao SET ITI_ID = @ITI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ITI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITI_DESC(int id, string value)
        {
            this.Query = $@" UPDATE ItemInspecao SET ITI_DESC = @ITI_DESC WHERE Id = @Id ";
            this.Parameters = new
            {
                ITI_DESC = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE ItemInspecao SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE ItemInspecao SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE ItemInspecao SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE ItemInspecao SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteItemInspecaoQuery(IItemInspecaoEntity ItemInspecao)
        {
            this.Query = $@" DELETE FROM ItemInspecao WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = ItemInspecao.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration