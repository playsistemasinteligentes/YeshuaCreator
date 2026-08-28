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
                    public static class OperacoesTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong OPE_TIPO_REGISTRO = 1UL << 1;
            public const ulong OPE_ID = 1UL << 2;
            public const ulong GMA_ID = 1UL << 3;
            public const ulong MAQ_ID = 1UL << 4;
            public const ulong PRO_ID = 1UL << 5;
            public const ulong OPE_EXCECAO = 1UL << 6;
            public const ulong ROT_SEQ_TRANFORMACAO = 1UL << 7;
            public const ulong ORD_ID = 1UL << 8;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 9;
            public const ulong TenantID = 1UL << 10;
            public const ulong Deleted = 1UL << 11;
            public const ulong Changed = 1UL << 12;
            public const ulong UserId = 1UL << 13;
        }

        public partial class OperacoesDecorator : IOperacoesEntity
{

                        private readonly IOperacoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public OperacoesDecorator(IOperacoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public OperacoesDecorator(
                            IOperacoesEntity inner,
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
                                                if ((_trackingMask & OperacoesTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OPE_TIPO_REGISTRO
                                    {
                                        get => _inner.OPE_TIPO_REGISTRO;
                                        set
                                        {
                                            if (_inner.OPE_TIPO_REGISTRO != value)
                                            {
                                                _inner.OPE_TIPO_REGISTRO = value;
                                                if ((_trackingMask & OperacoesTrackingFields.OPE_TIPO_REGISTRO) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "OPE_TIPO_REGISTRO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OPE_ID
                                    {
                                        get => _inner.OPE_ID;
                                        set
                                        {
                                            if (_inner.OPE_ID != value)
                                            {
                                                _inner.OPE_ID = value;
                                                if ((_trackingMask & OperacoesTrackingFields.OPE_ID) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "OPE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OperacoesTrackingFields.GMA_ID) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "GMA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MAQ_ID
                                    {
                                        get => _inner.MAQ_ID;
                                        set
                                        {
                                            if (_inner.MAQ_ID != value)
                                            {
                                                _inner.MAQ_ID = value;
                                                if ((_trackingMask & OperacoesTrackingFields.MAQ_ID) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "MAQ_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID
                                    {
                                        get => _inner.PRO_ID;
                                        set
                                        {
                                            if (_inner.PRO_ID != value)
                                            {
                                                _inner.PRO_ID = value;
                                                if ((_trackingMask & OperacoesTrackingFields.PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OPE_EXCECAO
                                    {
                                        get => _inner.OPE_EXCECAO;
                                        set
                                        {
                                            if (_inner.OPE_EXCECAO != value)
                                            {
                                                _inner.OPE_EXCECAO = value;
                                                if ((_trackingMask & OperacoesTrackingFields.OPE_EXCECAO) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "OPE_EXCECAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int ROT_SEQ_TRANFORMACAO
                                    {
                                        get => _inner.ROT_SEQ_TRANFORMACAO;
                                        set
                                        {
                                            if (_inner.ROT_SEQ_TRANFORMACAO != value)
                                            {
                                                _inner.ROT_SEQ_TRANFORMACAO = value;
                                                if ((_trackingMask & OperacoesTrackingFields.ROT_SEQ_TRANFORMACAO) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "ROT_SEQ_TRANFORMACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OperacoesTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int FPR_SEQ_REPETICAO
                                    {
                                        get => _inner.FPR_SEQ_REPETICAO;
                                        set
                                        {
                                            if (_inner.FPR_SEQ_REPETICAO != value)
                                            {
                                                _inner.FPR_SEQ_REPETICAO = value;
                                                if ((_trackingMask & OperacoesTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OperacoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OperacoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OperacoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & OperacoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Operacoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration