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
    public class SegmentoQueryWrite : QueryBase, ISegmentoQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public SegmentoQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirSegmentoQuery(ISegmentoEntity Segmento)
        {
            this.Query = $@" INSERT INTO Segmento (SEG_ID, SEG_DESCRICAO, SEG_ID_SEGUIMENTO_PAI, GRS_ID, SEG_INTEGRACAO_ERP, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@SEG_ID, @SEG_DESCRICAO, @SEG_ID_SEGUIMENTO_PAI, @GRS_ID, @SEG_INTEGRACAO_ERP, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                SEG_ID = Segmento.SEG_ID,
                SEG_DESCRICAO = Segmento.SEG_DESCRICAO,
                SEG_ID_SEGUIMENTO_PAI = Segmento.SEG_ID_SEGUIMENTO_PAI,
                GRS_ID = Segmento.GRS_ID,
                SEG_INTEGRACAO_ERP = Segmento.SEG_INTEGRACAO_ERP,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSegmentoQuery(ISegmentoEntity Segmento)
        {
            this.Query = $@" UPDATE Segmento SET SEG_ID = @SEG_ID, SEG_DESCRICAO = @SEG_DESCRICAO, SEG_ID_SEGUIMENTO_PAI = @SEG_ID_SEGUIMENTO_PAI, GRS_ID = @GRS_ID, SEG_INTEGRACAO_ERP = @SEG_INTEGRACAO_ERP, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                SEG_ID = Segmento.SEG_ID,
                SEG_DESCRICAO = Segmento.SEG_DESCRICAO,
                SEG_ID_SEGUIMENTO_PAI = Segmento.SEG_ID_SEGUIMENTO_PAI,
                GRS_ID = Segmento.GRS_ID,
                SEG_INTEGRACAO_ERP = Segmento.SEG_INTEGRACAO_ERP,
                Changed = Segmento.Changed,
                UserId = _executionContext.UserId,
                Id = Segmento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEG_ID(int id, string value)
        {
            this.Query = $@" UPDATE Segmento SET SEG_ID = @SEG_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                SEG_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEG_DESCRICAO(int id, string value)
        {
            this.Query = $@" UPDATE Segmento SET SEG_DESCRICAO = @SEG_DESCRICAO WHERE Id = @Id ";
            this.Parameters = new
            {
                SEG_DESCRICAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEG_ID_SEGUIMENTO_PAI(int id, string value)
        {
            this.Query = $@" UPDATE Segmento SET SEG_ID_SEGUIMENTO_PAI = @SEG_ID_SEGUIMENTO_PAI WHERE Id = @Id ";
            this.Parameters = new
            {
                SEG_ID_SEGUIMENTO_PAI = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGRS_ID(int id, string value)
        {
            this.Query = $@" UPDATE Segmento SET GRS_ID = @GRS_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                GRS_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSEG_INTEGRACAO_ERP(int id, string value)
        {
            this.Query = $@" UPDATE Segmento SET SEG_INTEGRACAO_ERP = @SEG_INTEGRACAO_ERP WHERE Id = @Id ";
            this.Parameters = new
            {
                SEG_INTEGRACAO_ERP = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Segmento SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Segmento SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Segmento SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Segmento SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteSegmentoQuery(ISegmentoEntity Segmento)
        {
            this.Query = $@" DELETE FROM Segmento WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Segmento.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration