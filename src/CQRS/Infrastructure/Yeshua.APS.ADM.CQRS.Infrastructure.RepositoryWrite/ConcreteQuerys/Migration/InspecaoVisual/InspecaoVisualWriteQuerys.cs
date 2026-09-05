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
    public class InspecaoVisualQueryWrite : QueryBase, IInspecaoVisualQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public InspecaoVisualQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirInspecaoVisualQuery(IInspecaoVisualEntity InspecaoVisual)
        {
            this.Query = $@" INSERT INTO [InspecaoVisual] ([IPV_VALOR], [IPV_ID_OPERADOR], [IPV_ID_LIBERACAO], [IPV_OBS], [IPV_DATA_COLETA], [IPV_DATA_AVAL], [TIV_ID], [TURN_ID], [TURM_ID], [ORD_ID], [ROT_PRO_ID], [ROT_MAQ_ID], [ROT_SEQ_TRANSFORMACAO], [FPR_SEQ_REPETICAO], [IPV_STATUS_LIBERACAO], [IPV_VALOR_MEDIDA], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[IPV_ID] VALUES(@IPV_VALOR, @IPV_ID_OPERADOR, @IPV_ID_LIBERACAO, @IPV_OBS, @IPV_DATA_COLETA, @IPV_DATA_AVAL, @TIV_ID, @TURN_ID, @TURM_ID, @ORD_ID, @ROT_PRO_ID, @ROT_MAQ_ID, @ROT_SEQ_TRANSFORMACAO, @FPR_SEQ_REPETICAO, @IPV_STATUS_LIBERACAO, @IPV_VALOR_MEDIDA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                IPV_VALOR = InspecaoVisual.IPV_VALOR,
                IPV_ID_OPERADOR = InspecaoVisual.IPV_ID_OPERADOR,
                IPV_ID_LIBERACAO = InspecaoVisual.IPV_ID_LIBERACAO,
                IPV_OBS = InspecaoVisual.IPV_OBS,
                IPV_DATA_COLETA = InspecaoVisual.IPV_DATA_COLETA,
                IPV_DATA_AVAL = InspecaoVisual.IPV_DATA_AVAL,
                TIV_ID = InspecaoVisual.TIV_ID,
                TURN_ID = InspecaoVisual.TURN_ID,
                TURM_ID = InspecaoVisual.TURM_ID,
                ORD_ID = InspecaoVisual.ORD_ID,
                ROT_PRO_ID = InspecaoVisual.ROT_PRO_ID,
                ROT_MAQ_ID = InspecaoVisual.ROT_MAQ_ID,
                ROT_SEQ_TRANSFORMACAO = InspecaoVisual.ROT_SEQ_TRANSFORMACAO,
                FPR_SEQ_REPETICAO = InspecaoVisual.FPR_SEQ_REPETICAO,
                IPV_STATUS_LIBERACAO = InspecaoVisual.IPV_STATUS_LIBERACAO,
                IPV_VALOR_MEDIDA = InspecaoVisual.IPV_VALOR_MEDIDA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateInspecaoVisualQuery(IInspecaoVisualEntity InspecaoVisual)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_VALOR] = @IPV_VALOR, [IPV_ID_OPERADOR] = @IPV_ID_OPERADOR, [IPV_ID_LIBERACAO] = @IPV_ID_LIBERACAO, [IPV_OBS] = @IPV_OBS, [IPV_DATA_COLETA] = @IPV_DATA_COLETA, [IPV_DATA_AVAL] = @IPV_DATA_AVAL, [TIV_ID] = @TIV_ID, [TURN_ID] = @TURN_ID, [TURM_ID] = @TURM_ID, [ORD_ID] = @ORD_ID, [ROT_PRO_ID] = @ROT_PRO_ID, [ROT_MAQ_ID] = @ROT_MAQ_ID, [ROT_SEQ_TRANSFORMACAO] = @ROT_SEQ_TRANSFORMACAO, [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO, [IPV_STATUS_LIBERACAO] = @IPV_STATUS_LIBERACAO, [IPV_VALOR_MEDIDA] = @IPV_VALOR_MEDIDA, [Changed] = @Changed, [UserId] = @UserId WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_VALOR = InspecaoVisual.IPV_VALOR,
                IPV_ID_OPERADOR = InspecaoVisual.IPV_ID_OPERADOR,
                IPV_ID_LIBERACAO = InspecaoVisual.IPV_ID_LIBERACAO,
                IPV_OBS = InspecaoVisual.IPV_OBS,
                IPV_DATA_COLETA = InspecaoVisual.IPV_DATA_COLETA,
                IPV_DATA_AVAL = InspecaoVisual.IPV_DATA_AVAL,
                TIV_ID = InspecaoVisual.TIV_ID,
                TURN_ID = InspecaoVisual.TURN_ID,
                TURM_ID = InspecaoVisual.TURM_ID,
                ORD_ID = InspecaoVisual.ORD_ID,
                ROT_PRO_ID = InspecaoVisual.ROT_PRO_ID,
                ROT_MAQ_ID = InspecaoVisual.ROT_MAQ_ID,
                ROT_SEQ_TRANSFORMACAO = InspecaoVisual.ROT_SEQ_TRANSFORMACAO,
                FPR_SEQ_REPETICAO = InspecaoVisual.FPR_SEQ_REPETICAO,
                IPV_STATUS_LIBERACAO = InspecaoVisual.IPV_STATUS_LIBERACAO,
                IPV_VALOR_MEDIDA = InspecaoVisual.IPV_VALOR_MEDIDA,
                Changed = InspecaoVisual.Changed,
                UserId = _executionContext.UserId,
                IPV_ID = InspecaoVisual.IPV_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_VALOR(int ipv_id, string value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_VALOR] = @IPV_VALOR WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_VALOR = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_ID_OPERADOR(int ipv_id, int value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_ID_OPERADOR] = @IPV_ID_OPERADOR WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_ID_OPERADOR = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_ID_LIBERACAO(int ipv_id, int value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_ID_LIBERACAO] = @IPV_ID_LIBERACAO WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_ID_LIBERACAO = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_OBS(int ipv_id, string value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_OBS] = @IPV_OBS WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_OBS = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_DATA_COLETA(int ipv_id, DateTime value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_DATA_COLETA] = @IPV_DATA_COLETA WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_DATA_COLETA = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_DATA_AVAL(int ipv_id, DateTime value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_DATA_AVAL] = @IPV_DATA_AVAL WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_DATA_AVAL = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIV_ID(int ipv_id, int value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [TIV_ID] = @TIV_ID WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                TIV_ID = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_ID(int ipv_id, string value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [TURN_ID] = @TURN_ID WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                TURN_ID = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_ID(int ipv_id, string value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [TURM_ID] = @TURM_ID WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                TURM_ID = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int ipv_id, string value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [ORD_ID] = @ORD_ID WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                ORD_ID = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_PRO_ID(int ipv_id, string value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [ROT_PRO_ID] = @ROT_PRO_ID WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                ROT_PRO_ID = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_MAQ_ID(int ipv_id, string value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [ROT_MAQ_ID] = @ROT_MAQ_ID WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                ROT_MAQ_ID = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_SEQ_TRANSFORMACAO(int ipv_id, int value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [ROT_SEQ_TRANSFORMACAO] = @ROT_SEQ_TRANSFORMACAO WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                ROT_SEQ_TRANSFORMACAO = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int ipv_id, int value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_STATUS_LIBERACAO(int ipv_id, string value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_STATUS_LIBERACAO] = @IPV_STATUS_LIBERACAO WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_STATUS_LIBERACAO = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIPV_VALOR_MEDIDA(int ipv_id, Decimal value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [IPV_VALOR_MEDIDA] = @IPV_VALOR_MEDIDA WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_VALOR_MEDIDA = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int ipv_id, int value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [TenantID] = @TenantID WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                TenantID = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int ipv_id, bool value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [Deleted] = @Deleted WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                Deleted = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int ipv_id, DateTime value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [Changed] = @Changed WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                Changed = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int ipv_id, int value)
        {
            this.Query = $@" UPDATE [InspecaoVisual] SET [UserId] = @UserId WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                UserId = value,
                IPV_ID = ipv_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteInspecaoVisualQuery(IInspecaoVisualEntity InspecaoVisual)
        {
            this.Query = $@" DELETE FROM [InspecaoVisual] WHERE [IPV_ID] = @IPV_ID ";
            this.Parameters = new
            {
                IPV_ID = InspecaoVisual.IPV_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration