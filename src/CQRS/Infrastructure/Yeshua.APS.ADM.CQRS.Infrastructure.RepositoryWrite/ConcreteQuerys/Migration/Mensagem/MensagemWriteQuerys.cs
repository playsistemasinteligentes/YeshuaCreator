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
    public class MensagemQueryWrite : QueryBase, IMensagemQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public MensagemQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirMensagemQuery(IMensagemEntity Mensagem)
        {
            this.Query = $@" INSERT INTO Mensagem (MEN_ID, MEN_SEND, MEN_EMISSION, MEN_STATUS, MEN_RECEIVE, MEN_TYPE, MEN_QTD_TRY_SEND, MEN_DATE_TRY_SEND, TenantID, Deleted, Changed, UserId) VALUES(@MEN_ID, @MEN_SEND, @MEN_EMISSION, @MEN_STATUS, @MEN_RECEIVE, @MEN_TYPE, @MEN_QTD_TRY_SEND, @MEN_DATE_TRY_SEND, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                MEN_ID = Mensagem.MEN_ID,
                MEN_SEND = Mensagem.MEN_SEND,
                MEN_EMISSION = Mensagem.MEN_EMISSION,
                MEN_STATUS = Mensagem.MEN_STATUS,
                MEN_RECEIVE = Mensagem.MEN_RECEIVE,
                MEN_TYPE = Mensagem.MEN_TYPE,
                MEN_QTD_TRY_SEND = Mensagem.MEN_QTD_TRY_SEND,
                MEN_DATE_TRY_SEND = Mensagem.MEN_DATE_TRY_SEND,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMensagemQuery(IMensagemEntity Mensagem)
        {
            this.Query = $@" UPDATE Mensagem SET MEN_SEND = @MEN_SEND, MEN_EMISSION = @MEN_EMISSION, MEN_STATUS = @MEN_STATUS, MEN_RECEIVE = @MEN_RECEIVE, MEN_TYPE = @MEN_TYPE, MEN_QTD_TRY_SEND = @MEN_QTD_TRY_SEND, MEN_DATE_TRY_SEND = @MEN_DATE_TRY_SEND, Changed = @Changed, UserId = @UserId WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_SEND = Mensagem.MEN_SEND,
                MEN_EMISSION = Mensagem.MEN_EMISSION,
                MEN_STATUS = Mensagem.MEN_STATUS,
                MEN_RECEIVE = Mensagem.MEN_RECEIVE,
                MEN_TYPE = Mensagem.MEN_TYPE,
                MEN_QTD_TRY_SEND = Mensagem.MEN_QTD_TRY_SEND,
                MEN_DATE_TRY_SEND = Mensagem.MEN_DATE_TRY_SEND,
                Changed = Mensagem.Changed,
                UserId = _executionContext.UserId,
                MEN_ID = Mensagem.MEN_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEN_SEND(string men_id, string value)
        {
            this.Query = $@" UPDATE Mensagem SET MEN_SEND = @MEN_SEND WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_SEND = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEN_EMISSION(string men_id, DateTime value)
        {
            this.Query = $@" UPDATE Mensagem SET MEN_EMISSION = @MEN_EMISSION WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_EMISSION = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEN_STATUS(string men_id, string value)
        {
            this.Query = $@" UPDATE Mensagem SET MEN_STATUS = @MEN_STATUS WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_STATUS = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEN_RECEIVE(string men_id, string value)
        {
            this.Query = $@" UPDATE Mensagem SET MEN_RECEIVE = @MEN_RECEIVE WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_RECEIVE = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEN_TYPE(string men_id, string value)
        {
            this.Query = $@" UPDATE Mensagem SET MEN_TYPE = @MEN_TYPE WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_TYPE = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEN_QTD_TRY_SEND(string men_id, Decimal value)
        {
            this.Query = $@" UPDATE Mensagem SET MEN_QTD_TRY_SEND = @MEN_QTD_TRY_SEND WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_QTD_TRY_SEND = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMEN_DATE_TRY_SEND(string men_id, DateTime value)
        {
            this.Query = $@" UPDATE Mensagem SET MEN_DATE_TRY_SEND = @MEN_DATE_TRY_SEND WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_DATE_TRY_SEND = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string men_id, int value)
        {
            this.Query = $@" UPDATE Mensagem SET TenantID = @TenantID WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                TenantID = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string men_id, bool value)
        {
            this.Query = $@" UPDATE Mensagem SET Deleted = @Deleted WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                Deleted = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string men_id, DateTime value)
        {
            this.Query = $@" UPDATE Mensagem SET Changed = @Changed WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                Changed = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string men_id, int value)
        {
            this.Query = $@" UPDATE Mensagem SET UserId = @UserId WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                UserId = value,
                MEN_ID = men_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteMensagemQuery(IMensagemEntity Mensagem)
        {
            this.Query = $@" DELETE FROM Mensagem WHERE MEN_ID = @MEN_ID ";
            this.Parameters = new
            {
                MEN_ID = Mensagem.MEN_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration