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
    public class OcorrenciaQueryWrite : QueryBase, IOcorrenciaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public OcorrenciaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirOcorrenciaQuery(IOcorrenciaEntity Ocorrencia)
        {
            this.Query = $@" INSERT INTO [Ocorrencia] ([OCO_ID], [OCO_DESCRICAO], [TIP_ID], [GMA_ID], [MAQ_ID], [SPR], [OCO_SUB_TIPO], [SUB_ID], [TenantID], [Deleted], [Changed], [UserId]) VALUES(@OCO_ID, @OCO_DESCRICAO, @TIP_ID, @GMA_ID, @MAQ_ID, @SPR, @OCO_SUB_TIPO, @SUB_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                OCO_ID = Ocorrencia.OCO_ID,
                OCO_DESCRICAO = Ocorrencia.OCO_DESCRICAO,
                TIP_ID = Ocorrencia.TIP_ID,
                GMA_ID = Ocorrencia.GMA_ID,
                MAQ_ID = Ocorrencia.MAQ_ID,
                SPR = Ocorrencia.SPR,
                OCO_SUB_TIPO = Ocorrencia.OCO_SUB_TIPO,
                SUB_ID = Ocorrencia.SUB_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOcorrenciaQuery(IOcorrenciaEntity Ocorrencia)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [OCO_DESCRICAO] = @OCO_DESCRICAO, [TIP_ID] = @TIP_ID, [GMA_ID] = @GMA_ID, [MAQ_ID] = @MAQ_ID, [SPR] = @SPR, [OCO_SUB_TIPO] = @OCO_SUB_TIPO, [SUB_ID] = @SUB_ID, [Changed] = @Changed, [UserId] = @UserId WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                OCO_DESCRICAO = Ocorrencia.OCO_DESCRICAO,
                TIP_ID = Ocorrencia.TIP_ID,
                GMA_ID = Ocorrencia.GMA_ID,
                MAQ_ID = Ocorrencia.MAQ_ID,
                SPR = Ocorrencia.SPR,
                OCO_SUB_TIPO = Ocorrencia.OCO_SUB_TIPO,
                SUB_ID = Ocorrencia.SUB_ID,
                Changed = Ocorrencia.Changed,
                UserId = _executionContext.UserId,
                OCO_ID = Ocorrencia.OCO_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_DESCRICAO(string oco_id, string value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [OCO_DESCRICAO] = @OCO_DESCRICAO WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                OCO_DESCRICAO = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_ID(string oco_id, int value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [TIP_ID] = @TIP_ID WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                TIP_ID = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateGMA_ID(string oco_id, string value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [GMA_ID] = @GMA_ID WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                GMA_ID = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(string oco_id, string value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [MAQ_ID] = @MAQ_ID WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                MAQ_ID = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSPR(string oco_id, int value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [SPR] = @SPR WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                SPR = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_SUB_TIPO(string oco_id, string value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [OCO_SUB_TIPO] = @OCO_SUB_TIPO WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                OCO_SUB_TIPO = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateSUB_ID(string oco_id, string value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [SUB_ID] = @SUB_ID WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                SUB_ID = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(string oco_id, int value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [TenantID] = @TenantID WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                TenantID = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(string oco_id, bool value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [Deleted] = @Deleted WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                Deleted = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(string oco_id, DateTime value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [Changed] = @Changed WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                Changed = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(string oco_id, int value)
        {
            this.Query = $@" UPDATE [Ocorrencia] SET [UserId] = @UserId WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                UserId = value,
                OCO_ID = oco_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteOcorrenciaQuery(IOcorrenciaEntity Ocorrencia)
        {
            this.Query = $@" DELETE FROM [Ocorrencia] WHERE [OCO_ID] = @OCO_ID ";
            this.Parameters = new
            {
                OCO_ID = Ocorrencia.OCO_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration