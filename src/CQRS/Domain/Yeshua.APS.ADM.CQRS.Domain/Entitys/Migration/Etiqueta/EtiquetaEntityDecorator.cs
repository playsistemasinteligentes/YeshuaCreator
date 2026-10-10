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
                    public static class EtiquetaTrackingFields
        {
            public const ulong ETI_ID = 1UL << 0;
            public const ulong ETI_EMISSAO = 1UL << 1;
            public const ulong ETI_CODIGO_BARRAS = 1UL << 2;
            public const ulong ETI_SEQUENCIA = 1UL << 3;
            public const ulong ETI_NUMERO_COPIAS = 1UL << 4;
            public const ulong ETI_STATUS = 1UL << 5;
            public const ulong ETI_DATA_FABRICACAO = 1UL << 6;
            public const ulong ETI_COD_BARRAS_ORIGINAL = 1UL << 7;
            public const ulong ETI_OP_ORIGINAL = 1UL << 8;
            public const ulong MAQ_ID = 1UL << 9;
            public const ulong IMP_ID = 1UL << 10;
            public const ulong USE_ID = 1UL << 11;
            public const ulong ORD_ID = 1UL << 12;
            public const ulong ROT_PRO_ID = 1UL << 13;
            public const ulong ROT_SEQ_TRANFORMACAO = 1UL << 14;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 15;
            public const ulong ETI_QUANTIDADE_PALETE = 1UL << 16;
            public const ulong ETI_LOTE = 1UL << 17;
            public const ulong ETI_SUB_LOTE = 1UL << 18;
            public const ulong ETI_IMPRIMIR_DE = 1UL << 19;
            public const ulong ETI_IMPRIMIR_ATE = 1UL << 20;
            public const ulong BOL_ID = 1UL << 21;
            public const ulong COR_SEQUENCIA = 1UL << 22;
            public const ulong TenantID = 1UL << 23;
            public const ulong Deleted = 1UL << 24;
            public const ulong Changed = 1UL << 25;
            public const ulong UserId = 1UL << 26;
            public const ulong OperationalEntityId = 1UL << 27;
        }

        public static class EtiquetaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification ETI_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_EMISSAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_CODIGO_BARRAS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_SEQUENCIA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_NUMERO_COPIAS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_STATUS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_DATA_FABRICACAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_COD_BARRAS_ORIGINAL = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_OP_ORIGINAL = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MAQ_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IMP_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification USE_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ORD_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ROT_PRO_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ROT_SEQ_TRANFORMACAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification FPR_SEQ_REPETICAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_QUANTIDADE_PALETE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_LOTE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_SUB_LOTE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_IMPRIMIR_DE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ETI_IMPRIMIR_ATE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification COR_SEQUENCIA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class EtiquetaDecorator : IEtiquetaEntity
{

                        private readonly IEtiquetaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public EtiquetaDecorator(IEtiquetaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public EtiquetaDecorator(
                            IEtiquetaEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingExecutionIdentity = context is null
                                ? default
                                : new Dominio.Operational.OperationalExecutionIdentity(
                                    context.RootOperationId,
                                    context.OperationId,
                                    context.ExecutionId,
                                    context.CausationId);
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public int ETI_ID
                                    {
                                        get => _inner.ETI_ID;
                                        set
                                        {
                                            if (_inner.ETI_ID != value)
                                            {
                                                _inner.ETI_ID = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? ETI_EMISSAO
                                    {
                                        get => _inner.ETI_EMISSAO;
                                        set
                                        {
                                            if (_inner.ETI_EMISSAO != value)
                                            {
                                                _inner.ETI_EMISSAO = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_EMISSAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ETI_CODIGO_BARRAS
                                    {
                                        get => _inner.ETI_CODIGO_BARRAS;
                                        set
                                        {
                                            if (_inner.ETI_CODIGO_BARRAS != value)
                                            {
                                                _inner.ETI_CODIGO_BARRAS = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_CODIGO_BARRAS) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_CODIGO_BARRAS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_CODIGO_BARRAS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ETI_SEQUENCIA
                                    {
                                        get => _inner.ETI_SEQUENCIA;
                                        set
                                        {
                                            if (_inner.ETI_SEQUENCIA != value)
                                            {
                                                _inner.ETI_SEQUENCIA = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_SEQUENCIA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ETI_NUMERO_COPIAS
                                    {
                                        get => _inner.ETI_NUMERO_COPIAS;
                                        set
                                        {
                                            if (_inner.ETI_NUMERO_COPIAS != value)
                                            {
                                                _inner.ETI_NUMERO_COPIAS = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_NUMERO_COPIAS) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_NUMERO_COPIAS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_NUMERO_COPIAS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ETI_STATUS
                                    {
                                        get => _inner.ETI_STATUS;
                                        set
                                        {
                                            if (_inner.ETI_STATUS != value)
                                            {
                                                _inner.ETI_STATUS = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_STATUS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? ETI_DATA_FABRICACAO
                                    {
                                        get => _inner.ETI_DATA_FABRICACAO;
                                        set
                                        {
                                            if (_inner.ETI_DATA_FABRICACAO != value)
                                            {
                                                _inner.ETI_DATA_FABRICACAO = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_DATA_FABRICACAO) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_DATA_FABRICACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_DATA_FABRICACAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ETI_COD_BARRAS_ORIGINAL
                                    {
                                        get => _inner.ETI_COD_BARRAS_ORIGINAL;
                                        set
                                        {
                                            if (_inner.ETI_COD_BARRAS_ORIGINAL != value)
                                            {
                                                _inner.ETI_COD_BARRAS_ORIGINAL = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_COD_BARRAS_ORIGINAL) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_COD_BARRAS_ORIGINAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_COD_BARRAS_ORIGINAL, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ETI_OP_ORIGINAL
                                    {
                                        get => _inner.ETI_OP_ORIGINAL;
                                        set
                                        {
                                            if (_inner.ETI_OP_ORIGINAL != value)
                                            {
                                                _inner.ETI_OP_ORIGINAL = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_OP_ORIGINAL) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_OP_ORIGINAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_OP_ORIGINAL, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MAQ_ID
                                    {
                                        get => _inner.MAQ_ID;
                                        set
                                        {
                                            if (_inner.MAQ_ID != value)
                                            {
                                                _inner.MAQ_ID = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.MAQ_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? IMP_ID
                                    {
                                        get => _inner.IMP_ID;
                                        set
                                        {
                                            if (_inner.IMP_ID != value)
                                            {
                                                _inner.IMP_ID = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.IMP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "IMP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.IMP_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? USE_ID
                                    {
                                        get => _inner.USE_ID;
                                        set
                                        {
                                            if (_inner.USE_ID != value)
                                            {
                                                _inner.USE_ID = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.USE_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ORD_ID
                                    {
                                        get => _inner.ORD_ID;
                                        set
                                        {
                                            if (_inner.ORD_ID != value)
                                            {
                                                _inner.ORD_ID = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ORD_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ROT_PRO_ID
                                    {
                                        get => _inner.ROT_PRO_ID;
                                        set
                                        {
                                            if (_inner.ROT_PRO_ID != value)
                                            {
                                                _inner.ROT_PRO_ID = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ROT_PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ROT_PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ROT_PRO_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ROT_SEQ_TRANFORMACAO
                                    {
                                        get => _inner.ROT_SEQ_TRANFORMACAO;
                                        set
                                        {
                                            if (_inner.ROT_SEQ_TRANFORMACAO != value)
                                            {
                                                _inner.ROT_SEQ_TRANFORMACAO = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ROT_SEQ_TRANFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ROT_SEQ_TRANFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ROT_SEQ_TRANFORMACAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? FPR_SEQ_REPETICAO
                                    {
                                        get => _inner.FPR_SEQ_REPETICAO;
                                        set
                                        {
                                            if (_inner.FPR_SEQ_REPETICAO != value)
                                            {
                                                _inner.FPR_SEQ_REPETICAO = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.FPR_SEQ_REPETICAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? ETI_QUANTIDADE_PALETE
                                    {
                                        get => _inner.ETI_QUANTIDADE_PALETE;
                                        set
                                        {
                                            if (_inner.ETI_QUANTIDADE_PALETE != value)
                                            {
                                                _inner.ETI_QUANTIDADE_PALETE = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_QUANTIDADE_PALETE) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_QUANTIDADE_PALETE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_QUANTIDADE_PALETE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ETI_LOTE
                                    {
                                        get => _inner.ETI_LOTE;
                                        set
                                        {
                                            if (_inner.ETI_LOTE != value)
                                            {
                                                _inner.ETI_LOTE = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_LOTE) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_LOTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_LOTE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ETI_SUB_LOTE
                                    {
                                        get => _inner.ETI_SUB_LOTE;
                                        set
                                        {
                                            if (_inner.ETI_SUB_LOTE != value)
                                            {
                                                _inner.ETI_SUB_LOTE = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_SUB_LOTE) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_SUB_LOTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_SUB_LOTE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ETI_IMPRIMIR_DE
                                    {
                                        get => _inner.ETI_IMPRIMIR_DE;
                                        set
                                        {
                                            if (_inner.ETI_IMPRIMIR_DE != value)
                                            {
                                                _inner.ETI_IMPRIMIR_DE = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_IMPRIMIR_DE) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_IMPRIMIR_DE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_IMPRIMIR_DE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ETI_IMPRIMIR_ATE
                                    {
                                        get => _inner.ETI_IMPRIMIR_ATE;
                                        set
                                        {
                                            if (_inner.ETI_IMPRIMIR_ATE != value)
                                            {
                                                _inner.ETI_IMPRIMIR_ATE = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.ETI_IMPRIMIR_ATE) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "ETI_IMPRIMIR_ATE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.ETI_IMPRIMIR_ATE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? BOL_ID
                                    {
                                        get => _inner.BOL_ID;
                                        set
                                        {
                                            if (_inner.BOL_ID != value)
                                            {
                                                _inner.BOL_ID = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.BOL_ID) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "BOL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.BOL_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? COR_SEQUENCIA
                                    {
                                        get => _inner.COR_SEQUENCIA;
                                        set
                                        {
                                            if (_inner.COR_SEQUENCIA != value)
                                            {
                                                _inner.COR_SEQUENCIA = value;
                                                if ((_trackingMask & EtiquetaTrackingFields.COR_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "COR_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.COR_SEQUENCIA, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EtiquetaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EtiquetaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EtiquetaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & EtiquetaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Etiqueta", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, EtiquetaOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration