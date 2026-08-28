// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public static class CargaPrevistaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CAR_ID = 1UL << 1;
            public const ulong ORD_ID = 1UL << 2;
            public const ulong ITC_QTD_PLANEJADA = 1UL << 3;
            public const ulong CAR_PREVISAO_MATERIA_PRIMA = 1UL << 4;
            public const ulong CAR_DATA_INICIO_PREVISTO = 1UL << 5;
            public const ulong CAR_DATA_INICIO_REALIZADO = 1UL << 6;
            public const ulong CAR_DATA_FIM_PREVISTO = 1UL << 7;
            public const ulong CAR_DATA_FIM_REALIZADO = 1UL << 8;
            public const ulong CAR_INICIO_JANELA_EMBARQUE = 1UL << 9;
            public const ulong CAR_FIM_JANELA_EMBARQUE = 1UL << 10;
            public const ulong CAR_EMBARQUE_ALVO = 1UL << 11;
            public const ulong CAR_STATUS = 1UL << 12;
            public const ulong CAR_PESO_TEORICO = 1UL << 13;
            public const ulong CAR_VOLUME_TEORICO = 1UL << 14;
            public const ulong CAR_PESO_REAL = 1UL << 15;
            public const ulong CAR_VOLUME_REAL = 1UL << 16;
            public const ulong CAR_PESO_EMBALAGEM = 1UL << 17;
            public const ulong CAR_PESO_ENTRADA = 1UL << 18;
            public const ulong CAR_PESO_SAIDA = 1UL << 19;
            public const ulong CAR_ID_DOCA = 1UL << 20;
            public const ulong VEI_PLACA = 1UL << 21;
            public const ulong TIP_ID = 1UL << 22;
            public const ulong TRA_ID = 1UL << 23;
            public const ulong CAR_GRUPO_PRODUTIVO = 1UL << 24;
            public const ulong ROT_ID = 1UL << 25;
            public const ulong CAR_OBSERVACAO_DE_TRANSPORTE = 1UL << 26;
            public const ulong CAR_JUSTIFICATIVA_DE_CARREGAMENTO = 1UL << 27;
            public const ulong OCO_ID = 1UL << 28;
            public const ulong CAR_ID_JUNTADA = 1UL << 29;
            public const ulong CAR_OBSERVACAO_OTIMIZADOR = 1UL << 30;
            public const ulong TenantID = 1UL << 31;
            public const ulong Deleted = 1UL << 32;
            public const ulong Changed = 1UL << 33;
            public const ulong UserId = 1UL << 34;
        }

        public partial class CargaPrevistaDecorator : ICargaPrevistaEntity
{

                        private readonly ICargaPrevistaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CargaPrevistaDecorator(ICargaPrevistaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CargaPrevistaDecorator(
                            ICargaPrevistaEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_ID
                                    {
                                        get => _inner.CAR_ID;
                                        set
                                        {
                                            if (_inner.CAR_ID != value)
                                            {
                                                _inner.CAR_ID = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ID
                                    {
                                        get => _inner.ORD_ID;
                                        set
                                        {
                                            if (_inner.ORD_ID != value)
                                            {
                                                _inner.ORD_ID = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal ITC_QTD_PLANEJADA
                                    {
                                        get => _inner.ITC_QTD_PLANEJADA;
                                        set
                                        {
                                            if (_inner.ITC_QTD_PLANEJADA != value)
                                            {
                                                _inner.ITC_QTD_PLANEJADA = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.ITC_QTD_PLANEJADA) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "ITC_QTD_PLANEJADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAR_PREVISAO_MATERIA_PRIMA
                                    {
                                        get => _inner.CAR_PREVISAO_MATERIA_PRIMA;
                                        set
                                        {
                                            if (_inner.CAR_PREVISAO_MATERIA_PRIMA != value)
                                            {
                                                _inner.CAR_PREVISAO_MATERIA_PRIMA = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_PREVISAO_MATERIA_PRIMA) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_PREVISAO_MATERIA_PRIMA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAR_DATA_INICIO_PREVISTO
                                    {
                                        get => _inner.CAR_DATA_INICIO_PREVISTO;
                                        set
                                        {
                                            if (_inner.CAR_DATA_INICIO_PREVISTO != value)
                                            {
                                                _inner.CAR_DATA_INICIO_PREVISTO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_DATA_INICIO_PREVISTO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_DATA_INICIO_PREVISTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAR_DATA_INICIO_REALIZADO
                                    {
                                        get => _inner.CAR_DATA_INICIO_REALIZADO;
                                        set
                                        {
                                            if (_inner.CAR_DATA_INICIO_REALIZADO != value)
                                            {
                                                _inner.CAR_DATA_INICIO_REALIZADO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_DATA_INICIO_REALIZADO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_DATA_INICIO_REALIZADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAR_DATA_FIM_PREVISTO
                                    {
                                        get => _inner.CAR_DATA_FIM_PREVISTO;
                                        set
                                        {
                                            if (_inner.CAR_DATA_FIM_PREVISTO != value)
                                            {
                                                _inner.CAR_DATA_FIM_PREVISTO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_DATA_FIM_PREVISTO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_DATA_FIM_PREVISTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAR_DATA_FIM_REALIZADO
                                    {
                                        get => _inner.CAR_DATA_FIM_REALIZADO;
                                        set
                                        {
                                            if (_inner.CAR_DATA_FIM_REALIZADO != value)
                                            {
                                                _inner.CAR_DATA_FIM_REALIZADO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_DATA_FIM_REALIZADO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_DATA_FIM_REALIZADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAR_INICIO_JANELA_EMBARQUE
                                    {
                                        get => _inner.CAR_INICIO_JANELA_EMBARQUE;
                                        set
                                        {
                                            if (_inner.CAR_INICIO_JANELA_EMBARQUE != value)
                                            {
                                                _inner.CAR_INICIO_JANELA_EMBARQUE = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_INICIO_JANELA_EMBARQUE) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_INICIO_JANELA_EMBARQUE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAR_FIM_JANELA_EMBARQUE
                                    {
                                        get => _inner.CAR_FIM_JANELA_EMBARQUE;
                                        set
                                        {
                                            if (_inner.CAR_FIM_JANELA_EMBARQUE != value)
                                            {
                                                _inner.CAR_FIM_JANELA_EMBARQUE = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_FIM_JANELA_EMBARQUE) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_FIM_JANELA_EMBARQUE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CAR_EMBARQUE_ALVO
                                    {
                                        get => _inner.CAR_EMBARQUE_ALVO;
                                        set
                                        {
                                            if (_inner.CAR_EMBARQUE_ALVO != value)
                                            {
                                                _inner.CAR_EMBARQUE_ALVO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_EMBARQUE_ALVO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_EMBARQUE_ALVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_STATUS
                                    {
                                        get => _inner.CAR_STATUS;
                                        set
                                        {
                                            if (_inner.CAR_STATUS != value)
                                            {
                                                _inner.CAR_STATUS = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_PESO_TEORICO
                                    {
                                        get => _inner.CAR_PESO_TEORICO;
                                        set
                                        {
                                            if (_inner.CAR_PESO_TEORICO != value)
                                            {
                                                _inner.CAR_PESO_TEORICO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_PESO_TEORICO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_PESO_TEORICO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_VOLUME_TEORICO
                                    {
                                        get => _inner.CAR_VOLUME_TEORICO;
                                        set
                                        {
                                            if (_inner.CAR_VOLUME_TEORICO != value)
                                            {
                                                _inner.CAR_VOLUME_TEORICO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_VOLUME_TEORICO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_VOLUME_TEORICO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_PESO_REAL
                                    {
                                        get => _inner.CAR_PESO_REAL;
                                        set
                                        {
                                            if (_inner.CAR_PESO_REAL != value)
                                            {
                                                _inner.CAR_PESO_REAL = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_PESO_REAL) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_PESO_REAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_VOLUME_REAL
                                    {
                                        get => _inner.CAR_VOLUME_REAL;
                                        set
                                        {
                                            if (_inner.CAR_VOLUME_REAL != value)
                                            {
                                                _inner.CAR_VOLUME_REAL = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_VOLUME_REAL) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_VOLUME_REAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_PESO_EMBALAGEM
                                    {
                                        get => _inner.CAR_PESO_EMBALAGEM;
                                        set
                                        {
                                            if (_inner.CAR_PESO_EMBALAGEM != value)
                                            {
                                                _inner.CAR_PESO_EMBALAGEM = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_PESO_EMBALAGEM) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_PESO_EMBALAGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_PESO_ENTRADA
                                    {
                                        get => _inner.CAR_PESO_ENTRADA;
                                        set
                                        {
                                            if (_inner.CAR_PESO_ENTRADA != value)
                                            {
                                                _inner.CAR_PESO_ENTRADA = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_PESO_ENTRADA) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_PESO_ENTRADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_PESO_SAIDA
                                    {
                                        get => _inner.CAR_PESO_SAIDA;
                                        set
                                        {
                                            if (_inner.CAR_PESO_SAIDA != value)
                                            {
                                                _inner.CAR_PESO_SAIDA = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_PESO_SAIDA) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_PESO_SAIDA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_ID_DOCA
                                    {
                                        get => _inner.CAR_ID_DOCA;
                                        set
                                        {
                                            if (_inner.CAR_ID_DOCA != value)
                                            {
                                                _inner.CAR_ID_DOCA = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_ID_DOCA) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_ID_DOCA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VEI_PLACA
                                    {
                                        get => _inner.VEI_PLACA;
                                        set
                                        {
                                            if (_inner.VEI_PLACA != value)
                                            {
                                                _inner.VEI_PLACA = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.VEI_PLACA) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "VEI_PLACA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TIP_ID
                                    {
                                        get => _inner.TIP_ID;
                                        set
                                        {
                                            if (_inner.TIP_ID != value)
                                            {
                                                _inner.TIP_ID = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.TIP_ID) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "TIP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TRA_ID
                                    {
                                        get => _inner.TRA_ID;
                                        set
                                        {
                                            if (_inner.TRA_ID != value)
                                            {
                                                _inner.TRA_ID = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.TRA_ID) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "TRA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CAR_GRUPO_PRODUTIVO
                                    {
                                        get => _inner.CAR_GRUPO_PRODUTIVO;
                                        set
                                        {
                                            if (_inner.CAR_GRUPO_PRODUTIVO != value)
                                            {
                                                _inner.CAR_GRUPO_PRODUTIVO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_GRUPO_PRODUTIVO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_GRUPO_PRODUTIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_ID
                                    {
                                        get => _inner.ROT_ID;
                                        set
                                        {
                                            if (_inner.ROT_ID != value)
                                            {
                                                _inner.ROT_ID = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.ROT_ID) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "ROT_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_OBSERVACAO_DE_TRANSPORTE
                                    {
                                        get => _inner.CAR_OBSERVACAO_DE_TRANSPORTE;
                                        set
                                        {
                                            if (_inner.CAR_OBSERVACAO_DE_TRANSPORTE != value)
                                            {
                                                _inner.CAR_OBSERVACAO_DE_TRANSPORTE = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_OBSERVACAO_DE_TRANSPORTE) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_OBSERVACAO_DE_TRANSPORTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_JUSTIFICATIVA_DE_CARREGAMENTO
                                    {
                                        get => _inner.CAR_JUSTIFICATIVA_DE_CARREGAMENTO;
                                        set
                                        {
                                            if (_inner.CAR_JUSTIFICATIVA_DE_CARREGAMENTO != value)
                                            {
                                                _inner.CAR_JUSTIFICATIVA_DE_CARREGAMENTO = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_JUSTIFICATIVA_DE_CARREGAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_JUSTIFICATIVA_DE_CARREGAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OCO_ID
                                    {
                                        get => _inner.OCO_ID;
                                        set
                                        {
                                            if (_inner.OCO_ID != value)
                                            {
                                                _inner.OCO_ID = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.OCO_ID) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "OCO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_ID_JUNTADA
                                    {
                                        get => _inner.CAR_ID_JUNTADA;
                                        set
                                        {
                                            if (_inner.CAR_ID_JUNTADA != value)
                                            {
                                                _inner.CAR_ID_JUNTADA = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_ID_JUNTADA) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_ID_JUNTADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_OBSERVACAO_OTIMIZADOR
                                    {
                                        get => _inner.CAR_OBSERVACAO_OTIMIZADOR;
                                        set
                                        {
                                            if (_inner.CAR_OBSERVACAO_OTIMIZADOR != value)
                                            {
                                                _inner.CAR_OBSERVACAO_OTIMIZADOR = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.CAR_OBSERVACAO_OTIMIZADOR) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "CAR_OBSERVACAO_OTIMIZADOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public bool? Deleted
                                    {
                                        get => _inner.Deleted;
                                        set
                                        {
                                            if (_inner.Deleted != value)
                                            {
                                                _inner.Deleted = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? Changed
                                    {
                                        get => _inner.Changed;
                                        set
                                        {
                                            if (_inner.Changed != value)
                                            {
                                                _inner.Changed = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? UserId
                                    {
                                        get => _inner.UserId;
                                        set
                                        {
                                            if (_inner.UserId != value)
                                            {
                                                _inner.UserId = value;
                                                if ((_trackingMask & CargaPrevistaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CargaPrevista", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration