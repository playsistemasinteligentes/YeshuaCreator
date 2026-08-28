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
    public class TempoSetupOnduladeiraQueryWrite : QueryBase, ITempoSetupOnduladeiraQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public TempoSetupOnduladeiraQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirTempoSetupOnduladeiraQuery(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira)
        {
            this.Query = $@" INSERT INTO TempoSetupOnduladeira (OND_ID_DE, OND_ID_PARA, TEM_RESINA_DE, TEM_RESINA_PARA, TEM_TEMPO, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.TEM_ID VALUES(@OND_ID_DE, @OND_ID_PARA, @TEM_RESINA_DE, @TEM_RESINA_PARA, @TEM_TEMPO, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                OND_ID_DE = TempoSetupOnduladeira.OND_ID_DE,
                OND_ID_PARA = TempoSetupOnduladeira.OND_ID_PARA,
                TEM_RESINA_DE = TempoSetupOnduladeira.TEM_RESINA_DE,
                TEM_RESINA_PARA = TempoSetupOnduladeira.TEM_RESINA_PARA,
                TEM_TEMPO = TempoSetupOnduladeira.TEM_TEMPO,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTempoSetupOnduladeiraQuery(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET OND_ID_DE = @OND_ID_DE, OND_ID_PARA = @OND_ID_PARA, TEM_RESINA_DE = @TEM_RESINA_DE, TEM_RESINA_PARA = @TEM_RESINA_PARA, TEM_TEMPO = @TEM_TEMPO, Changed = @Changed, UserId = @UserId WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                OND_ID_DE = TempoSetupOnduladeira.OND_ID_DE,
                OND_ID_PARA = TempoSetupOnduladeira.OND_ID_PARA,
                TEM_RESINA_DE = TempoSetupOnduladeira.TEM_RESINA_DE,
                TEM_RESINA_PARA = TempoSetupOnduladeira.TEM_RESINA_PARA,
                TEM_TEMPO = TempoSetupOnduladeira.TEM_TEMPO,
                Changed = TempoSetupOnduladeira.Changed,
                UserId = _executionContext.UserId,
                TEM_ID = TempoSetupOnduladeira.TEM_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_ID_DE(int tem_id, string value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET OND_ID_DE = @OND_ID_DE WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                OND_ID_DE = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOND_ID_PARA(int tem_id, string value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET OND_ID_PARA = @OND_ID_PARA WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                OND_ID_PARA = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_RESINA_DE(int tem_id, string value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET TEM_RESINA_DE = @TEM_RESINA_DE WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TEM_RESINA_DE = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_RESINA_PARA(int tem_id, string value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET TEM_RESINA_PARA = @TEM_RESINA_PARA WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TEM_RESINA_PARA = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTEM_TEMPO(int tem_id, int value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET TEM_TEMPO = @TEM_TEMPO WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TEM_TEMPO = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int tem_id, int value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET TenantID = @TenantID WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TenantID = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int tem_id, bool value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET Deleted = @Deleted WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                Deleted = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int tem_id, DateTime value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET Changed = @Changed WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                Changed = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int tem_id, int value)
        {
            this.Query = $@" UPDATE TempoSetupOnduladeira SET UserId = @UserId WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                UserId = value,
                TEM_ID = tem_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteTempoSetupOnduladeiraQuery(ITempoSetupOnduladeiraEntity TempoSetupOnduladeira)
        {
            this.Query = $@" DELETE FROM TempoSetupOnduladeira WHERE TEM_ID = @TEM_ID ";
            this.Parameters = new
            {
                TEM_ID = TempoSetupOnduladeira.TEM_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration