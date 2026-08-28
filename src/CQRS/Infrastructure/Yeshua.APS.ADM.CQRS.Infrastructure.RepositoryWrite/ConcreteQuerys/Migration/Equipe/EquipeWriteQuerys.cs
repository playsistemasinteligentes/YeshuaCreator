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
    public class EquipeQueryWrite : QueryBase, IEquipeQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EquipeQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEquipeQuery(IEquipeEntity Equipe)
        {
            this.Query = $@" INSERT INTO Equipe (EQU_ID, EQU_HIERARQUIA_SEQ_TRANSFORMACAO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@EQU_ID, @EQU_HIERARQUIA_SEQ_TRANSFORMACAO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                EQU_ID = Equipe.EQU_ID,
                EQU_HIERARQUIA_SEQ_TRANSFORMACAO = Equipe.EQU_HIERARQUIA_SEQ_TRANSFORMACAO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEquipeQuery(IEquipeEntity Equipe)
        {
            this.Query = $@" UPDATE Equipe SET EQU_ID = @EQU_ID, EQU_HIERARQUIA_SEQ_TRANSFORMACAO = @EQU_HIERARQUIA_SEQ_TRANSFORMACAO, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                EQU_ID = Equipe.EQU_ID,
                EQU_HIERARQUIA_SEQ_TRANSFORMACAO = Equipe.EQU_HIERARQUIA_SEQ_TRANSFORMACAO,
                Changed = Equipe.Changed,
                UserId = _executionContext.UserId,
                Id = Equipe.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEQU_ID(int id, string value)
        {
            this.Query = $@" UPDATE Equipe SET EQU_ID = @EQU_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                EQU_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEQU_HIERARQUIA_SEQ_TRANSFORMACAO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Equipe SET EQU_HIERARQUIA_SEQ_TRANSFORMACAO = @EQU_HIERARQUIA_SEQ_TRANSFORMACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                EQU_HIERARQUIA_SEQ_TRANSFORMACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Equipe SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Equipe SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Equipe SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Equipe SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEquipeQuery(IEquipeEntity Equipe)
        {
            this.Query = $@" DELETE FROM Equipe WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Equipe.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration