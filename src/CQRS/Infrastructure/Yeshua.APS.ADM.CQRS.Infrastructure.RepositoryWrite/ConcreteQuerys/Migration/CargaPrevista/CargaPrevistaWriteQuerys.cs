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
    public class CargaPrevistaQueryWrite : QueryBase, ICargaPrevistaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CargaPrevistaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCargaPrevistaQuery(ICargaPrevistaEntity CargaPrevista)
        {
            this.Query = $@" INSERT INTO [CargaPrevista] ([CAR_ID], [ORD_ID], [ITC_QTD_PLANEJADA], [CAR_PREVISAO_MATERIA_PRIMA], [CAR_DATA_INICIO_PREVISTO], [CAR_DATA_INICIO_REALIZADO], [CAR_DATA_FIM_PREVISTO], [CAR_DATA_FIM_REALIZADO], [CAR_INICIO_JANELA_EMBARQUE], [CAR_FIM_JANELA_EMBARQUE], [CAR_EMBARQUE_ALVO], [CAR_STATUS], [CAR_PESO_TEORICO], [CAR_VOLUME_TEORICO], [CAR_PESO_REAL], [CAR_VOLUME_REAL], [CAR_PESO_EMBALAGEM], [CAR_PESO_ENTRADA], [CAR_PESO_SAIDA], [CAR_ID_DOCA], [VEI_PLACA], [TIP_ID], [TRA_ID], [CAR_GRUPO_PRODUTIVO], [ROT_ID], [CAR_OBSERVACAO_DE_TRANSPORTE], [CAR_JUSTIFICATIVA_DE_CARREGAMENTO], [OCO_ID], [CAR_ID_JUNTADA], [CAR_OBSERVACAO_OTIMIZADOR], [TenantID], [Deleted], [Changed], [UserId]) OUTPUT INSERTED.[Id] VALUES(@CAR_ID, @ORD_ID, @ITC_QTD_PLANEJADA, @CAR_PREVISAO_MATERIA_PRIMA, @CAR_DATA_INICIO_PREVISTO, @CAR_DATA_INICIO_REALIZADO, @CAR_DATA_FIM_PREVISTO, @CAR_DATA_FIM_REALIZADO, @CAR_INICIO_JANELA_EMBARQUE, @CAR_FIM_JANELA_EMBARQUE, @CAR_EMBARQUE_ALVO, @CAR_STATUS, @CAR_PESO_TEORICO, @CAR_VOLUME_TEORICO, @CAR_PESO_REAL, @CAR_VOLUME_REAL, @CAR_PESO_EMBALAGEM, @CAR_PESO_ENTRADA, @CAR_PESO_SAIDA, @CAR_ID_DOCA, @VEI_PLACA, @TIP_ID, @TRA_ID, @CAR_GRUPO_PRODUTIVO, @ROT_ID, @CAR_OBSERVACAO_DE_TRANSPORTE, @CAR_JUSTIFICATIVA_DE_CARREGAMENTO, @OCO_ID, @CAR_ID_JUNTADA, @CAR_OBSERVACAO_OTIMIZADOR, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CAR_ID = CargaPrevista.CAR_ID,
                ORD_ID = CargaPrevista.ORD_ID,
                ITC_QTD_PLANEJADA = CargaPrevista.ITC_QTD_PLANEJADA,
                CAR_PREVISAO_MATERIA_PRIMA = CargaPrevista.CAR_PREVISAO_MATERIA_PRIMA,
                CAR_DATA_INICIO_PREVISTO = CargaPrevista.CAR_DATA_INICIO_PREVISTO,
                CAR_DATA_INICIO_REALIZADO = CargaPrevista.CAR_DATA_INICIO_REALIZADO,
                CAR_DATA_FIM_PREVISTO = CargaPrevista.CAR_DATA_FIM_PREVISTO,
                CAR_DATA_FIM_REALIZADO = CargaPrevista.CAR_DATA_FIM_REALIZADO,
                CAR_INICIO_JANELA_EMBARQUE = CargaPrevista.CAR_INICIO_JANELA_EMBARQUE,
                CAR_FIM_JANELA_EMBARQUE = CargaPrevista.CAR_FIM_JANELA_EMBARQUE,
                CAR_EMBARQUE_ALVO = CargaPrevista.CAR_EMBARQUE_ALVO,
                CAR_STATUS = CargaPrevista.CAR_STATUS,
                CAR_PESO_TEORICO = CargaPrevista.CAR_PESO_TEORICO,
                CAR_VOLUME_TEORICO = CargaPrevista.CAR_VOLUME_TEORICO,
                CAR_PESO_REAL = CargaPrevista.CAR_PESO_REAL,
                CAR_VOLUME_REAL = CargaPrevista.CAR_VOLUME_REAL,
                CAR_PESO_EMBALAGEM = CargaPrevista.CAR_PESO_EMBALAGEM,
                CAR_PESO_ENTRADA = CargaPrevista.CAR_PESO_ENTRADA,
                CAR_PESO_SAIDA = CargaPrevista.CAR_PESO_SAIDA,
                CAR_ID_DOCA = CargaPrevista.CAR_ID_DOCA,
                VEI_PLACA = CargaPrevista.VEI_PLACA,
                TIP_ID = CargaPrevista.TIP_ID,
                TRA_ID = CargaPrevista.TRA_ID,
                CAR_GRUPO_PRODUTIVO = CargaPrevista.CAR_GRUPO_PRODUTIVO,
                ROT_ID = CargaPrevista.ROT_ID,
                CAR_OBSERVACAO_DE_TRANSPORTE = CargaPrevista.CAR_OBSERVACAO_DE_TRANSPORTE,
                CAR_JUSTIFICATIVA_DE_CARREGAMENTO = CargaPrevista.CAR_JUSTIFICATIVA_DE_CARREGAMENTO,
                OCO_ID = CargaPrevista.OCO_ID,
                CAR_ID_JUNTADA = CargaPrevista.CAR_ID_JUNTADA,
                CAR_OBSERVACAO_OTIMIZADOR = CargaPrevista.CAR_OBSERVACAO_OTIMIZADOR,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaPrevistaQuery(ICargaPrevistaEntity CargaPrevista)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_ID] = @CAR_ID, [ORD_ID] = @ORD_ID, [ITC_QTD_PLANEJADA] = @ITC_QTD_PLANEJADA, [CAR_PREVISAO_MATERIA_PRIMA] = @CAR_PREVISAO_MATERIA_PRIMA, [CAR_DATA_INICIO_PREVISTO] = @CAR_DATA_INICIO_PREVISTO, [CAR_DATA_INICIO_REALIZADO] = @CAR_DATA_INICIO_REALIZADO, [CAR_DATA_FIM_PREVISTO] = @CAR_DATA_FIM_PREVISTO, [CAR_DATA_FIM_REALIZADO] = @CAR_DATA_FIM_REALIZADO, [CAR_INICIO_JANELA_EMBARQUE] = @CAR_INICIO_JANELA_EMBARQUE, [CAR_FIM_JANELA_EMBARQUE] = @CAR_FIM_JANELA_EMBARQUE, [CAR_EMBARQUE_ALVO] = @CAR_EMBARQUE_ALVO, [CAR_STATUS] = @CAR_STATUS, [CAR_PESO_TEORICO] = @CAR_PESO_TEORICO, [CAR_VOLUME_TEORICO] = @CAR_VOLUME_TEORICO, [CAR_PESO_REAL] = @CAR_PESO_REAL, [CAR_VOLUME_REAL] = @CAR_VOLUME_REAL, [CAR_PESO_EMBALAGEM] = @CAR_PESO_EMBALAGEM, [CAR_PESO_ENTRADA] = @CAR_PESO_ENTRADA, [CAR_PESO_SAIDA] = @CAR_PESO_SAIDA, [CAR_ID_DOCA] = @CAR_ID_DOCA, [VEI_PLACA] = @VEI_PLACA, [TIP_ID] = @TIP_ID, [TRA_ID] = @TRA_ID, [CAR_GRUPO_PRODUTIVO] = @CAR_GRUPO_PRODUTIVO, [ROT_ID] = @ROT_ID, [CAR_OBSERVACAO_DE_TRANSPORTE] = @CAR_OBSERVACAO_DE_TRANSPORTE, [CAR_JUSTIFICATIVA_DE_CARREGAMENTO] = @CAR_JUSTIFICATIVA_DE_CARREGAMENTO, [OCO_ID] = @OCO_ID, [CAR_ID_JUNTADA] = @CAR_ID_JUNTADA, [CAR_OBSERVACAO_OTIMIZADOR] = @CAR_OBSERVACAO_OTIMIZADOR, [Changed] = @Changed, [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_ID = CargaPrevista.CAR_ID,
                ORD_ID = CargaPrevista.ORD_ID,
                ITC_QTD_PLANEJADA = CargaPrevista.ITC_QTD_PLANEJADA,
                CAR_PREVISAO_MATERIA_PRIMA = CargaPrevista.CAR_PREVISAO_MATERIA_PRIMA,
                CAR_DATA_INICIO_PREVISTO = CargaPrevista.CAR_DATA_INICIO_PREVISTO,
                CAR_DATA_INICIO_REALIZADO = CargaPrevista.CAR_DATA_INICIO_REALIZADO,
                CAR_DATA_FIM_PREVISTO = CargaPrevista.CAR_DATA_FIM_PREVISTO,
                CAR_DATA_FIM_REALIZADO = CargaPrevista.CAR_DATA_FIM_REALIZADO,
                CAR_INICIO_JANELA_EMBARQUE = CargaPrevista.CAR_INICIO_JANELA_EMBARQUE,
                CAR_FIM_JANELA_EMBARQUE = CargaPrevista.CAR_FIM_JANELA_EMBARQUE,
                CAR_EMBARQUE_ALVO = CargaPrevista.CAR_EMBARQUE_ALVO,
                CAR_STATUS = CargaPrevista.CAR_STATUS,
                CAR_PESO_TEORICO = CargaPrevista.CAR_PESO_TEORICO,
                CAR_VOLUME_TEORICO = CargaPrevista.CAR_VOLUME_TEORICO,
                CAR_PESO_REAL = CargaPrevista.CAR_PESO_REAL,
                CAR_VOLUME_REAL = CargaPrevista.CAR_VOLUME_REAL,
                CAR_PESO_EMBALAGEM = CargaPrevista.CAR_PESO_EMBALAGEM,
                CAR_PESO_ENTRADA = CargaPrevista.CAR_PESO_ENTRADA,
                CAR_PESO_SAIDA = CargaPrevista.CAR_PESO_SAIDA,
                CAR_ID_DOCA = CargaPrevista.CAR_ID_DOCA,
                VEI_PLACA = CargaPrevista.VEI_PLACA,
                TIP_ID = CargaPrevista.TIP_ID,
                TRA_ID = CargaPrevista.TRA_ID,
                CAR_GRUPO_PRODUTIVO = CargaPrevista.CAR_GRUPO_PRODUTIVO,
                ROT_ID = CargaPrevista.ROT_ID,
                CAR_OBSERVACAO_DE_TRANSPORTE = CargaPrevista.CAR_OBSERVACAO_DE_TRANSPORTE,
                CAR_JUSTIFICATIVA_DE_CARREGAMENTO = CargaPrevista.CAR_JUSTIFICATIVA_DE_CARREGAMENTO,
                OCO_ID = CargaPrevista.OCO_ID,
                CAR_ID_JUNTADA = CargaPrevista.CAR_ID_JUNTADA,
                CAR_OBSERVACAO_OTIMIZADOR = CargaPrevista.CAR_OBSERVACAO_OTIMIZADOR,
                Changed = CargaPrevista.Changed,
                UserId = _executionContext.UserId,
                Id = CargaPrevista.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_ID] = @CAR_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateORD_ID(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [ORD_ID] = @ORD_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ORD_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateITC_QTD_PLANEJADA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [ITC_QTD_PLANEJADA] = @ITC_QTD_PLANEJADA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ITC_QTD_PLANEJADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PREVISAO_MATERIA_PRIMA(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_PREVISAO_MATERIA_PRIMA] = @CAR_PREVISAO_MATERIA_PRIMA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_PREVISAO_MATERIA_PRIMA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_INICIO_PREVISTO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_DATA_INICIO_PREVISTO] = @CAR_DATA_INICIO_PREVISTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_DATA_INICIO_PREVISTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_INICIO_REALIZADO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_DATA_INICIO_REALIZADO] = @CAR_DATA_INICIO_REALIZADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_DATA_INICIO_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_FIM_PREVISTO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_DATA_FIM_PREVISTO] = @CAR_DATA_FIM_PREVISTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_DATA_FIM_PREVISTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_FIM_REALIZADO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_DATA_FIM_REALIZADO] = @CAR_DATA_FIM_REALIZADO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_DATA_FIM_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_INICIO_JANELA_EMBARQUE(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_INICIO_JANELA_EMBARQUE] = @CAR_INICIO_JANELA_EMBARQUE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_INICIO_JANELA_EMBARQUE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_FIM_JANELA_EMBARQUE(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_FIM_JANELA_EMBARQUE] = @CAR_FIM_JANELA_EMBARQUE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_FIM_JANELA_EMBARQUE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_EMBARQUE_ALVO(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_EMBARQUE_ALVO] = @CAR_EMBARQUE_ALVO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_EMBARQUE_ALVO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_STATUS(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_STATUS] = @CAR_STATUS WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_TEORICO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_PESO_TEORICO] = @CAR_PESO_TEORICO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_PESO_TEORICO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_VOLUME_TEORICO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_VOLUME_TEORICO] = @CAR_VOLUME_TEORICO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_VOLUME_TEORICO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_REAL(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_PESO_REAL] = @CAR_PESO_REAL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_PESO_REAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_VOLUME_REAL(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_VOLUME_REAL] = @CAR_VOLUME_REAL WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_VOLUME_REAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_EMBALAGEM(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_PESO_EMBALAGEM] = @CAR_PESO_EMBALAGEM WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_PESO_EMBALAGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_ENTRADA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_PESO_ENTRADA] = @CAR_PESO_ENTRADA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_PESO_ENTRADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_SAIDA(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_PESO_SAIDA] = @CAR_PESO_SAIDA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_PESO_SAIDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID_DOCA(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_ID_DOCA] = @CAR_ID_DOCA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_ID_DOCA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_PLACA(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [VEI_PLACA] = @VEI_PLACA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                VEI_PLACA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_ID(int id, int value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [TIP_ID] = @TIP_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TIP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_ID(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [TRA_ID] = @TRA_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TRA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_GRUPO_PRODUTIVO(int id, Decimal value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_GRUPO_PRODUTIVO] = @CAR_GRUPO_PRODUTIVO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_GRUPO_PRODUTIVO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_ID(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [ROT_ID] = @ROT_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                ROT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_OBSERVACAO_DE_TRANSPORTE(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_OBSERVACAO_DE_TRANSPORTE] = @CAR_OBSERVACAO_DE_TRANSPORTE WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_OBSERVACAO_DE_TRANSPORTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_JUSTIFICATIVA_DE_CARREGAMENTO(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_JUSTIFICATIVA_DE_CARREGAMENTO] = @CAR_JUSTIFICATIVA_DE_CARREGAMENTO WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_JUSTIFICATIVA_DE_CARREGAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [OCO_ID] = @OCO_ID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                OCO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID_JUNTADA(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_ID_JUNTADA] = @CAR_ID_JUNTADA WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_ID_JUNTADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_OBSERVACAO_OTIMIZADOR(int id, string value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [CAR_OBSERVACAO_OTIMIZADOR] = @CAR_OBSERVACAO_OTIMIZADOR WHERE [Id] = @Id ";
            this.Parameters = new
            {
                CAR_OBSERVACAO_OTIMIZADOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [TenantID] = @TenantID WHERE [Id] = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [Deleted] = @Deleted WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [Changed] = @Changed WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE [CargaPrevista] SET [UserId] = @UserId WHERE [Id] = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCargaPrevistaQuery(ICargaPrevistaEntity CargaPrevista)
        {
            this.Query = $@" DELETE FROM [CargaPrevista] WHERE [Id] = @Id ";
            this.Parameters = new
            {
                Id = CargaPrevista.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration