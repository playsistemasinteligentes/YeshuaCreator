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
                    public static class LaudoTesteFisicoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong LTF_ID = 1UL << 1;
            public const ulong LTF_EMISSAO = 1UL << 2;
            public const ulong LTF_VALOR = 1UL << 3;
            public const ulong LTF_OBS = 1UL << 4;
            public const ulong LTF_STATUS = 1UL << 5;
            public const ulong ORD_ID = 1UL << 6;
            public const ulong ROT_PRO_ID = 1UL << 7;
            public const ulong FPR_SEQ_REPETICAO = 1UL << 8;
            public const ulong USE_ID = 1UL << 9;
            public const ulong TenantID = 1UL << 10;
            public const ulong Deleted = 1UL << 11;
            public const ulong Changed = 1UL << 12;
            public const ulong UserId = 1UL << 13;
        }

        public partial class LaudoTesteFisicoDecorator : ILaudoTesteFisicoEntity
{

                        private readonly ILaudoTesteFisicoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public LaudoTesteFisicoDecorator(ILaudoTesteFisicoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public LaudoTesteFisicoDecorator(
                            ILaudoTesteFisicoEntity inner,
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
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int LTF_ID
                                    {
                                        get => _inner.LTF_ID;
                                        set
                                        {
                                            if (_inner.LTF_ID != value)
                                            {
                                                _inner.LTF_ID = value;
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.LTF_ID) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "LTF_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? LTF_EMISSAO
                                    {
                                        get => _inner.LTF_EMISSAO;
                                        set
                                        {
                                            if (_inner.LTF_EMISSAO != value)
                                            {
                                                _inner.LTF_EMISSAO = value;
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.LTF_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "LTF_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? LTF_VALOR
                                    {
                                        get => _inner.LTF_VALOR;
                                        set
                                        {
                                            if (_inner.LTF_VALOR != value)
                                            {
                                                _inner.LTF_VALOR = value;
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.LTF_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "LTF_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string LTF_OBS
                                    {
                                        get => _inner.LTF_OBS;
                                        set
                                        {
                                            if (_inner.LTF_OBS != value)
                                            {
                                                _inner.LTF_OBS = value;
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.LTF_OBS) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "LTF_OBS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string LTF_STATUS
                                    {
                                        get => _inner.LTF_STATUS;
                                        set
                                        {
                                            if (_inner.LTF_STATUS != value)
                                            {
                                                _inner.LTF_STATUS = value;
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.LTF_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "LTF_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.ORD_ID) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "ORD_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ROT_PRO_ID
                                    {
                                        get => _inner.ROT_PRO_ID;
                                        set
                                        {
                                            if (_inner.ROT_PRO_ID != value)
                                            {
                                                _inner.ROT_PRO_ID = value;
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.ROT_PRO_ID) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "ROT_PRO_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.FPR_SEQ_REPETICAO) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "FPR_SEQ_REPETICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & LaudoTesteFisicoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("LaudoTesteFisico", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration