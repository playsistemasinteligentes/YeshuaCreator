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
                    public static class MDFeSolicitacaoFiscalTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CorrelationId = 1UL << 1;
            public const ulong CargaId = 1UL << 2;
            public const ulong Ambiente = 1UL << 3;
            public const ulong UFCarregamento = 1UL << 4;
            public const ulong UFDescarregamento = 1UL << 5;
            public const ulong PlacaVeiculo = 1UL << 6;
            public const ulong CondutorDocumento = 1UL << 7;
            public const ulong DocumentosOriginariosJson = 1UL << 8;
            public const ulong TransporteSnapshotJson = 1UL << 9;
            public const ulong Status = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
        }

        public partial class MDFeSolicitacaoFiscalDecorator : IMDFeSolicitacaoFiscalEntity
{

                        private readonly IMDFeSolicitacaoFiscalEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MDFeSolicitacaoFiscalDecorator(IMDFeSolicitacaoFiscalEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MDFeSolicitacaoFiscalDecorator(
                            IMDFeSolicitacaoFiscalEntity inner,
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
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.CorrelationId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "CorrelationId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CargaId
                                    {
                                        get => _inner.CargaId;
                                        set
                                        {
                                            if (_inner.CargaId != value)
                                            {
                                                _inner.CargaId = value;
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.CargaId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "CargaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Ambiente
                                    {
                                        get => _inner.Ambiente;
                                        set
                                        {
                                            if (_inner.Ambiente != value)
                                            {
                                                _inner.Ambiente = value;
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.Ambiente) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "Ambiente", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UFCarregamento
                                    {
                                        get => _inner.UFCarregamento;
                                        set
                                        {
                                            if (_inner.UFCarregamento != value)
                                            {
                                                _inner.UFCarregamento = value;
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.UFCarregamento) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "UFCarregamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UFDescarregamento
                                    {
                                        get => _inner.UFDescarregamento;
                                        set
                                        {
                                            if (_inner.UFDescarregamento != value)
                                            {
                                                _inner.UFDescarregamento = value;
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.UFDescarregamento) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "UFDescarregamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PlacaVeiculo
                                    {
                                        get => _inner.PlacaVeiculo;
                                        set
                                        {
                                            if (_inner.PlacaVeiculo != value)
                                            {
                                                _inner.PlacaVeiculo = value;
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.PlacaVeiculo) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "PlacaVeiculo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CondutorDocumento
                                    {
                                        get => _inner.CondutorDocumento;
                                        set
                                        {
                                            if (_inner.CondutorDocumento != value)
                                            {
                                                _inner.CondutorDocumento = value;
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.CondutorDocumento) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "CondutorDocumento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DocumentosOriginariosJson
                                    {
                                        get => _inner.DocumentosOriginariosJson;
                                        set
                                        {
                                            if (_inner.DocumentosOriginariosJson != value)
                                            {
                                                _inner.DocumentosOriginariosJson = value;
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.DocumentosOriginariosJson) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "DocumentosOriginariosJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TransporteSnapshotJson
                                    {
                                        get => _inner.TransporteSnapshotJson;
                                        set
                                        {
                                            if (_inner.TransporteSnapshotJson != value)
                                            {
                                                _inner.TransporteSnapshotJson = value;
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.TransporteSnapshotJson) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "TransporteSnapshotJson", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeSolicitacaoFiscalTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeSolicitacaoFiscal", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration