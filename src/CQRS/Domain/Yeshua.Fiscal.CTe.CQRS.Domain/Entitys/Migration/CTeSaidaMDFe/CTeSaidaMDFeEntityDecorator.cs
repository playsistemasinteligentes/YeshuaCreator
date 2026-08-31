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
                    public static class CTeSaidaMDFeTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CTeTentativaEmissaoId = 1UL << 1;
            public const ulong CorrelationId = 1UL << 2;
            public const ulong ChaveAcessoCTe = 1UL << 3;
            public const ulong SnapshotHash = 1UL << 4;
            public const ulong OutboxMessageId = 1UL << 5;
            public const ulong PublicadoEmUtc = 1UL << 6;
            public const ulong UltimoErro = 1UL << 7;
            public const ulong Status = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
        }

        public partial class CTeSaidaMDFeDecorator : ICTeSaidaMDFeEntity
{

                        private readonly ICTeSaidaMDFeEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CTeSaidaMDFeDecorator(ICTeSaidaMDFeEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CTeSaidaMDFeDecorator(
                            ICTeSaidaMDFeEntity inner,
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
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int CTeTentativaEmissaoId
                                    {
                                        get => _inner.CTeTentativaEmissaoId;
                                        set
                                        {
                                            if (_inner.CTeTentativaEmissaoId != value)
                                            {
                                                _inner.CTeTentativaEmissaoId = value;
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.CTeTentativaEmissaoId) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "CTeTentativaEmissaoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CorrelationId
                                    {
                                        get => _inner.CorrelationId;
                                        set
                                        {
                                            if (_inner.CorrelationId != value)
                                            {
                                                _inner.CorrelationId = value;
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ChaveAcessoCTe
                                    {
                                        get => _inner.ChaveAcessoCTe;
                                        set
                                        {
                                            if (_inner.ChaveAcessoCTe != value)
                                            {
                                                _inner.ChaveAcessoCTe = value;
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.ChaveAcessoCTe) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "ChaveAcessoCTe", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SnapshotHash
                                    {
                                        get => _inner.SnapshotHash;
                                        set
                                        {
                                            if (_inner.SnapshotHash != value)
                                            {
                                                _inner.SnapshotHash = value;
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.SnapshotHash) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "SnapshotHash", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OutboxMessageId
                                    {
                                        get => _inner.OutboxMessageId;
                                        set
                                        {
                                            if (_inner.OutboxMessageId != value)
                                            {
                                                _inner.OutboxMessageId = value;
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.OutboxMessageId) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "OutboxMessageId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? PublicadoEmUtc
                                    {
                                        get => _inner.PublicadoEmUtc;
                                        set
                                        {
                                            if (_inner.PublicadoEmUtc != value)
                                            {
                                                _inner.PublicadoEmUtc = value;
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.PublicadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "PublicadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UltimoErro
                                    {
                                        get => _inner.UltimoErro;
                                        set
                                        {
                                            if (_inner.UltimoErro != value)
                                            {
                                                _inner.UltimoErro = value;
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.UltimoErro) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "UltimoErro", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeSaidaMDFeTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CTeSaidaMDFe", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration