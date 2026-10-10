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
                    public static class TabelaTrackingFields
        {
            public const ulong ID_TABELA = 1UL << 0;
            public const ulong CODIGO = 1UL << 1;
            public const ulong NOME = 1UL << 2;
            public const ulong OperationalEntityId = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public static class TabelaOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification ID_TABELA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CODIGO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification NOME = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class TabelaDecorator : ITabelaEntity
{

                        private readonly ITabelaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public TabelaDecorator(ITabelaEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public TabelaDecorator(
                            ITabelaEntity inner,
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
                                    public int ID_TABELA
                                    {
                                        get => _inner.ID_TABELA;
                                        set
                                        {
                                            if (_inner.ID_TABELA != value)
                                            {
                                                _inner.ID_TABELA = value;
                                                if ((_trackingMask & TabelaTrackingFields.ID_TABELA) != 0UL)
                                                    _logger.DomainValueChanged("Tabela", "ID_TABELA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TabelaOperationalFields.ID_TABELA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string CODIGO
                                    {
                                        get => _inner.CODIGO;
                                        set
                                        {
                                            if (_inner.CODIGO != value)
                                            {
                                                _inner.CODIGO = value;
                                                if ((_trackingMask & TabelaTrackingFields.CODIGO) != 0UL)
                                                    _logger.DomainValueChanged("Tabela", "CODIGO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TabelaOperationalFields.CODIGO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string NOME
                                    {
                                        get => _inner.NOME;
                                        set
                                        {
                                            if (_inner.NOME != value)
                                            {
                                                _inner.NOME = value;
                                                if ((_trackingMask & TabelaTrackingFields.NOME) != 0UL)
                                                    _logger.DomainValueChanged("Tabela", "NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TabelaOperationalFields.NOME, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public int? TenantID
                                    {
                                        get => _inner.TenantID;
                                        set
                                        {
                                            if (_inner.TenantID != value)
                                            {
                                                _inner.TenantID = value;
                                                if ((_trackingMask & TabelaTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Tabela", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TabelaOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TabelaTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Tabela", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TabelaOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TabelaTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Tabela", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TabelaOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & TabelaTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Tabela", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, TabelaOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration