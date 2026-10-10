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
                    public static class ColaboradorTrackingFields
        {
            public const ulong COL_CPF = 1UL << 0;
            public const ulong COL_NOME = 1UL << 1;
            public const ulong COL_NASCIMENTO = 1UL << 2;
            public const ulong COL_EMAIL = 1UL << 3;
            public const ulong COL_MATRICULA = 1UL << 4;
            public const ulong TURM_id = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
            public const ulong OperationalEntityId = 1UL << 10;
        }

        public static class ColaboradorOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification COL_CPF = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification COL_NOME = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification COL_NASCIMENTO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification COL_EMAIL = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification COL_MATRICULA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TURM_id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class ColaboradorDecorator : IColaboradorEntity
{

                        private readonly IColaboradorEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ColaboradorDecorator(IColaboradorEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ColaboradorDecorator(
                            IColaboradorEntity inner,
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
                                    public string COL_CPF
                                    {
                                        get => _inner.COL_CPF;
                                        set
                                        {
                                            if (_inner.COL_CPF != value)
                                            {
                                                _inner.COL_CPF = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_CPF) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_CPF", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.COL_CPF, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string COL_NOME
                                    {
                                        get => _inner.COL_NOME;
                                        set
                                        {
                                            if (_inner.COL_NOME != value)
                                            {
                                                _inner.COL_NOME = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_NOME) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.COL_NOME, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime COL_NASCIMENTO
                                    {
                                        get => _inner.COL_NASCIMENTO;
                                        set
                                        {
                                            if (_inner.COL_NASCIMENTO != value)
                                            {
                                                _inner.COL_NASCIMENTO = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_NASCIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_NASCIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.COL_NASCIMENTO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string COL_EMAIL
                                    {
                                        get => _inner.COL_EMAIL;
                                        set
                                        {
                                            if (_inner.COL_EMAIL != value)
                                            {
                                                _inner.COL_EMAIL = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_EMAIL) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_EMAIL", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.COL_EMAIL, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string COL_MATRICULA
                                    {
                                        get => _inner.COL_MATRICULA;
                                        set
                                        {
                                            if (_inner.COL_MATRICULA != value)
                                            {
                                                _inner.COL_MATRICULA = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_MATRICULA) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_MATRICULA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.COL_MATRICULA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string TURM_id
                                    {
                                        get => _inner.TURM_id;
                                        set
                                        {
                                            if (_inner.TURM_id != value)
                                            {
                                                _inner.TURM_id = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.TURM_id) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "TURM_id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.TURM_id, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ColaboradorTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ColaboradorTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ColaboradorTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ColaboradorTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ColaboradorOperationalFields.UserId, _trackingExecutionIdentity);
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