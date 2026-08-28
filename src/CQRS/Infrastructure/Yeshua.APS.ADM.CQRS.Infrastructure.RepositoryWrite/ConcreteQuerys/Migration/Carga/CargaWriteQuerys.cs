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
    public class CargaQueryWrite : QueryBase, ICargaQueryWrite
    {
        protected readonly IExecutionContext _executionContext;
        public CargaQueryWrite(IExecutionContext executionContext)
        {
            _executionContext = executionContext;
        }
        public QueryModel InserirCargaQuery(ICargaEntity Carga)
        {
            this.Query = $@" INSERT INTO Carga (CAR_ID, CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO, CAR_STATUS, CAR_PESO_TEORICO, CAR_VOLUME_TEORICO, CAR_PESO_REAL, CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA, CAR_PESO_SAIDA, CAR_ID_DOCA, VEI_PLACA, TIP_ID, TRA_ID, CAR_GRUPO_PRODUTIVO, ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID, CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO, OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO, TURN_ID, TURM_ID, TenantID, Deleted, Changed, UserId) OUTPUT INSERTED.Id VALUES(@CAR_ID, @CAR_PREVISAO_MATERIA_PRIMA, @CAR_DATA_INICIO_PREVISTO, @CAR_DATA_INICIO_REALIZADO, @CAR_DATA_FIM_PREVISTO, @CAR_DATA_FIM_REALIZADO, @CAR_INICIO_JANELA_EMBARQUE, @CAR_FIM_JANELA_EMBARQUE, @CAR_EMBARQUE_ALVO, @CAR_STATUS, @CAR_PESO_TEORICO, @CAR_VOLUME_TEORICO, @CAR_PESO_REAL, @CAR_VOLUME_REAL, @CAR_PESO_EMBALAGEM, @CAR_PESO_ENTRADA, @CAR_PESO_SAIDA, @CAR_ID_DOCA, @VEI_PLACA, @TIP_ID, @TRA_ID, @CAR_GRUPO_PRODUTIVO, @ROT_ID, @CAR_OBSERVACAO_DE_TRANSPORTE, @CAR_JUSTIFICATIVA_DE_CARREGAMENTO, @OCO_ID, @CAR_ID_JUNTADA, @CAR_OBSERVACAO_OTIMIZADOR, @CAR_ID_INTEGRACAO_BALANCA, @CAR_PESAGEM_LIBERADA, @CAR_OBS_LIERACAO, @OCO_ID_LIERACAO, @CAR_DATA_ENTRADA_VEICULO, @CAR_DATA_SAIDA_VEICULO, @CAR_DATA_ROMANEIO_CONSOLIDADO, @CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, @CAR_DIFERENCA_PESAGEM, @CAR_DATA_AGENCIAMENTO, @TURN_ID, @TURM_ID, @TenantID, @Deleted, @Changed, @UserId) ";
            this.Parameters = new
            {
                CAR_ID = Carga.CAR_ID,
                CAR_PREVISAO_MATERIA_PRIMA = Carga.CAR_PREVISAO_MATERIA_PRIMA,
                CAR_DATA_INICIO_PREVISTO = Carga.CAR_DATA_INICIO_PREVISTO,
                CAR_DATA_INICIO_REALIZADO = Carga.CAR_DATA_INICIO_REALIZADO,
                CAR_DATA_FIM_PREVISTO = Carga.CAR_DATA_FIM_PREVISTO,
                CAR_DATA_FIM_REALIZADO = Carga.CAR_DATA_FIM_REALIZADO,
                CAR_INICIO_JANELA_EMBARQUE = Carga.CAR_INICIO_JANELA_EMBARQUE,
                CAR_FIM_JANELA_EMBARQUE = Carga.CAR_FIM_JANELA_EMBARQUE,
                CAR_EMBARQUE_ALVO = Carga.CAR_EMBARQUE_ALVO,
                CAR_STATUS = Carga.CAR_STATUS,
                CAR_PESO_TEORICO = Carga.CAR_PESO_TEORICO,
                CAR_VOLUME_TEORICO = Carga.CAR_VOLUME_TEORICO,
                CAR_PESO_REAL = Carga.CAR_PESO_REAL,
                CAR_VOLUME_REAL = Carga.CAR_VOLUME_REAL,
                CAR_PESO_EMBALAGEM = Carga.CAR_PESO_EMBALAGEM,
                CAR_PESO_ENTRADA = Carga.CAR_PESO_ENTRADA,
                CAR_PESO_SAIDA = Carga.CAR_PESO_SAIDA,
                CAR_ID_DOCA = Carga.CAR_ID_DOCA,
                VEI_PLACA = Carga.VEI_PLACA,
                TIP_ID = Carga.TIP_ID,
                TRA_ID = Carga.TRA_ID,
                CAR_GRUPO_PRODUTIVO = Carga.CAR_GRUPO_PRODUTIVO,
                ROT_ID = Carga.ROT_ID,
                CAR_OBSERVACAO_DE_TRANSPORTE = Carga.CAR_OBSERVACAO_DE_TRANSPORTE,
                CAR_JUSTIFICATIVA_DE_CARREGAMENTO = Carga.CAR_JUSTIFICATIVA_DE_CARREGAMENTO,
                OCO_ID = Carga.OCO_ID,
                CAR_ID_JUNTADA = Carga.CAR_ID_JUNTADA,
                CAR_OBSERVACAO_OTIMIZADOR = Carga.CAR_OBSERVACAO_OTIMIZADOR,
                CAR_ID_INTEGRACAO_BALANCA = Carga.CAR_ID_INTEGRACAO_BALANCA,
                CAR_PESAGEM_LIBERADA = Carga.CAR_PESAGEM_LIBERADA,
                CAR_OBS_LIERACAO = Carga.CAR_OBS_LIERACAO,
                OCO_ID_LIERACAO = Carga.OCO_ID_LIERACAO,
                CAR_DATA_ENTRADA_VEICULO = Carga.CAR_DATA_ENTRADA_VEICULO,
                CAR_DATA_SAIDA_VEICULO = Carga.CAR_DATA_SAIDA_VEICULO,
                CAR_DATA_ROMANEIO_CONSOLIDADO = Carga.CAR_DATA_ROMANEIO_CONSOLIDADO,
                CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO = Carga.CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO,
                CAR_DIFERENCA_PESAGEM = Carga.CAR_DIFERENCA_PESAGEM,
                CAR_DATA_AGENCIAMENTO = Carga.CAR_DATA_AGENCIAMENTO,
                TURN_ID = Carga.TURN_ID,
                TURM_ID = Carga.TURM_ID,
                TenantID = _executionContext.TenantID,
                Deleted = 0,
                Changed = DateTime.Now,
                UserId = _executionContext.UserId,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCargaQuery(ICargaEntity Carga)
        {
            this.Query = $@" UPDATE Carga SET CAR_ID = @CAR_ID, CAR_PREVISAO_MATERIA_PRIMA = @CAR_PREVISAO_MATERIA_PRIMA, CAR_DATA_INICIO_PREVISTO = @CAR_DATA_INICIO_PREVISTO, CAR_DATA_INICIO_REALIZADO = @CAR_DATA_INICIO_REALIZADO, CAR_DATA_FIM_PREVISTO = @CAR_DATA_FIM_PREVISTO, CAR_DATA_FIM_REALIZADO = @CAR_DATA_FIM_REALIZADO, CAR_INICIO_JANELA_EMBARQUE = @CAR_INICIO_JANELA_EMBARQUE, CAR_FIM_JANELA_EMBARQUE = @CAR_FIM_JANELA_EMBARQUE, CAR_EMBARQUE_ALVO = @CAR_EMBARQUE_ALVO, CAR_STATUS = @CAR_STATUS, CAR_PESO_TEORICO = @CAR_PESO_TEORICO, CAR_VOLUME_TEORICO = @CAR_VOLUME_TEORICO, CAR_PESO_REAL = @CAR_PESO_REAL, CAR_VOLUME_REAL = @CAR_VOLUME_REAL, CAR_PESO_EMBALAGEM = @CAR_PESO_EMBALAGEM, CAR_PESO_ENTRADA = @CAR_PESO_ENTRADA, CAR_PESO_SAIDA = @CAR_PESO_SAIDA, CAR_ID_DOCA = @CAR_ID_DOCA, VEI_PLACA = @VEI_PLACA, TIP_ID = @TIP_ID, TRA_ID = @TRA_ID, CAR_GRUPO_PRODUTIVO = @CAR_GRUPO_PRODUTIVO, ROT_ID = @ROT_ID, CAR_OBSERVACAO_DE_TRANSPORTE = @CAR_OBSERVACAO_DE_TRANSPORTE, CAR_JUSTIFICATIVA_DE_CARREGAMENTO = @CAR_JUSTIFICATIVA_DE_CARREGAMENTO, OCO_ID = @OCO_ID, CAR_ID_JUNTADA = @CAR_ID_JUNTADA, CAR_OBSERVACAO_OTIMIZADOR = @CAR_OBSERVACAO_OTIMIZADOR, CAR_ID_INTEGRACAO_BALANCA = @CAR_ID_INTEGRACAO_BALANCA, CAR_PESAGEM_LIBERADA = @CAR_PESAGEM_LIBERADA, CAR_OBS_LIERACAO = @CAR_OBS_LIERACAO, OCO_ID_LIERACAO = @OCO_ID_LIERACAO, CAR_DATA_ENTRADA_VEICULO = @CAR_DATA_ENTRADA_VEICULO, CAR_DATA_SAIDA_VEICULO = @CAR_DATA_SAIDA_VEICULO, CAR_DATA_ROMANEIO_CONSOLIDADO = @CAR_DATA_ROMANEIO_CONSOLIDADO, CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO = @CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO, CAR_DIFERENCA_PESAGEM = @CAR_DIFERENCA_PESAGEM, CAR_DATA_AGENCIAMENTO = @CAR_DATA_AGENCIAMENTO, TURN_ID = @TURN_ID, TURM_ID = @TURM_ID, Changed = @Changed, UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID = Carga.CAR_ID,
                CAR_PREVISAO_MATERIA_PRIMA = Carga.CAR_PREVISAO_MATERIA_PRIMA,
                CAR_DATA_INICIO_PREVISTO = Carga.CAR_DATA_INICIO_PREVISTO,
                CAR_DATA_INICIO_REALIZADO = Carga.CAR_DATA_INICIO_REALIZADO,
                CAR_DATA_FIM_PREVISTO = Carga.CAR_DATA_FIM_PREVISTO,
                CAR_DATA_FIM_REALIZADO = Carga.CAR_DATA_FIM_REALIZADO,
                CAR_INICIO_JANELA_EMBARQUE = Carga.CAR_INICIO_JANELA_EMBARQUE,
                CAR_FIM_JANELA_EMBARQUE = Carga.CAR_FIM_JANELA_EMBARQUE,
                CAR_EMBARQUE_ALVO = Carga.CAR_EMBARQUE_ALVO,
                CAR_STATUS = Carga.CAR_STATUS,
                CAR_PESO_TEORICO = Carga.CAR_PESO_TEORICO,
                CAR_VOLUME_TEORICO = Carga.CAR_VOLUME_TEORICO,
                CAR_PESO_REAL = Carga.CAR_PESO_REAL,
                CAR_VOLUME_REAL = Carga.CAR_VOLUME_REAL,
                CAR_PESO_EMBALAGEM = Carga.CAR_PESO_EMBALAGEM,
                CAR_PESO_ENTRADA = Carga.CAR_PESO_ENTRADA,
                CAR_PESO_SAIDA = Carga.CAR_PESO_SAIDA,
                CAR_ID_DOCA = Carga.CAR_ID_DOCA,
                VEI_PLACA = Carga.VEI_PLACA,
                TIP_ID = Carga.TIP_ID,
                TRA_ID = Carga.TRA_ID,
                CAR_GRUPO_PRODUTIVO = Carga.CAR_GRUPO_PRODUTIVO,
                ROT_ID = Carga.ROT_ID,
                CAR_OBSERVACAO_DE_TRANSPORTE = Carga.CAR_OBSERVACAO_DE_TRANSPORTE,
                CAR_JUSTIFICATIVA_DE_CARREGAMENTO = Carga.CAR_JUSTIFICATIVA_DE_CARREGAMENTO,
                OCO_ID = Carga.OCO_ID,
                CAR_ID_JUNTADA = Carga.CAR_ID_JUNTADA,
                CAR_OBSERVACAO_OTIMIZADOR = Carga.CAR_OBSERVACAO_OTIMIZADOR,
                CAR_ID_INTEGRACAO_BALANCA = Carga.CAR_ID_INTEGRACAO_BALANCA,
                CAR_PESAGEM_LIBERADA = Carga.CAR_PESAGEM_LIBERADA,
                CAR_OBS_LIERACAO = Carga.CAR_OBS_LIERACAO,
                OCO_ID_LIERACAO = Carga.OCO_ID_LIERACAO,
                CAR_DATA_ENTRADA_VEICULO = Carga.CAR_DATA_ENTRADA_VEICULO,
                CAR_DATA_SAIDA_VEICULO = Carga.CAR_DATA_SAIDA_VEICULO,
                CAR_DATA_ROMANEIO_CONSOLIDADO = Carga.CAR_DATA_ROMANEIO_CONSOLIDADO,
                CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO = Carga.CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO,
                CAR_DIFERENCA_PESAGEM = Carga.CAR_DIFERENCA_PESAGEM,
                CAR_DATA_AGENCIAMENTO = Carga.CAR_DATA_AGENCIAMENTO,
                TURN_ID = Carga.TURN_ID,
                TURM_ID = Carga.TURM_ID,
                Changed = Carga.Changed,
                UserId = _executionContext.UserId,
                Id = Carga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_ID = @CAR_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PREVISAO_MATERIA_PRIMA(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_PREVISAO_MATERIA_PRIMA = @CAR_PREVISAO_MATERIA_PRIMA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_PREVISAO_MATERIA_PRIMA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_INICIO_PREVISTO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DATA_INICIO_PREVISTO = @CAR_DATA_INICIO_PREVISTO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DATA_INICIO_PREVISTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_INICIO_REALIZADO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DATA_INICIO_REALIZADO = @CAR_DATA_INICIO_REALIZADO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DATA_INICIO_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_FIM_PREVISTO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DATA_FIM_PREVISTO = @CAR_DATA_FIM_PREVISTO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DATA_FIM_PREVISTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_FIM_REALIZADO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DATA_FIM_REALIZADO = @CAR_DATA_FIM_REALIZADO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DATA_FIM_REALIZADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_INICIO_JANELA_EMBARQUE(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_INICIO_JANELA_EMBARQUE = @CAR_INICIO_JANELA_EMBARQUE WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_INICIO_JANELA_EMBARQUE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_FIM_JANELA_EMBARQUE(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_FIM_JANELA_EMBARQUE = @CAR_FIM_JANELA_EMBARQUE WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_FIM_JANELA_EMBARQUE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_EMBARQUE_ALVO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_EMBARQUE_ALVO = @CAR_EMBARQUE_ALVO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_EMBARQUE_ALVO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_STATUS(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_STATUS = @CAR_STATUS WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_STATUS = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_TEORICO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_PESO_TEORICO = @CAR_PESO_TEORICO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_PESO_TEORICO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_VOLUME_TEORICO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_VOLUME_TEORICO = @CAR_VOLUME_TEORICO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_VOLUME_TEORICO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_REAL(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_PESO_REAL = @CAR_PESO_REAL WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_PESO_REAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_VOLUME_REAL(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_VOLUME_REAL = @CAR_VOLUME_REAL WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_VOLUME_REAL = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_EMBALAGEM(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_PESO_EMBALAGEM = @CAR_PESO_EMBALAGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_PESO_EMBALAGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_ENTRADA(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_PESO_ENTRADA = @CAR_PESO_ENTRADA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_PESO_ENTRADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESO_SAIDA(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_PESO_SAIDA = @CAR_PESO_SAIDA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_PESO_SAIDA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID_DOCA(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_ID_DOCA = @CAR_ID_DOCA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID_DOCA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateVEI_PLACA(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET VEI_PLACA = @VEI_PLACA WHERE Id = @Id ";
            this.Parameters = new
            {
                VEI_PLACA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTIP_ID(int id, int value)
        {
            this.Query = $@" UPDATE Carga SET TIP_ID = @TIP_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TIP_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTRA_ID(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET TRA_ID = @TRA_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TRA_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_GRUPO_PRODUTIVO(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_GRUPO_PRODUTIVO = @CAR_GRUPO_PRODUTIVO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_GRUPO_PRODUTIVO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateROT_ID(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET ROT_ID = @ROT_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                ROT_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_OBSERVACAO_DE_TRANSPORTE(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_OBSERVACAO_DE_TRANSPORTE = @CAR_OBSERVACAO_DE_TRANSPORTE WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_OBSERVACAO_DE_TRANSPORTE = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_JUSTIFICATIVA_DE_CARREGAMENTO(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_JUSTIFICATIVA_DE_CARREGAMENTO = @CAR_JUSTIFICATIVA_DE_CARREGAMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_JUSTIFICATIVA_DE_CARREGAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET OCO_ID = @OCO_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                OCO_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID_JUNTADA(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_ID_JUNTADA = @CAR_ID_JUNTADA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID_JUNTADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_OBSERVACAO_OTIMIZADOR(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_OBSERVACAO_OTIMIZADOR = @CAR_OBSERVACAO_OTIMIZADOR WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_OBSERVACAO_OTIMIZADOR = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_ID_INTEGRACAO_BALANCA(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_ID_INTEGRACAO_BALANCA = @CAR_ID_INTEGRACAO_BALANCA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_ID_INTEGRACAO_BALANCA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_PESAGEM_LIBERADA(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_PESAGEM_LIBERADA = @CAR_PESAGEM_LIBERADA WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_PESAGEM_LIBERADA = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_OBS_LIERACAO(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_OBS_LIERACAO = @CAR_OBS_LIERACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_OBS_LIERACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateOCO_ID_LIERACAO(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET OCO_ID_LIERACAO = @OCO_ID_LIERACAO WHERE Id = @Id ";
            this.Parameters = new
            {
                OCO_ID_LIERACAO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_ENTRADA_VEICULO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DATA_ENTRADA_VEICULO = @CAR_DATA_ENTRADA_VEICULO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DATA_ENTRADA_VEICULO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_SAIDA_VEICULO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DATA_SAIDA_VEICULO = @CAR_DATA_SAIDA_VEICULO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DATA_SAIDA_VEICULO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_ROMANEIO_CONSOLIDADO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DATA_ROMANEIO_CONSOLIDADO = @CAR_DATA_ROMANEIO_CONSOLIDADO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DATA_ROMANEIO_CONSOLIDADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DIA_TURMA_ROMANEIO_CONSOLIDADO(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO = @CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DIA_TURMA_ROMANEIO_CONSOLIDADO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DIFERENCA_PESAGEM(int id, Decimal value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DIFERENCA_PESAGEM = @CAR_DIFERENCA_PESAGEM WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DIFERENCA_PESAGEM = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateCAR_DATA_AGENCIAMENTO(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET CAR_DATA_AGENCIAMENTO = @CAR_DATA_AGENCIAMENTO WHERE Id = @Id ";
            this.Parameters = new
            {
                CAR_DATA_AGENCIAMENTO = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURN_ID(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET TURN_ID = @TURN_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TURN_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTURM_ID(int id, string value)
        {
            this.Query = $@" UPDATE Carga SET TURM_ID = @TURM_ID WHERE Id = @Id ";
            this.Parameters = new
            {
                TURM_ID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateTenantID(int id, int value)
        {
            this.Query = $@" UPDATE Carga SET TenantID = @TenantID WHERE Id = @Id ";
            this.Parameters = new
            {
                TenantID = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateDeleted(int id, bool value)
        {
            this.Query = $@" UPDATE Carga SET Deleted = @Deleted WHERE Id = @Id ";
            this.Parameters = new
            {
                Deleted = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateChanged(int id, DateTime value)
        {
            this.Query = $@" UPDATE Carga SET Changed = @Changed WHERE Id = @Id ";
            this.Parameters = new
            {
                Changed = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel UpdateUserId(int id, int value)
        {
            this.Query = $@" UPDATE Carga SET UserId = @UserId WHERE Id = @Id ";
            this.Parameters = new
            {
                UserId = value,
                Id = id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
        public QueryModel DeleteCargaQuery(ICargaEntity Carga)
        {
            this.Query = $@" DELETE FROM Carga WHERE Id = @Id ";
            this.Parameters = new
            {
                Id = Carga.Id,
            };
            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
//Dominio.Schemas.CQRS.SourceCodeInfraestructureQueryWriteMigration