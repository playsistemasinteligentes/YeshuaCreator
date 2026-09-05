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
    public class PendenciasInterfaceQueryWrite : QueryBase, IPendenciasInterfaceQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public PendenciasInterfaceQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirPendenciasInterfaceQuery(IPendenciasInterfaceEntity PendenciasInterface)
        {
            this.Query = $@" INSERT INTO [PendenciasInterface] ([PEN_STATUS_OUT], [PEN_PROTOCOLO_OUT], [PEN_ID_PROTOCOLO_OUT], [PEN_STATUS_IN], [PEN_PROTOCOLO_IN], [PEN_ID_PROTOCOLO_IN], [DATA_ENTRADA], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[PEN_ID] VALUES(@PEN_STATUS_OUT, @PEN_PROTOCOLO_OUT, @PEN_ID_PROTOCOLO_OUT, @PEN_STATUS_IN, @PEN_PROTOCOLO_IN, @PEN_ID_PROTOCOLO_IN, @DATA_ENTRADA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                PEN_STATUS_OUT = PendenciasInterface.PEN_STATUS_OUT,
                PEN_PROTOCOLO_OUT = PendenciasInterface.PEN_PROTOCOLO_OUT,
                PEN_ID_PROTOCOLO_OUT = PendenciasInterface.PEN_ID_PROTOCOLO_OUT,
                PEN_STATUS_IN = PendenciasInterface.PEN_STATUS_IN,
                PEN_PROTOCOLO_IN = PendenciasInterface.PEN_PROTOCOLO_IN,
                PEN_ID_PROTOCOLO_IN = PendenciasInterface.PEN_ID_PROTOCOLO_IN,
                DATA_ENTRADA = PendenciasInterface.DATA_ENTRADA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePendenciasInterfaceQuery(IPendenciasInterfaceEntity PendenciasInterface)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [PEN_STATUS_OUT] = @PEN_STATUS_OUT, [PEN_PROTOCOLO_OUT] = @PEN_PROTOCOLO_OUT, [PEN_ID_PROTOCOLO_OUT] = @PEN_ID_PROTOCOLO_OUT, [PEN_STATUS_IN] = @PEN_STATUS_IN, [PEN_PROTOCOLO_IN] = @PEN_PROTOCOLO_IN, [PEN_ID_PROTOCOLO_IN] = @PEN_ID_PROTOCOLO_IN, [DATA_ENTRADA] = @DATA_ENTRADA, [Changed] = @Changed, [UserId] = @UserId WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                PEN_STATUS_OUT = PendenciasInterface.PEN_STATUS_OUT,
                PEN_PROTOCOLO_OUT = PendenciasInterface.PEN_PROTOCOLO_OUT,
                PEN_ID_PROTOCOLO_OUT = PendenciasInterface.PEN_ID_PROTOCOLO_OUT,
                PEN_STATUS_IN = PendenciasInterface.PEN_STATUS_IN,
                PEN_PROTOCOLO_IN = PendenciasInterface.PEN_PROTOCOLO_IN,
                PEN_ID_PROTOCOLO_IN = PendenciasInterface.PEN_ID_PROTOCOLO_IN,
                DATA_ENTRADA = PendenciasInterface.DATA_ENTRADA,
                Changed = PendenciasInterface.Changed,
                UserId = _executionContext.UserId,
                PEN_ID = PendenciasInterface.PEN_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePEN_STATUS_OUT(int pen_id, string value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [PEN_STATUS_OUT] = @PEN_STATUS_OUT WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                PEN_STATUS_OUT = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePEN_PROTOCOLO_OUT(int pen_id, string value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [PEN_PROTOCOLO_OUT] = @PEN_PROTOCOLO_OUT WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                PEN_PROTOCOLO_OUT = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePEN_ID_PROTOCOLO_OUT(int pen_id, string value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [PEN_ID_PROTOCOLO_OUT] = @PEN_ID_PROTOCOLO_OUT WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                PEN_ID_PROTOCOLO_OUT = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePEN_STATUS_IN(int pen_id, string value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [PEN_STATUS_IN] = @PEN_STATUS_IN WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                PEN_STATUS_IN = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePEN_PROTOCOLO_IN(int pen_id, string value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [PEN_PROTOCOLO_IN] = @PEN_PROTOCOLO_IN WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                PEN_PROTOCOLO_IN = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdatePEN_ID_PROTOCOLO_IN(int pen_id, string value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [PEN_ID_PROTOCOLO_IN] = @PEN_ID_PROTOCOLO_IN WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                PEN_ID_PROTOCOLO_IN = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDATA_ENTRADA(int pen_id, DateTime value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [DATA_ENTRADA] = @DATA_ENTRADA WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                DATA_ENTRADA = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int pen_id, int value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [TenantID] = @TenantID WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                TenantID = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int pen_id, bool value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [Deleted] = @Deleted WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                Deleted = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int pen_id, DateTime value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [Changed] = @Changed WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                Changed = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int pen_id, int value)
        {
            this.Query = $@" UPDATE [PendenciasInterface] SET [UserId] = @UserId WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                UserId = value,
                PEN_ID = pen_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeletePendenciasInterfaceQuery(IPendenciasInterfaceEntity PendenciasInterface)
        {
            this.Query = $@" DELETE FROM [PendenciasInterface] WHERE [PEN_ID] = @PEN_ID ";
            this.Parameters = new
            {
                PEN_ID = PendenciasInterface.PEN_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration