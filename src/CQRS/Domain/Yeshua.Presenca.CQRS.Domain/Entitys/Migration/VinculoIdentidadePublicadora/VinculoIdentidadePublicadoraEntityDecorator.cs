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
                    public static class VinculoIdentidadePublicadoraTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong IdentidadeId = 1UL << 1;
            public const ulong UsuarioId = 1UL << 2;
            public const ulong Permissoes = 1UL << 3;
            public const ulong Versao = 1UL << 4;
            public const ulong TenantID = 1UL << 5;
            public const ulong Deleted = 1UL << 6;
            public const ulong Changed = 1UL << 7;
            public const ulong UserId = 1UL << 8;
            public const ulong OperationalEntityId = 1UL << 9;
        }

        public static class VinculoIdentidadePublicadoraOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification IdentidadeId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UsuarioId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Permissoes = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Versao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class VinculoIdentidadePublicadoraDecorator : IVinculoIdentidadePublicadoraEntity
{

                        private readonly IVinculoIdentidadePublicadoraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public VinculoIdentidadePublicadoraDecorator(IVinculoIdentidadePublicadoraEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public VinculoIdentidadePublicadoraDecorator(
                            IVinculoIdentidadePublicadoraEntity inner,
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
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.Id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.IdentidadeId) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "IdentidadeId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.IdentidadeId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? UsuarioId
                                    {
                                        get => _inner.UsuarioId;
                                        set
                                        {
                                            if (_inner.UsuarioId != value)
                                            {
                                                _inner.UsuarioId = value;
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.UsuarioId) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "UsuarioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.UsuarioId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? Permissoes
                                    {
                                        get => _inner.Permissoes;
                                        set
                                        {
                                            if (_inner.Permissoes != value)
                                            {
                                                _inner.Permissoes = value;
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.Permissoes) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "Permissoes", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.Permissoes, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? Versao
                                    {
                                        get => _inner.Versao;
                                        set
                                        {
                                            if (_inner.Versao != value)
                                            {
                                                _inner.Versao = value;
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.Versao) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "Versao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.Versao, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & VinculoIdentidadePublicadoraTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("VinculoIdentidadePublicadora", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, VinculoIdentidadePublicadoraOperationalFields.UserId, _trackingExecutionIdentity);
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