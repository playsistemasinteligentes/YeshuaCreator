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
    public class EtiquetaQueryWrite : QueryBase, IEtiquetaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public EtiquetaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirEtiquetaQuery(IEtiquetaEntity Etiqueta)
        {
            this.Query = $@" INSERT INTO [Etiqueta] ([ETI_EMISSAO], [ETI_CODIGO_BARRAS], [ETI_SEQUENCIA], [ETI_NUMERO_COPIAS], [ETI_STATUS], [ETI_DATA_FABRICACAO], [ETI_COD_BARRAS_ORIGINAL], [ETI_OP_ORIGINAL], [MAQ_ID], [IMP_ID], [USE_ID], [ORD_ID], [ROT_PRO_ID], [ROT_SEQ_TRANFORMACAO], [FPR_SEQ_REPETICAO], [ETI_QUANTIDADE_PALETE], [ETI_LOTE], [ETI_SUB_LOTE], [ETI_IMPRIMIR_DE], [ETI_IMPRIMIR_ATE], [BOL_ID], [COR_SEQUENCIA], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[ETI_ID] VALUES(@ETI_EMISSAO, @ETI_CODIGO_BARRAS, @ETI_SEQUENCIA, @ETI_NUMERO_COPIAS, @ETI_STATUS, @ETI_DATA_FABRICACAO, @ETI_COD_BARRAS_ORIGINAL, @ETI_OP_ORIGINAL, @MAQ_ID, @IMP_ID, @USE_ID, @ORD_ID, @ROT_PRO_ID, @ROT_SEQ_TRANFORMACAO, @FPR_SEQ_REPETICAO, @ETI_QUANTIDADE_PALETE, @ETI_LOTE, @ETI_SUB_LOTE, @ETI_IMPRIMIR_DE, @ETI_IMPRIMIR_ATE, @BOL_ID, @COR_SEQUENCIA, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                ETI_EMISSAO = Etiqueta.ETI_EMISSAO,
                ETI_CODIGO_BARRAS = Etiqueta.ETI_CODIGO_BARRAS,
                ETI_SEQUENCIA = Etiqueta.ETI_SEQUENCIA,
                ETI_NUMERO_COPIAS = Etiqueta.ETI_NUMERO_COPIAS,
                ETI_STATUS = Etiqueta.ETI_STATUS,
                ETI_DATA_FABRICACAO = Etiqueta.ETI_DATA_FABRICACAO,
                ETI_COD_BARRAS_ORIGINAL = Etiqueta.ETI_COD_BARRAS_ORIGINAL,
                ETI_OP_ORIGINAL = Etiqueta.ETI_OP_ORIGINAL,
                MAQ_ID = Etiqueta.MAQ_ID,
                IMP_ID = Etiqueta.IMP_ID,
                USE_ID = Etiqueta.USE_ID,
                ORD_ID = Etiqueta.ORD_ID,
                ROT_PRO_ID = Etiqueta.ROT_PRO_ID,
                ROT_SEQ_TRANFORMACAO = Etiqueta.ROT_SEQ_TRANFORMACAO,
                FPR_SEQ_REPETICAO = Etiqueta.FPR_SEQ_REPETICAO,
                ETI_QUANTIDADE_PALETE = Etiqueta.ETI_QUANTIDADE_PALETE,
                ETI_LOTE = Etiqueta.ETI_LOTE,
                ETI_SUB_LOTE = Etiqueta.ETI_SUB_LOTE,
                ETI_IMPRIMIR_DE = Etiqueta.ETI_IMPRIMIR_DE,
                ETI_IMPRIMIR_ATE = Etiqueta.ETI_IMPRIMIR_ATE,
                BOL_ID = Etiqueta.BOL_ID,
                COR_SEQUENCIA = Etiqueta.COR_SEQUENCIA,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateEtiquetaQuery(IEtiquetaEntity Etiqueta)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_EMISSAO] = @ETI_EMISSAO, [ETI_CODIGO_BARRAS] = @ETI_CODIGO_BARRAS, [ETI_SEQUENCIA] = @ETI_SEQUENCIA, [ETI_NUMERO_COPIAS] = @ETI_NUMERO_COPIAS, [ETI_STATUS] = @ETI_STATUS, [ETI_DATA_FABRICACAO] = @ETI_DATA_FABRICACAO, [ETI_COD_BARRAS_ORIGINAL] = @ETI_COD_BARRAS_ORIGINAL, [ETI_OP_ORIGINAL] = @ETI_OP_ORIGINAL, [MAQ_ID] = @MAQ_ID, [IMP_ID] = @IMP_ID, [USE_ID] = @USE_ID, [ORD_ID] = @ORD_ID, [ROT_PRO_ID] = @ROT_PRO_ID, [ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO, [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO, [ETI_QUANTIDADE_PALETE] = @ETI_QUANTIDADE_PALETE, [ETI_LOTE] = @ETI_LOTE, [ETI_SUB_LOTE] = @ETI_SUB_LOTE, [ETI_IMPRIMIR_DE] = @ETI_IMPRIMIR_DE, [ETI_IMPRIMIR_ATE] = @ETI_IMPRIMIR_ATE, [BOL_ID] = @BOL_ID, [COR_SEQUENCIA] = @COR_SEQUENCIA, [Changed] = @Changed, [UserId] = @UserId WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_EMISSAO = Etiqueta.ETI_EMISSAO,
                ETI_CODIGO_BARRAS = Etiqueta.ETI_CODIGO_BARRAS,
                ETI_SEQUENCIA = Etiqueta.ETI_SEQUENCIA,
                ETI_NUMERO_COPIAS = Etiqueta.ETI_NUMERO_COPIAS,
                ETI_STATUS = Etiqueta.ETI_STATUS,
                ETI_DATA_FABRICACAO = Etiqueta.ETI_DATA_FABRICACAO,
                ETI_COD_BARRAS_ORIGINAL = Etiqueta.ETI_COD_BARRAS_ORIGINAL,
                ETI_OP_ORIGINAL = Etiqueta.ETI_OP_ORIGINAL,
                MAQ_ID = Etiqueta.MAQ_ID,
                IMP_ID = Etiqueta.IMP_ID,
                USE_ID = Etiqueta.USE_ID,
                ORD_ID = Etiqueta.ORD_ID,
                ROT_PRO_ID = Etiqueta.ROT_PRO_ID,
                ROT_SEQ_TRANFORMACAO = Etiqueta.ROT_SEQ_TRANFORMACAO,
                FPR_SEQ_REPETICAO = Etiqueta.FPR_SEQ_REPETICAO,
                ETI_QUANTIDADE_PALETE = Etiqueta.ETI_QUANTIDADE_PALETE,
                ETI_LOTE = Etiqueta.ETI_LOTE,
                ETI_SUB_LOTE = Etiqueta.ETI_SUB_LOTE,
                ETI_IMPRIMIR_DE = Etiqueta.ETI_IMPRIMIR_DE,
                ETI_IMPRIMIR_ATE = Etiqueta.ETI_IMPRIMIR_ATE,
                BOL_ID = Etiqueta.BOL_ID,
                COR_SEQUENCIA = Etiqueta.COR_SEQUENCIA,
                Changed = Etiqueta.Changed,
                UserId = _executionContext.UserId,
                ETI_ID = Etiqueta.ETI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_EMISSAO(int eti_id, DateTime value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_EMISSAO] = @ETI_EMISSAO WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_EMISSAO = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_CODIGO_BARRAS(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_CODIGO_BARRAS] = @ETI_CODIGO_BARRAS WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_CODIGO_BARRAS = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_SEQUENCIA(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_SEQUENCIA] = @ETI_SEQUENCIA WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_SEQUENCIA = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_NUMERO_COPIAS(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_NUMERO_COPIAS] = @ETI_NUMERO_COPIAS WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_NUMERO_COPIAS = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_STATUS(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_STATUS] = @ETI_STATUS WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_STATUS = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_DATA_FABRICACAO(int eti_id, DateTime value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_DATA_FABRICACAO] = @ETI_DATA_FABRICACAO WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_DATA_FABRICACAO = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_COD_BARRAS_ORIGINAL(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_COD_BARRAS_ORIGINAL] = @ETI_COD_BARRAS_ORIGINAL WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_COD_BARRAS_ORIGINAL = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_OP_ORIGINAL(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_OP_ORIGINAL] = @ETI_OP_ORIGINAL WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_OP_ORIGINAL = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateMAQ_ID(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [MAQ_ID] = @MAQ_ID WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                MAQ_ID = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateIMP_ID(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [IMP_ID] = @IMP_ID WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                IMP_ID = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUSE_ID(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [USE_ID] = @USE_ID WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                USE_ID = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ORD_ID] = @ORD_ID WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ORD_ID = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_PRO_ID(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ROT_PRO_ID] = @ROT_PRO_ID WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ROT_PRO_ID = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_SEQ_TRANFORMACAO(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ROT_SEQ_TRANFORMACAO] = @ROT_SEQ_TRANFORMACAO WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ROT_SEQ_TRANFORMACAO = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateFPR_SEQ_REPETICAO(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [FPR_SEQ_REPETICAO] = @FPR_SEQ_REPETICAO WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                FPR_SEQ_REPETICAO = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_QUANTIDADE_PALETE(int eti_id, Decimal value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_QUANTIDADE_PALETE] = @ETI_QUANTIDADE_PALETE WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_QUANTIDADE_PALETE = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_LOTE(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_LOTE] = @ETI_LOTE WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_LOTE = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_SUB_LOTE(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_SUB_LOTE] = @ETI_SUB_LOTE WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_SUB_LOTE = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_IMPRIMIR_DE(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_IMPRIMIR_DE] = @ETI_IMPRIMIR_DE WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_IMPRIMIR_DE = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateETI_IMPRIMIR_ATE(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [ETI_IMPRIMIR_ATE] = @ETI_IMPRIMIR_ATE WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_IMPRIMIR_ATE = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateBOL_ID(int eti_id, string value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [BOL_ID] = @BOL_ID WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                BOL_ID = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCOR_SEQUENCIA(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [COR_SEQUENCIA] = @COR_SEQUENCIA WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                COR_SEQUENCIA = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [TenantID] = @TenantID WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                TenantID = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int eti_id, bool value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [Deleted] = @Deleted WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                Deleted = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int eti_id, DateTime value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [Changed] = @Changed WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                Changed = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int eti_id, int value)
        {
            this.Query = $@" UPDATE [Etiqueta] SET [UserId] = @UserId WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                UserId = value,
                ETI_ID = eti_id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteEtiquetaQuery(IEtiquetaEntity Etiqueta)
        {
            this.Query = $@" DELETE FROM [Etiqueta] WHERE [ETI_ID] = @ETI_ID ";
            this.Parameters = new
            {
                ETI_ID = Etiqueta.ETI_ID,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration