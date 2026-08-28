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
    public class SubOcorrenciaQueryWrite : QueryBase, ISubOcorrenciaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public SubOcorrenciaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirSubOcorrenciaQuery(ISubOcorrenciaEntity SubOcorrencia)
        {
            this.Query = $@" INSERT INTO SubOcorrencia (SUB_ID, SUB_DESCRICAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@SUB_ID, @SUB_DESCRICAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                SUB_ID = SubOcorrencia.SUB_ID,
                SUB_DESCRICAO = SubOcorrencia.SUB_DESCRICAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSubOcorrenciaQuery(ISubOcorrenciaEntity SubOcorrencia)
        {
            this.Query = $@" UPDATE SubOcorrencia SET SUB_ID = @SUB_ID, SUB_DESCRICAO = @SUB_DESCRICAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                SUB_ID = SubOcorrencia.SUB_ID,
                SUB_DESCRICAO = SubOcorrencia.SUB_DESCRICAO,
                Changed = SubOcorrencia.Changed,
                UserId = _executionContext.UserId,
                Id = SubOcorrencia.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSUB_ID(int id, string value)
        {
            this.Query = $@" UPDATE SubOcorrencia SET SUB_ID = @SUB_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                SUB_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSUB_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE SubOcorrencia SET SUB_DESCRICAO = @SUB_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                SUB_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE SubOcorrencia SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE SubOcorrencia SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE SubOcorrencia SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE SubOcorrencia SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteSubOcorrenciaQuery(ISubOcorrenciaEntity SubOcorrencia)
        {
            this.Query = $@" DELETE FROM SubOcorrencia WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = SubOcorrencia.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration