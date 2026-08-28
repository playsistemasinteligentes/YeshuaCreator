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
    public class T_MAQUINAS_EQUIPESQueryWrite : QueryBase, IT_MAQUINAS_EQUIPESQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public T_MAQUINAS_EQUIPESQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirT_MAQUINAS_EQUIPESQuery(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES)
        {
            this.Query = $@" INSERT INTO T_MAQUINAS_EQUIPES (MAQ_ID, EQU_ID, CAL_ID, CLI_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@MAQ_ID, @EQU_ID, @CAL_ID, @CLI_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MAQ_ID = T_MAQUINAS_EQUIPES.MAQ_ID,
                EQU_ID = T_MAQUINAS_EQUIPES.EQU_ID,
                CAL_ID = T_MAQUINAS_EQUIPES.CAL_ID,
                CLI_ID = T_MAQUINAS_EQUIPES.CLI_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateT_MAQUINAS_EQUIPESQuery(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET MAQ_ID = @MAQ_ID, EQU_ID = @EQU_ID, CAL_ID = @CAL_ID, CLI_ID = @CLI_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID = T_MAQUINAS_EQUIPES.MAQ_ID,
                EQU_ID = T_MAQUINAS_EQUIPES.EQU_ID,
                CAL_ID = T_MAQUINAS_EQUIPES.CAL_ID,
                CLI_ID = T_MAQUINAS_EQUIPES.CLI_ID,
                Changed = T_MAQUINAS_EQUIPES.Changed,
                UserId = _executionContext.UserId,
                Id = T_MAQUINAS_EQUIPES.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int id, string value)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET MAQ_ID = @MAQ_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                MAQ_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEQU_ID(int id, string value)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET EQU_ID = @EQU_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                EQU_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAL_ID(int id, int value)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET CAL_ID = @CAL_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CAL_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCLI_ID(int id, string value)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET CLI_ID = @CLI_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CLI_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE T_MAQUINAS_EQUIPES SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteT_MAQUINAS_EQUIPESQuery(IT_MAQUINAS_EQUIPESEntity T_MAQUINAS_EQUIPES)
        {
            this.Query = $@" DELETE FROM T_MAQUINAS_EQUIPES WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = T_MAQUINAS_EQUIPES.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration