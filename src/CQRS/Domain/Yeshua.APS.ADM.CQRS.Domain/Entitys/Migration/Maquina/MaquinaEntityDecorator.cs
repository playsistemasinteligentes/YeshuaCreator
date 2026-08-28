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
                    public static class MaquinaTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Descricao = 1UL << 1;
            public const ulong Status = 1UL << 2;
            public const ulong TenantID = 1UL << 3;
            public const ulong Deleted = 1UL << 4;
            public const ulong Changed = 1UL << 5;
            public const ulong UserId = 1UL << 6;
            public const ulong CAL_ID = 1UL << 7;
            public const ulong MAQ_CONTROL_IP = 1UL << 8;
            public const ulong GMA_ID = 1UL << 9;
            public const ulong MAQ_ULTIMA_ATUALIZACAO = 1UL << 10;
            public const ulong MAQ_SIRENE_SEMAFORO = 1UL << 11;
            public const ulong MAQ_COR_SEMAFORO = 1UL << 12;
            public const ulong MAQ_ID_MAQ_PAI = 1UL << 13;
            public const ulong MAQ_TIPO_CONTADOR = 1UL << 14;
            public const ulong MAQ_TIPO_PLANEJAMENTO = 1UL << 15;
            public const ulong MAQ_AVALIA_CUSTO = 1UL << 16;
            public const ulong FPR_ID_OP_PRODUZINDO = 1UL << 17;
            public const ulong MAQ_CONGELA_FILA = 1UL << 18;
            public const ulong MAQ_TEMPO_MIN_PARADA = 1UL << 19;
            public const ulong MAQ_QTD_CORES = 1UL << 20;
            public const ulong MAQ_ID_INTEGRACAO = 1UL << 21;
            public const ulong MAQ_ID_INTEGRACAO_ERP = 1UL << 22;
            public const ulong MAQ_HIERARQUIA_SEQ_TRANSFORMACAO = 1UL << 23;
            public const ulong EQU_ID = 1UL << 24;
            public const ulong MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR = 1UL << 25;
            public const ulong MAQ_ACOMPANHA_LOTE_PILOTO = 1UL << 26;
            public const ulong MAQ_ID_SENSOR = 1UL << 27;
            public const ulong MAQ_DEBOUNCING_LOW = 1UL << 28;
            public const ulong MAQ_DEBOUNCING_HIGHT = 1UL << 29;
            public const ulong MAQ_TIPO_SINAL = 1UL << 30;
            public const ulong TEM_ID = 1UL << 31;
            public const ulong MAQ_COMPRIMENTO_CHAPA_DE = 1UL << 32;
            public const ulong MAQ_COMPRIMENTO_CHAPA_ATE = 1UL << 33;
            public const ulong MAQ_LARGURA_CHAPA_DE = 1UL << 34;
            public const ulong MAQ_LARGURA_CHAPA_ATE = 1UL << 35;
            public const ulong MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR = 1UL << 36;
            public const ulong MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR = 1UL << 37;
            public const ulong MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR = 1UL << 38;
            public const ulong MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR = 1UL << 39;
            public const ulong MAQ_COMPRIMENTO_ENTRE_VINCO_DE = 1UL << 40;
            public const ulong MAQ_COMPRIMENTO_ENTRE_VINCO_ATE = 1UL << 41;
            public const ulong MAQ_LARGURA_ENTRE_VINCO_DE = 1UL << 42;
            public const ulong MAQ_LARGURA_ENTRE_VINCO_ATE = 1UL << 43;
            public const ulong MAQ_ALTURA_ENTRE_VINCO_DE = 1UL << 44;
            public const ulong MAQ_ALTURA_ENTRE_VINCO_ATE = 1UL << 45;
            public const ulong MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE = 1UL << 46;
            public const ulong MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE = 1UL << 47;
            public const ulong MAQ_ABA_DE = 1UL << 48;
            public const ulong MAQ_ABA_ATE = 1UL << 49;
            public const ulong MAQ_LAP_DE = 1UL << 50;
            public const ulong MAQ_LAP_ATE = 1UL << 51;
            public const ulong MAQ_ONDAS = 1UL << 52;
            public const ulong MAQ_PROLONGA_LAP = 1UL << 53;
            public const ulong MAQ_LARGURA_IMPRESSAO = 1UL << 54;
            public const ulong MAQ_COMPRIMENTO_IMPRESSAO = 1UL << 55;
            public const ulong MAQ_ROLO_DISPOSITIVO_DE = 1UL << 56;
            public const ulong MAQ_ROLO_DISPOSITIVO_ATE = 1UL << 57;
            public const ulong MAQ_FAMILIAS = 1UL << 58;
            public const ulong MAQ_REFILE_MINIMO = 1UL << 59;
            public const ulong MAQ_LARGURA_UTIL = 1UL << 60;
            public const ulong MAQ_TOTAL_ACO = 1UL << 61;
            public const ulong MAQ_FECHAMENTO = 1UL << 62;
            public const ulong MAQ_OPERACAO_VINCAR = 1UL << 63;
        }

        public partial class MaquinaDecorator : IMaquinaEntity
{

                        private readonly IMaquinaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MaquinaDecorator(IMaquinaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MaquinaDecorator(
                            IMaquinaEntity inner,
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
                                    public string Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & MaquinaTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _inner.Descricao = value;
                                                if ((_trackingMask & MaquinaTrackingFields.Descricao) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "Descricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & MaquinaTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MaquinaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MaquinaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MaquinaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MaquinaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CAL_ID
                                    {
                                        get => _inner.CAL_ID;
                                        set
                                        {
                                            if (_inner.CAL_ID != value)
                                            {
                                                _inner.CAL_ID = value;
                                                if ((_trackingMask & MaquinaTrackingFields.CAL_ID) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "CAL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_CONTROL_IP
                                    {
                                        get => _inner.MAQ_CONTROL_IP;
                                        set
                                        {
                                            if (_inner.MAQ_CONTROL_IP != value)
                                            {
                                                _inner.MAQ_CONTROL_IP = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_CONTROL_IP) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_CONTROL_IP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GMA_ID
                                    {
                                        get => _inner.GMA_ID;
                                        set
                                        {
                                            if (_inner.GMA_ID != value)
                                            {
                                                _inner.GMA_ID = value;
                                                if ((_trackingMask & MaquinaTrackingFields.GMA_ID) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "GMA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? MAQ_ULTIMA_ATUALIZACAO
                                    {
                                        get => _inner.MAQ_ULTIMA_ATUALIZACAO;
                                        set
                                        {
                                            if (_inner.MAQ_ULTIMA_ATUALIZACAO != value)
                                            {
                                                _inner.MAQ_ULTIMA_ATUALIZACAO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ULTIMA_ATUALIZACAO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ULTIMA_ATUALIZACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_SIRENE_SEMAFORO
                                    {
                                        get => _inner.MAQ_SIRENE_SEMAFORO;
                                        set
                                        {
                                            if (_inner.MAQ_SIRENE_SEMAFORO != value)
                                            {
                                                _inner.MAQ_SIRENE_SEMAFORO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_SIRENE_SEMAFORO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_SIRENE_SEMAFORO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_COR_SEMAFORO
                                    {
                                        get => _inner.MAQ_COR_SEMAFORO;
                                        set
                                        {
                                            if (_inner.MAQ_COR_SEMAFORO != value)
                                            {
                                                _inner.MAQ_COR_SEMAFORO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COR_SEMAFORO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COR_SEMAFORO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID_MAQ_PAI
                                    {
                                        get => _inner.MAQ_ID_MAQ_PAI;
                                        set
                                        {
                                            if (_inner.MAQ_ID_MAQ_PAI != value)
                                            {
                                                _inner.MAQ_ID_MAQ_PAI = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ID_MAQ_PAI) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ID_MAQ_PAI", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_TIPO_CONTADOR
                                    {
                                        get => _inner.MAQ_TIPO_CONTADOR;
                                        set
                                        {
                                            if (_inner.MAQ_TIPO_CONTADOR != value)
                                            {
                                                _inner.MAQ_TIPO_CONTADOR = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_TIPO_CONTADOR) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_TIPO_CONTADOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_TIPO_PLANEJAMENTO
                                    {
                                        get => _inner.MAQ_TIPO_PLANEJAMENTO;
                                        set
                                        {
                                            if (_inner.MAQ_TIPO_PLANEJAMENTO != value)
                                            {
                                                _inner.MAQ_TIPO_PLANEJAMENTO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_TIPO_PLANEJAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_TIPO_PLANEJAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_AVALIA_CUSTO
                                    {
                                        get => _inner.MAQ_AVALIA_CUSTO;
                                        set
                                        {
                                            if (_inner.MAQ_AVALIA_CUSTO != value)
                                            {
                                                _inner.MAQ_AVALIA_CUSTO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_AVALIA_CUSTO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_AVALIA_CUSTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? FPR_ID_OP_PRODUZINDO
                                    {
                                        get => _inner.FPR_ID_OP_PRODUZINDO;
                                        set
                                        {
                                            if (_inner.FPR_ID_OP_PRODUZINDO != value)
                                            {
                                                _inner.FPR_ID_OP_PRODUZINDO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.FPR_ID_OP_PRODUZINDO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "FPR_ID_OP_PRODUZINDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_CONGELA_FILA
                                    {
                                        get => _inner.MAQ_CONGELA_FILA;
                                        set
                                        {
                                            if (_inner.MAQ_CONGELA_FILA != value)
                                            {
                                                _inner.MAQ_CONGELA_FILA = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_CONGELA_FILA) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_CONGELA_FILA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_TEMPO_MIN_PARADA
                                    {
                                        get => _inner.MAQ_TEMPO_MIN_PARADA;
                                        set
                                        {
                                            if (_inner.MAQ_TEMPO_MIN_PARADA != value)
                                            {
                                                _inner.MAQ_TEMPO_MIN_PARADA = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_TEMPO_MIN_PARADA) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_TEMPO_MIN_PARADA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_QTD_CORES
                                    {
                                        get => _inner.MAQ_QTD_CORES;
                                        set
                                        {
                                            if (_inner.MAQ_QTD_CORES != value)
                                            {
                                                _inner.MAQ_QTD_CORES = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_QTD_CORES) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_QTD_CORES", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID_INTEGRACAO
                                    {
                                        get => _inner.MAQ_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.MAQ_ID_INTEGRACAO != value)
                                            {
                                                _inner.MAQ_ID_INTEGRACAO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID_INTEGRACAO_ERP
                                    {
                                        get => _inner.MAQ_ID_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.MAQ_ID_INTEGRACAO_ERP != value)
                                            {
                                                _inner.MAQ_ID_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ID_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ID_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_HIERARQUIA_SEQ_TRANSFORMACAO
                                    {
                                        get => _inner.MAQ_HIERARQUIA_SEQ_TRANSFORMACAO;
                                        set
                                        {
                                            if (_inner.MAQ_HIERARQUIA_SEQ_TRANSFORMACAO != value)
                                            {
                                                _inner.MAQ_HIERARQUIA_SEQ_TRANSFORMACAO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_HIERARQUIA_SEQ_TRANSFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_HIERARQUIA_SEQ_TRANSFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EQU_ID
                                    {
                                        get => _inner.EQU_ID;
                                        set
                                        {
                                            if (_inner.EQU_ID != value)
                                            {
                                                _inner.EQU_ID = value;
                                                if ((_trackingMask & MaquinaTrackingFields.EQU_ID) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "EQU_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR
                                    {
                                        get => _inner.MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR;
                                        set
                                        {
                                            if (_inner.MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR != value)
                                            {
                                                _inner.MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_PERCENTUAL_INICIO_PASSO_ANTERIOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ACOMPANHA_LOTE_PILOTO
                                    {
                                        get => _inner.MAQ_ACOMPANHA_LOTE_PILOTO;
                                        set
                                        {
                                            if (_inner.MAQ_ACOMPANHA_LOTE_PILOTO != value)
                                            {
                                                _inner.MAQ_ACOMPANHA_LOTE_PILOTO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ACOMPANHA_LOTE_PILOTO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ACOMPANHA_LOTE_PILOTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_ID_SENSOR
                                    {
                                        get => _inner.MAQ_ID_SENSOR;
                                        set
                                        {
                                            if (_inner.MAQ_ID_SENSOR != value)
                                            {
                                                _inner.MAQ_ID_SENSOR = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ID_SENSOR) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ID_SENSOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_DEBOUNCING_LOW
                                    {
                                        get => _inner.MAQ_DEBOUNCING_LOW;
                                        set
                                        {
                                            if (_inner.MAQ_DEBOUNCING_LOW != value)
                                            {
                                                _inner.MAQ_DEBOUNCING_LOW = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_DEBOUNCING_LOW) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_DEBOUNCING_LOW", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_DEBOUNCING_HIGHT
                                    {
                                        get => _inner.MAQ_DEBOUNCING_HIGHT;
                                        set
                                        {
                                            if (_inner.MAQ_DEBOUNCING_HIGHT != value)
                                            {
                                                _inner.MAQ_DEBOUNCING_HIGHT = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_DEBOUNCING_HIGHT) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_DEBOUNCING_HIGHT", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MAQ_TIPO_SINAL
                                    {
                                        get => _inner.MAQ_TIPO_SINAL;
                                        set
                                        {
                                            if (_inner.MAQ_TIPO_SINAL != value)
                                            {
                                                _inner.MAQ_TIPO_SINAL = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_TIPO_SINAL) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_TIPO_SINAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? TEM_ID
                                    {
                                        get => _inner.TEM_ID;
                                        set
                                        {
                                            if (_inner.TEM_ID != value)
                                            {
                                                _inner.TEM_ID = value;
                                                if ((_trackingMask & MaquinaTrackingFields.TEM_ID) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "TEM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_CHAPA_DE
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_CHAPA_DE;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_CHAPA_DE != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_CHAPA_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_CHAPA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_CHAPA_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_CHAPA_ATE != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_CHAPA_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_CHAPA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_LARGURA_CHAPA_DE
                                    {
                                        get => _inner.MAQ_LARGURA_CHAPA_DE;
                                        set
                                        {
                                            if (_inner.MAQ_LARGURA_CHAPA_DE != value)
                                            {
                                                _inner.MAQ_LARGURA_CHAPA_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_LARGURA_CHAPA_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_LARGURA_CHAPA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_LARGURA_CHAPA_ATE
                                    {
                                        get => _inner.MAQ_LARGURA_CHAPA_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_LARGURA_CHAPA_ATE != value)
                                            {
                                                _inner.MAQ_LARGURA_CHAPA_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_LARGURA_CHAPA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_LARGURA_CHAPA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_CHAPA_DE_FACAO_SUPERIOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_SUPERIOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_CHAPA_DE_FACAO_INFERIOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_CHAPA_ATE_FACAO_INFERIOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_DE
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_ENTRE_VINCO_DE;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_ENTRE_VINCO_DE != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_ENTRE_VINCO_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_ENTRE_VINCO_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_ENTRE_VINCO_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_ENTRE_VINCO_ATE
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_ENTRE_VINCO_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_ENTRE_VINCO_ATE != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_ENTRE_VINCO_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_ENTRE_VINCO_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_ENTRE_VINCO_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_LARGURA_ENTRE_VINCO_DE
                                    {
                                        get => _inner.MAQ_LARGURA_ENTRE_VINCO_DE;
                                        set
                                        {
                                            if (_inner.MAQ_LARGURA_ENTRE_VINCO_DE != value)
                                            {
                                                _inner.MAQ_LARGURA_ENTRE_VINCO_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_LARGURA_ENTRE_VINCO_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_LARGURA_ENTRE_VINCO_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_LARGURA_ENTRE_VINCO_ATE
                                    {
                                        get => _inner.MAQ_LARGURA_ENTRE_VINCO_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_LARGURA_ENTRE_VINCO_ATE != value)
                                            {
                                                _inner.MAQ_LARGURA_ENTRE_VINCO_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_LARGURA_ENTRE_VINCO_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_LARGURA_ENTRE_VINCO_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_ALTURA_ENTRE_VINCO_DE
                                    {
                                        get => _inner.MAQ_ALTURA_ENTRE_VINCO_DE;
                                        set
                                        {
                                            if (_inner.MAQ_ALTURA_ENTRE_VINCO_DE != value)
                                            {
                                                _inner.MAQ_ALTURA_ENTRE_VINCO_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ALTURA_ENTRE_VINCO_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ALTURA_ENTRE_VINCO_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_ALTURA_ENTRE_VINCO_ATE
                                    {
                                        get => _inner.MAQ_ALTURA_ENTRE_VINCO_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_ALTURA_ENTRE_VINCO_ATE != value)
                                            {
                                                _inner.MAQ_ALTURA_ENTRE_VINCO_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ALTURA_ENTRE_VINCO_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ALTURA_ENTRE_VINCO_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_MAIS_LARGURA_ENTRE_VINCO_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_ABA_DE
                                    {
                                        get => _inner.MAQ_ABA_DE;
                                        set
                                        {
                                            if (_inner.MAQ_ABA_DE != value)
                                            {
                                                _inner.MAQ_ABA_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ABA_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ABA_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_ABA_ATE
                                    {
                                        get => _inner.MAQ_ABA_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_ABA_ATE != value)
                                            {
                                                _inner.MAQ_ABA_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ABA_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ABA_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_LAP_DE
                                    {
                                        get => _inner.MAQ_LAP_DE;
                                        set
                                        {
                                            if (_inner.MAQ_LAP_DE != value)
                                            {
                                                _inner.MAQ_LAP_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_LAP_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_LAP_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_LAP_ATE
                                    {
                                        get => _inner.MAQ_LAP_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_LAP_ATE != value)
                                            {
                                                _inner.MAQ_LAP_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_LAP_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_LAP_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ONDAS
                                    {
                                        get => _inner.MAQ_ONDAS;
                                        set
                                        {
                                            if (_inner.MAQ_ONDAS != value)
                                            {
                                                _inner.MAQ_ONDAS = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ONDAS) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ONDAS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_PROLONGA_LAP
                                    {
                                        get => _inner.MAQ_PROLONGA_LAP;
                                        set
                                        {
                                            if (_inner.MAQ_PROLONGA_LAP != value)
                                            {
                                                _inner.MAQ_PROLONGA_LAP = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_PROLONGA_LAP) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_PROLONGA_LAP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_LARGURA_IMPRESSAO
                                    {
                                        get => _inner.MAQ_LARGURA_IMPRESSAO;
                                        set
                                        {
                                            if (_inner.MAQ_LARGURA_IMPRESSAO != value)
                                            {
                                                _inner.MAQ_LARGURA_IMPRESSAO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_LARGURA_IMPRESSAO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_LARGURA_IMPRESSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_COMPRIMENTO_IMPRESSAO
                                    {
                                        get => _inner.MAQ_COMPRIMENTO_IMPRESSAO;
                                        set
                                        {
                                            if (_inner.MAQ_COMPRIMENTO_IMPRESSAO != value)
                                            {
                                                _inner.MAQ_COMPRIMENTO_IMPRESSAO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_COMPRIMENTO_IMPRESSAO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_COMPRIMENTO_IMPRESSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_ROLO_DISPOSITIVO_DE
                                    {
                                        get => _inner.MAQ_ROLO_DISPOSITIVO_DE;
                                        set
                                        {
                                            if (_inner.MAQ_ROLO_DISPOSITIVO_DE != value)
                                            {
                                                _inner.MAQ_ROLO_DISPOSITIVO_DE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ROLO_DISPOSITIVO_DE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ROLO_DISPOSITIVO_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_ROLO_DISPOSITIVO_ATE
                                    {
                                        get => _inner.MAQ_ROLO_DISPOSITIVO_ATE;
                                        set
                                        {
                                            if (_inner.MAQ_ROLO_DISPOSITIVO_ATE != value)
                                            {
                                                _inner.MAQ_ROLO_DISPOSITIVO_ATE = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_ROLO_DISPOSITIVO_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_ROLO_DISPOSITIVO_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_FAMILIAS
                                    {
                                        get => _inner.MAQ_FAMILIAS;
                                        set
                                        {
                                            if (_inner.MAQ_FAMILIAS != value)
                                            {
                                                _inner.MAQ_FAMILIAS = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_FAMILIAS) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_FAMILIAS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_REFILE_MINIMO
                                    {
                                        get => _inner.MAQ_REFILE_MINIMO;
                                        set
                                        {
                                            if (_inner.MAQ_REFILE_MINIMO != value)
                                            {
                                                _inner.MAQ_REFILE_MINIMO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_REFILE_MINIMO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_REFILE_MINIMO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_LARGURA_UTIL
                                    {
                                        get => _inner.MAQ_LARGURA_UTIL;
                                        set
                                        {
                                            if (_inner.MAQ_LARGURA_UTIL != value)
                                            {
                                                _inner.MAQ_LARGURA_UTIL = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_LARGURA_UTIL) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_LARGURA_UTIL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_TOTAL_ACO
                                    {
                                        get => _inner.MAQ_TOTAL_ACO;
                                        set
                                        {
                                            if (_inner.MAQ_TOTAL_ACO != value)
                                            {
                                                _inner.MAQ_TOTAL_ACO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_TOTAL_ACO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_TOTAL_ACO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_FECHAMENTO
                                    {
                                        get => _inner.MAQ_FECHAMENTO;
                                        set
                                        {
                                            if (_inner.MAQ_FECHAMENTO != value)
                                            {
                                                _inner.MAQ_FECHAMENTO = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_FECHAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_FECHAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_OPERACAO_VINCAR
                                    {
                                        get => _inner.MAQ_OPERACAO_VINCAR;
                                        set
                                        {
                                            if (_inner.MAQ_OPERACAO_VINCAR != value)
                                            {
                                                _inner.MAQ_OPERACAO_VINCAR = value;
                                                if ((_trackingMask & MaquinaTrackingFields.MAQ_OPERACAO_VINCAR) != 0UL)
                                                    _logger.DomainValueChanged("Maquina", "MAQ_OPERACAO_VINCAR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? MAQ_OPERACAO_MONTA_DIVISAO
                                    {
                                        get => _inner.MAQ_OPERACAO_MONTA_DIVISAO;
                                        set
                                        {
                                            if (_inner.MAQ_OPERACAO_MONTA_DIVISAO != value)
                                            {
                                                _inner.MAQ_OPERACAO_MONTA_DIVISAO = value;

                                            }
                                        }
                                    }

                                    public Decimal? MAQ_OPERACAO_SERRAR
                                    {
                                        get => _inner.MAQ_OPERACAO_SERRAR;
                                        set
                                        {
                                            if (_inner.MAQ_OPERACAO_SERRAR != value)
                                            {
                                                _inner.MAQ_OPERACAO_SERRAR = value;

                                            }
                                        }
                                    }

                                    public string MAQ_TIPO_LAP
                                    {
                                        get => _inner.MAQ_TIPO_LAP;
                                        set
                                        {
                                            if (_inner.MAQ_TIPO_LAP != value)
                                            {
                                                _inner.MAQ_TIPO_LAP = value;

                                            }
                                        }
                                    }

                                    public Decimal? MAQ_INDICE_PARADAS_POR_OP
                                    {
                                        get => _inner.MAQ_INDICE_PARADAS_POR_OP;
                                        set
                                        {
                                            if (_inner.MAQ_INDICE_PARADAS_POR_OP != value)
                                            {
                                                _inner.MAQ_INDICE_PARADAS_POR_OP = value;

                                            }
                                        }
                                    }

                                    public int? MAQ_PERDA_MAXIMA
                                    {
                                        get => _inner.MAQ_PERDA_MAXIMA;
                                        set
                                        {
                                            if (_inner.MAQ_PERDA_MAXIMA != value)
                                            {
                                                _inner.MAQ_PERDA_MAXIMA = value;

                                            }
                                        }
                                    }

                                    public int? MAQ_TOTAL_PECAS_REFILANDO
                                    {
                                        get => _inner.MAQ_TOTAL_PECAS_REFILANDO;
                                        set
                                        {
                                            if (_inner.MAQ_TOTAL_PECAS_REFILANDO != value)
                                            {
                                                _inner.MAQ_TOTAL_PECAS_REFILANDO = value;

                                            }
                                        }
                                    }

                                    public int? MAQ_TOTAL_PECAS_NAO_REFILANDO
                                    {
                                        get => _inner.MAQ_TOTAL_PECAS_NAO_REFILANDO;
                                        set
                                        {
                                            if (_inner.MAQ_TOTAL_PECAS_NAO_REFILANDO != value)
                                            {
                                                _inner.MAQ_TOTAL_PECAS_NAO_REFILANDO = value;

                                            }
                                        }
                                    }

                                    public int? MAQ_TOTAL_VINCOS
                                    {
                                        get => _inner.MAQ_TOTAL_VINCOS;
                                        set
                                        {
                                            if (_inner.MAQ_TOTAL_VINCOS != value)
                                            {
                                                _inner.MAQ_TOTAL_VINCOS = value;

                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration