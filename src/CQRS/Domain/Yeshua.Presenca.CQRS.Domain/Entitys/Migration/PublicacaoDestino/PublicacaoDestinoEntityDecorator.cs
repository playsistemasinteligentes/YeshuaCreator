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
                    public static class PublicacaoDestinoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong IdentidadeId = 1UL << 1;
            public const ulong VersaoId = 1UL << 2;
            public const ulong CanalId = 1UL << 3;
            public const ulong Estado = 1UL << 4;
            public const ulong Tentativas = 1UL << 5;
            public const ulong ProximaTentativaUtc = 1UL << 6;
            public const ulong ReciboExterno = 1UL << 7;
            public const ulong UrlPublica = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
            public const ulong OperationalEntityId = 1UL << 13;
            public const ulong CodigoErro = 1UL << 14;
            public const ulong NaturezaFalha = 1UL << 15;
            public const ulong RetryPossivel = 1UL << 16;
        }

        public static class PublicacaoDestinoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IdentidadeId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VersaoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CanalId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Estado = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Tentativas = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProximaTentativaUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ReciboExterno = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UrlPublica = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CodigoErro = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification NaturezaFalha = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RetryPossivel = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class PublicacaoDestinoDecorator : IPublicacaoDestinoEntity
{

                        private readonly IPublicacaoDestinoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PublicacaoDestinoDecorator(IPublicacaoDestinoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PublicacaoDestinoDecorator(
                            IPublicacaoDestinoEntity inner,
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
                                    public string? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? IdentidadeId
                                    {
                                        get => _inner.IdentidadeId;
                                        set
                                        {
                                            if (_inner.IdentidadeId != value)
                                            {
                                                _inner.IdentidadeId = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.IdentidadeId) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "IdentidadeId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.IdentidadeId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? VersaoId
                                    {
                                        get => _inner.VersaoId;
                                        set
                                        {
                                            if (_inner.VersaoId != value)
                                            {
                                                _inner.VersaoId = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.VersaoId) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "VersaoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.VersaoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CanalId
                                    {
                                        get => _inner.CanalId;
                                        set
                                        {
                                            if (_inner.CanalId != value)
                                            {
                                                _inner.CanalId = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.CanalId) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "CanalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.CanalId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Estado
                                    {
                                        get => _inner.Estado;
                                        set
                                        {
                                            if (_inner.Estado != value)
                                            {
                                                _inner.Estado = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.Estado) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "Estado", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.Estado, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? Tentativas
                                    {
                                        get => _inner.Tentativas;
                                        set
                                        {
                                            if (_inner.Tentativas != value)
                                            {
                                                _inner.Tentativas = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.Tentativas) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "Tentativas", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.Tentativas, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? ProximaTentativaUtc
                                    {
                                        get => _inner.ProximaTentativaUtc;
                                        set
                                        {
                                            if (_inner.ProximaTentativaUtc != value)
                                            {
                                                _inner.ProximaTentativaUtc = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.ProximaTentativaUtc) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "ProximaTentativaUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.ProximaTentativaUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ReciboExterno
                                    {
                                        get => _inner.ReciboExterno;
                                        set
                                        {
                                            if (_inner.ReciboExterno != value)
                                            {
                                                _inner.ReciboExterno = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.ReciboExterno) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "ReciboExterno", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.ReciboExterno, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? UrlPublica
                                    {
                                        get => _inner.UrlPublica;
                                        set
                                        {
                                            if (_inner.UrlPublica != value)
                                            {
                                                _inner.UrlPublica = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.UrlPublica) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "UrlPublica", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.UrlPublica, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public string? CodigoErro
                                    {
                                        get => _inner.CodigoErro;
                                        set
                                        {
                                            if (_inner.CodigoErro != value)
                                            {
                                                _inner.CodigoErro = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.CodigoErro) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "CodigoErro", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.CodigoErro, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? NaturezaFalha
                                    {
                                        get => _inner.NaturezaFalha;
                                        set
                                        {
                                            if (_inner.NaturezaFalha != value)
                                            {
                                                _inner.NaturezaFalha = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.NaturezaFalha) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "NaturezaFalha", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.NaturezaFalha, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public bool? RetryPossivel
                                    {
                                        get => _inner.RetryPossivel;
                                        set
                                        {
                                            if (_inner.RetryPossivel != value)
                                            {
                                                _inner.RetryPossivel = value;
                                                if ((_trackingMask & PublicacaoDestinoTrackingFields.RetryPossivel) != 0UL)
                                                    _logger.DomainValueChanged("PublicacaoDestino", "RetryPossivel", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PublicacaoDestinoOperationalFields.RetryPossivel, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration