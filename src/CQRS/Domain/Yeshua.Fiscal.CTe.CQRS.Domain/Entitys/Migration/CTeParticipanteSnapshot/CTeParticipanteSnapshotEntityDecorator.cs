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
                    public static class CTeParticipanteSnapshotTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CTeSolicitacaoFiscalId = 1UL << 1;
            public const ulong Papel = 1UL << 2;
            public const ulong Documento = 1UL << 3;
            public const ulong Nome = 1UL << 4;
            public const ulong InscricaoEstadual = 1UL << 5;
            public const ulong UF = 1UL << 6;
            public const ulong MunicipioCodigoIbge = 1UL << 7;
            public const ulong EnderecoJson = 1UL << 8;
            public const ulong TenantID = 1UL << 9;
            public const ulong Deleted = 1UL << 10;
            public const ulong Changed = 1UL << 11;
            public const ulong UserId = 1UL << 12;
        }

        public partial class CTeParticipanteSnapshotDecorator : ICTeParticipanteSnapshotEntity
{

                        private readonly ICTeParticipanteSnapshotEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CTeParticipanteSnapshotDecorator(ICTeParticipanteSnapshotEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CTeParticipanteSnapshotDecorator(
                            ICTeParticipanteSnapshotEntity inner,
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
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int CTeSolicitacaoFiscalId
                                    {
                                        get => _inner.CTeSolicitacaoFiscalId;
                                        set
                                        {
                                            if (_inner.CTeSolicitacaoFiscalId != value)
                                            {
                                                _inner.CTeSolicitacaoFiscalId = value;
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.CTeSolicitacaoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "CTeSolicitacaoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Papel
                                    {
                                        get => _inner.Papel;
                                        set
                                        {
                                            if (_inner.Papel != value)
                                            {
                                                _inner.Papel = value;
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.Papel) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "Papel", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Documento
                                    {
                                        get => _inner.Documento;
                                        set
                                        {
                                            if (_inner.Documento != value)
                                            {
                                                _inner.Documento = value;
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.Documento) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "Documento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Nome
                                    {
                                        get => _inner.Nome;
                                        set
                                        {
                                            if (_inner.Nome != value)
                                            {
                                                _inner.Nome = value;
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.Nome) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "Nome", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string InscricaoEstadual
                                    {
                                        get => _inner.InscricaoEstadual;
                                        set
                                        {
                                            if (_inner.InscricaoEstadual != value)
                                            {
                                                _inner.InscricaoEstadual = value;
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.InscricaoEstadual) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "InscricaoEstadual", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UF
                                    {
                                        get => _inner.UF;
                                        set
                                        {
                                            if (_inner.UF != value)
                                            {
                                                _inner.UF = value;
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.UF) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "UF", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MunicipioCodigoIbge
                                    {
                                        get => _inner.MunicipioCodigoIbge;
                                        set
                                        {
                                            if (_inner.MunicipioCodigoIbge != value)
                                            {
                                                _inner.MunicipioCodigoIbge = value;
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.MunicipioCodigoIbge) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "MunicipioCodigoIbge", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string EnderecoJson
                                    {
                                        get => _inner.EnderecoJson;
                                        set
                                        {
                                            if (_inner.EnderecoJson != value)
                                            {
                                                _inner.EnderecoJson = value;
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.EnderecoJson) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "EnderecoJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeParticipanteSnapshotTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CTeParticipanteSnapshot", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration