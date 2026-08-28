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
    public class OptAlteracaoDimencoesQueryWrite : QueryBase, IOptAlteracaoDimencoesQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public OptAlteracaoDimencoesQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirOptAlteracaoDimencoesQuery(IOptAlteracaoDimencoesEntity OptAlteracaoDimencoes)
        {
            this.Query = $@" INSERT INTO OptAlteracaoDimencoes (OAD_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@OAD_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                OAD_ID = OptAlteracaoDimencoes.OAD_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOptAlteracaoDimencoesQuery(IOptAlteracaoDimencoesEntity OptAlteracaoDimencoes)
        {
            this.Query = $@" UPDATE OptAlteracaoDimencoes SET OAD_ID = @OAD_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                OAD_ID = OptAlteracaoDimencoes.OAD_ID,
                Changed = OptAlteracaoDimencoes.Changed,
                UserId = _executionContext.UserId,
                Id = OptAlteracaoDimencoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOAD_ID(int id, int value)
        {
            this.Query = $@" UPDATE OptAlteracaoDimencoes SET OAD_ID = @OAD_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                OAD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE OptAlteracaoDimencoes SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE OptAlteracaoDimencoes SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE OptAlteracaoDimencoes SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE OptAlteracaoDimencoes SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteOptAlteracaoDimencoesQuery(IOptAlteracaoDimencoesEntity OptAlteracaoDimencoes)
        {
            this.Query = $@" DELETE FROM OptAlteracaoDimencoes WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = OptAlteracaoDimencoes.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration