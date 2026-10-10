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
                    public static class BoletimTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong BOL_ID = 1UL << 1;
            public const ulong BOL_ID_ORIGEM = 1UL << 2;
            public const ulong BOL_SOLVER = 1UL << 3;
            public const ulong BOL_INTEGRACAO = 1UL << 4;
            public const ulong BOL_SEQUENCIA = 1UL << 5;
            public const ulong GRP_PAP_GRAMATURA_PROGRAMADO = 1UL << 6;
            public const ulong GRP_ID_PROGRAMADO = 1UL << 7;
            public const ulong GRP_PAPEL1_PROGRAMADO = 1UL << 8;
            public const ulong GRP_PAPEL2_PROGRAMADO = 1UL << 9;
            public const ulong GRP_PAPEL3_PROGRAMADO = 1UL << 10;
            public const ulong GRP_PAPEL4_PROGRAMADO = 1UL << 11;
            public const ulong GRP_PAPEL5_PROGRAMADO = 1UL << 12;
            public const ulong BOL_STATUS_INTERFACE = 1UL << 13;
            public const ulong BOL_TIPO = 1UL << 14;
            public const ulong BOL_FORMATO = 1UL << 15;
            public const ulong BOL_GRAMATURA_PAPEIS_PROGRAMADOS = 1UL << 16;
            public const ulong BOL_GRAMATURA_PAPEIS_REALIZADO = 1UL << 17;
            public const ulong BOL_CUSTO_PAPEIS_PROGRAMADOS = 1UL << 18;
            public const ulong BOL_CUSTO_PAPEIS_REALIZADO = 1UL << 19;
            public const ulong BOL_GRAMATURA_RESINA_PROGRAMADOS = 1UL << 20;
            public const ulong BOL_CUSTO_RESINA_PROGRAMADOS = 1UL << 21;
            public const ulong BOL_REFILE_OBRIGATORIO = 1UL << 22;
            public const ulong BOL_OBS = 1UL << 23;
            public const ulong TenantID = 1UL << 24;
            public const ulong Deleted = 1UL << 25;
            public const ulong Changed = 1UL << 26;
            public const ulong UserId = 1UL << 27;
            public const ulong OperationalEntityId = 1UL << 28;
        }

        public static class BoletimOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_ID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_ID_ORIGEM = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_SOLVER = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_INTEGRACAO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_SEQUENCIA = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRP_PAP_GRAMATURA_PROGRAMADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRP_ID_PROGRAMADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRP_PAPEL1_PROGRAMADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRP_PAPEL2_PROGRAMADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRP_PAPEL3_PROGRAMADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRP_PAPEL4_PROGRAMADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification GRP_PAPEL5_PROGRAMADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_STATUS_INTERFACE = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_TIPO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_FORMATO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_GRAMATURA_PAPEIS_PROGRAMADOS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_GRAMATURA_PAPEIS_REALIZADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_CUSTO_PAPEIS_PROGRAMADOS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_CUSTO_PAPEIS_REALIZADO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_GRAMATURA_RESINA_PROGRAMADOS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_CUSTO_RESINA_PROGRAMADOS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_REFILE_OBRIGATORIO = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification BOL_OBS = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class BoletimDecorator : IBoletimEntity
{

                        private readonly IBoletimEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public BoletimDecorator(IBoletimEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public BoletimDecorator(
                            IBoletimEntity inner,
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
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & BoletimTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string BOL_ID
                                    {
                                        get => _inner.BOL_ID;
                                        set
                                        {
                                            if (_inner.BOL_ID != value)
                                            {
                                                _inner.BOL_ID = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_ID) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_ID, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? BOL_ID_ORIGEM
                                    {
                                        get => _inner.BOL_ID_ORIGEM;
                                        set
                                        {
                                            if (_inner.BOL_ID_ORIGEM != value)
                                            {
                                                _inner.BOL_ID_ORIGEM = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_ID_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_ID_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_ID_ORIGEM, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? BOL_SOLVER
                                    {
                                        get => _inner.BOL_SOLVER;
                                        set
                                        {
                                            if (_inner.BOL_SOLVER != value)
                                            {
                                                _inner.BOL_SOLVER = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_SOLVER) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_SOLVER", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_SOLVER, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? BOL_INTEGRACAO
                                    {
                                        get => _inner.BOL_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.BOL_INTEGRACAO != value)
                                            {
                                                _inner.BOL_INTEGRACAO = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_INTEGRACAO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? BOL_SEQUENCIA
                                    {
                                        get => _inner.BOL_SEQUENCIA;
                                        set
                                        {
                                            if (_inner.BOL_SEQUENCIA != value)
                                            {
                                                _inner.BOL_SEQUENCIA = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_SEQUENCIA, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal GRP_PAP_GRAMATURA_PROGRAMADO
                                    {
                                        get => _inner.GRP_PAP_GRAMATURA_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.GRP_PAP_GRAMATURA_PROGRAMADO != value)
                                            {
                                                _inner.GRP_PAP_GRAMATURA_PROGRAMADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.GRP_PAP_GRAMATURA_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "GRP_PAP_GRAMATURA_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.GRP_PAP_GRAMATURA_PROGRAMADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string GRP_ID_PROGRAMADO
                                    {
                                        get => _inner.GRP_ID_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.GRP_ID_PROGRAMADO != value)
                                            {
                                                _inner.GRP_ID_PROGRAMADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.GRP_ID_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "GRP_ID_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.GRP_ID_PROGRAMADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GRP_PAPEL1_PROGRAMADO
                                    {
                                        get => _inner.GRP_PAPEL1_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL1_PROGRAMADO != value)
                                            {
                                                _inner.GRP_PAPEL1_PROGRAMADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.GRP_PAPEL1_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "GRP_PAPEL1_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.GRP_PAPEL1_PROGRAMADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GRP_PAPEL2_PROGRAMADO
                                    {
                                        get => _inner.GRP_PAPEL2_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL2_PROGRAMADO != value)
                                            {
                                                _inner.GRP_PAPEL2_PROGRAMADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.GRP_PAPEL2_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "GRP_PAPEL2_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.GRP_PAPEL2_PROGRAMADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GRP_PAPEL3_PROGRAMADO
                                    {
                                        get => _inner.GRP_PAPEL3_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL3_PROGRAMADO != value)
                                            {
                                                _inner.GRP_PAPEL3_PROGRAMADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.GRP_PAPEL3_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "GRP_PAPEL3_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.GRP_PAPEL3_PROGRAMADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GRP_PAPEL4_PROGRAMADO
                                    {
                                        get => _inner.GRP_PAPEL4_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL4_PROGRAMADO != value)
                                            {
                                                _inner.GRP_PAPEL4_PROGRAMADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.GRP_PAPEL4_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "GRP_PAPEL4_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.GRP_PAPEL4_PROGRAMADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? GRP_PAPEL5_PROGRAMADO
                                    {
                                        get => _inner.GRP_PAPEL5_PROGRAMADO;
                                        set
                                        {
                                            if (_inner.GRP_PAPEL5_PROGRAMADO != value)
                                            {
                                                _inner.GRP_PAPEL5_PROGRAMADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.GRP_PAPEL5_PROGRAMADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "GRP_PAPEL5_PROGRAMADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.GRP_PAPEL5_PROGRAMADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? BOL_STATUS_INTERFACE
                                    {
                                        get => _inner.BOL_STATUS_INTERFACE;
                                        set
                                        {
                                            if (_inner.BOL_STATUS_INTERFACE != value)
                                            {
                                                _inner.BOL_STATUS_INTERFACE = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_STATUS_INTERFACE) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_STATUS_INTERFACE", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_STATUS_INTERFACE, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? BOL_TIPO
                                    {
                                        get => _inner.BOL_TIPO;
                                        set
                                        {
                                            if (_inner.BOL_TIPO != value)
                                            {
                                                _inner.BOL_TIPO = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_TIPO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? BOL_FORMATO
                                    {
                                        get => _inner.BOL_FORMATO;
                                        set
                                        {
                                            if (_inner.BOL_FORMATO != value)
                                            {
                                                _inner.BOL_FORMATO = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_FORMATO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_FORMATO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_FORMATO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? BOL_GRAMATURA_PAPEIS_PROGRAMADOS
                                    {
                                        get => _inner.BOL_GRAMATURA_PAPEIS_PROGRAMADOS;
                                        set
                                        {
                                            if (_inner.BOL_GRAMATURA_PAPEIS_PROGRAMADOS != value)
                                            {
                                                _inner.BOL_GRAMATURA_PAPEIS_PROGRAMADOS = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_GRAMATURA_PAPEIS_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_GRAMATURA_PAPEIS_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_GRAMATURA_PAPEIS_PROGRAMADOS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? BOL_GRAMATURA_PAPEIS_REALIZADO
                                    {
                                        get => _inner.BOL_GRAMATURA_PAPEIS_REALIZADO;
                                        set
                                        {
                                            if (_inner.BOL_GRAMATURA_PAPEIS_REALIZADO != value)
                                            {
                                                _inner.BOL_GRAMATURA_PAPEIS_REALIZADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_GRAMATURA_PAPEIS_REALIZADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_GRAMATURA_PAPEIS_REALIZADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_GRAMATURA_PAPEIS_REALIZADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? BOL_CUSTO_PAPEIS_PROGRAMADOS
                                    {
                                        get => _inner.BOL_CUSTO_PAPEIS_PROGRAMADOS;
                                        set
                                        {
                                            if (_inner.BOL_CUSTO_PAPEIS_PROGRAMADOS != value)
                                            {
                                                _inner.BOL_CUSTO_PAPEIS_PROGRAMADOS = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_CUSTO_PAPEIS_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_CUSTO_PAPEIS_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_CUSTO_PAPEIS_PROGRAMADOS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? BOL_CUSTO_PAPEIS_REALIZADO
                                    {
                                        get => _inner.BOL_CUSTO_PAPEIS_REALIZADO;
                                        set
                                        {
                                            if (_inner.BOL_CUSTO_PAPEIS_REALIZADO != value)
                                            {
                                                _inner.BOL_CUSTO_PAPEIS_REALIZADO = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_CUSTO_PAPEIS_REALIZADO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_CUSTO_PAPEIS_REALIZADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_CUSTO_PAPEIS_REALIZADO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? BOL_GRAMATURA_RESINA_PROGRAMADOS
                                    {
                                        get => _inner.BOL_GRAMATURA_RESINA_PROGRAMADOS;
                                        set
                                        {
                                            if (_inner.BOL_GRAMATURA_RESINA_PROGRAMADOS != value)
                                            {
                                                _inner.BOL_GRAMATURA_RESINA_PROGRAMADOS = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_GRAMATURA_RESINA_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_GRAMATURA_RESINA_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_GRAMATURA_RESINA_PROGRAMADOS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? BOL_CUSTO_RESINA_PROGRAMADOS
                                    {
                                        get => _inner.BOL_CUSTO_RESINA_PROGRAMADOS;
                                        set
                                        {
                                            if (_inner.BOL_CUSTO_RESINA_PROGRAMADOS != value)
                                            {
                                                _inner.BOL_CUSTO_RESINA_PROGRAMADOS = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_CUSTO_RESINA_PROGRAMADOS) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_CUSTO_RESINA_PROGRAMADOS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_CUSTO_RESINA_PROGRAMADOS, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? BOL_REFILE_OBRIGATORIO
                                    {
                                        get => _inner.BOL_REFILE_OBRIGATORIO;
                                        set
                                        {
                                            if (_inner.BOL_REFILE_OBRIGATORIO != value)
                                            {
                                                _inner.BOL_REFILE_OBRIGATORIO = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_REFILE_OBRIGATORIO) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_REFILE_OBRIGATORIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_REFILE_OBRIGATORIO, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? BOL_OBS
                                    {
                                        get => _inner.BOL_OBS;
                                        set
                                        {
                                            if (_inner.BOL_OBS != value)
                                            {
                                                _inner.BOL_OBS = value;
                                                if ((_trackingMask & BoletimTrackingFields.BOL_OBS) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "BOL_OBS", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.BOL_OBS, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & BoletimTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & BoletimTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & BoletimTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & BoletimTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Boletim", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, BoletimOperationalFields.UserId, _trackingExecutionIdentity);
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