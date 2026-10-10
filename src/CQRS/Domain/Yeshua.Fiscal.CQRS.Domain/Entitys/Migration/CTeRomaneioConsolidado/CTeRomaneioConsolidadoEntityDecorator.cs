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
                    public static class CTeRomaneioConsolidadoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong EntradaOficialId = 1UL << 1;
            public const ulong CorrelationId = 1UL << 2;
            public const ulong RomaneioId = 1UL << 3;
            public const ulong CargaId = 1UL << 4;
            public const ulong ConsolidadoEmUtc = 1UL << 5;
            public const ulong UFInicio = 1UL << 6;
            public const ulong UFFim = 1UL << 7;
            public const ulong MunicipioInicioCodigoIbge = 1UL << 8;
            public const ulong MunicipioFimCodigoIbge = 1UL << 9;
            public const ulong EmitenteDocumento = 1UL << 10;
            public const ulong TomadorDocumento = 1UL << 11;
            public const ulong RotaSnapshotJson = 1UL << 12;
            public const ulong CargaSnapshotJson = 1UL << 13;
            public const ulong PreferenciasFiscaisJson = 1UL << 14;
            public const ulong Status = 1UL << 15;
            public const ulong TenantID = 1UL << 16;
            public const ulong Deleted = 1UL << 17;
            public const ulong Changed = 1UL << 18;
            public const ulong UserId = 1UL << 19;
            public const ulong OperationalEntityId = 1UL << 20;
        }

        public static class CTeRomaneioConsolidadoOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EntradaOficialId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CorrelationId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RomaneioId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CargaId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ConsolidadoEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UFInicio = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UFFim = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MunicipioInicioCodigoIbge = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MunicipioFimCodigoIbge = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EmitenteDocumento = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification TomadorDocumento = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification RotaSnapshotJson = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CargaSnapshotJson = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification PreferenciasFiscaisJson = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class CTeRomaneioConsolidadoDecorator : ICTeRomaneioConsolidadoEntity
{

                        private readonly ICTeRomaneioConsolidadoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CTeRomaneioConsolidadoDecorator(ICTeRomaneioConsolidadoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CTeRomaneioConsolidadoDecorator(
                            ICTeRomaneioConsolidadoEntity inner,
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
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int EntradaOficialId
                                    {
                                        get => _inner.EntradaOficialId;
                                        set
                                        {
                                            if (_inner.EntradaOficialId != value)
                                            {
                                                _inner.EntradaOficialId = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.EntradaOficialId) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "EntradaOficialId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.EntradaOficialId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.CorrelationId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string RomaneioId
                                    {
                                        get => _inner.RomaneioId;
                                        set
                                        {
                                            if (_inner.RomaneioId != value)
                                            {
                                                _inner.RomaneioId = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.RomaneioId) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "RomaneioId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.RomaneioId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CargaId
                                    {
                                        get => _inner.CargaId;
                                        set
                                        {
                                            if (_inner.CargaId != value)
                                            {
                                                _inner.CargaId = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.CargaId) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "CargaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.CargaId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime ConsolidadoEmUtc
                                    {
                                        get => _inner.ConsolidadoEmUtc;
                                        set
                                        {
                                            if (_inner.ConsolidadoEmUtc != value)
                                            {
                                                _inner.ConsolidadoEmUtc = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.ConsolidadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "ConsolidadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.ConsolidadoEmUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string UFInicio
                                    {
                                        get => _inner.UFInicio;
                                        set
                                        {
                                            if (_inner.UFInicio != value)
                                            {
                                                _inner.UFInicio = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.UFInicio) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "UFInicio", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.UFInicio, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string UFFim
                                    {
                                        get => _inner.UFFim;
                                        set
                                        {
                                            if (_inner.UFFim != value)
                                            {
                                                _inner.UFFim = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.UFFim) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "UFFim", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.UFFim, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MunicipioInicioCodigoIbge
                                    {
                                        get => _inner.MunicipioInicioCodigoIbge;
                                        set
                                        {
                                            if (_inner.MunicipioInicioCodigoIbge != value)
                                            {
                                                _inner.MunicipioInicioCodigoIbge = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.MunicipioInicioCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "MunicipioInicioCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.MunicipioInicioCodigoIbge, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MunicipioFimCodigoIbge
                                    {
                                        get => _inner.MunicipioFimCodigoIbge;
                                        set
                                        {
                                            if (_inner.MunicipioFimCodigoIbge != value)
                                            {
                                                _inner.MunicipioFimCodigoIbge = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.MunicipioFimCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "MunicipioFimCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.MunicipioFimCodigoIbge, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? EmitenteDocumento
                                    {
                                        get => _inner.EmitenteDocumento;
                                        set
                                        {
                                            if (_inner.EmitenteDocumento != value)
                                            {
                                                _inner.EmitenteDocumento = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.EmitenteDocumento) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "EmitenteDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.EmitenteDocumento, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? TomadorDocumento
                                    {
                                        get => _inner.TomadorDocumento;
                                        set
                                        {
                                            if (_inner.TomadorDocumento != value)
                                            {
                                                _inner.TomadorDocumento = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.TomadorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "TomadorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.TomadorDocumento, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? RotaSnapshotJson
                                    {
                                        get => _inner.RotaSnapshotJson;
                                        set
                                        {
                                            if (_inner.RotaSnapshotJson != value)
                                            {
                                                _inner.RotaSnapshotJson = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.RotaSnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "RotaSnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.RotaSnapshotJson, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CargaSnapshotJson
                                    {
                                        get => _inner.CargaSnapshotJson;
                                        set
                                        {
                                            if (_inner.CargaSnapshotJson != value)
                                            {
                                                _inner.CargaSnapshotJson = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.CargaSnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "CargaSnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.CargaSnapshotJson, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? PreferenciasFiscaisJson
                                    {
                                        get => _inner.PreferenciasFiscaisJson;
                                        set
                                        {
                                            if (_inner.PreferenciasFiscaisJson != value)
                                            {
                                                _inner.PreferenciasFiscaisJson = value;
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.PreferenciasFiscaisJson) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "PreferenciasFiscaisJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.PreferenciasFiscaisJson, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.Status, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & CTeRomaneioConsolidadoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CTeRomaneioConsolidado", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, CTeRomaneioConsolidadoOperationalFields.UserId, _trackingExecutionIdentity);
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