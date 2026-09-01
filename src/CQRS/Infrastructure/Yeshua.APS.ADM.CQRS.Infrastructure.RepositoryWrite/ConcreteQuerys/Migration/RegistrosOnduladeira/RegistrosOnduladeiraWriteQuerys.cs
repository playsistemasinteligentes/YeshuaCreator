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
    public class RegistrosOnduladeiraQueryWrite : QueryBase, IRegistrosOnduladeiraQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public RegistrosOnduladeiraQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirRegistrosOnduladeiraQuery(IRegistrosOnduladeiraEntity RegistrosOnduladeira)
        {
            this.Query = $@" INSERT INTO RegistrosOnduladeira (REG_ID, REG_RESPOSTA, REG_STATUS, REG_DATA_INICIO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@REG_ID, @REG_RESPOSTA, @REG_STATUS, @REG_DATA_INICIO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                REG_ID = RegistrosOnduladeira.REG_ID,
                REG_RESPOSTA = RegistrosOnduladeira.REG_RESPOSTA,
                REG_STATUS = RegistrosOnduladeira.REG_STATUS,
                REG_DATA_INICIO = RegistrosOnduladeira.REG_DATA_INICIO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateRegistrosOnduladeiraQuery(IRegistrosOnduladeiraEntity RegistrosOnduladeira)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET REG_ID = @REG_ID, REG_RESPOSTA = @REG_RESPOSTA, REG_STATUS = @REG_STATUS, REG_DATA_INICIO = @REG_DATA_INICIO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                REG_ID = RegistrosOnduladeira.REG_ID,
                REG_RESPOSTA = RegistrosOnduladeira.REG_RESPOSTA,
                REG_STATUS = RegistrosOnduladeira.REG_STATUS,
                REG_DATA_INICIO = RegistrosOnduladeira.REG_DATA_INICIO,
                Changed = RegistrosOnduladeira.Changed,
                UserId = _executionContext.UserId,
                Id = RegistrosOnduladeira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREG_ID(int id, int value)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET REG_ID = @REG_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                REG_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREG_RESPOSTA(int id, string value)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET REG_RESPOSTA = @REG_RESPOSTA WHERE Id = @Id ";
            this.Parameters = new
            {
                REG_RESPOSTA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREG_STATUS(int id, string value)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET REG_STATUS = @REG_STATUS WHERE Id = @Id ";
            this.Parameters = new
            {
                REG_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateREG_DATA_INICIO(int id, DateTime value)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET REG_DATA_INICIO = @REG_DATA_INICIO WHERE Id = @Id ";
            this.Parameters = new
            {
                REG_DATA_INICIO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE RegistrosOnduladeira SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteRegistrosOnduladeiraQuery(IRegistrosOnduladeiraEntity RegistrosOnduladeira)
        {
            this.Query = $@" DELETE FROM RegistrosOnduladeira WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = RegistrosOnduladeira.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration