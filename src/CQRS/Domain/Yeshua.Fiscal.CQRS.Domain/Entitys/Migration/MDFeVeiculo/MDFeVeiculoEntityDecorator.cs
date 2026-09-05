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
                    public static class MDFeVeiculoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MDFeSolicitacaoFiscalId = 1UL << 1;
            public const ulong Placa = 1UL << 2;
            public const ulong Renavam = 1UL << 3;
            public const ulong Tara = 1UL << 4;
            public const ulong CapacidadeKg = 1UL << 5;
            public const ulong CapacidadeM3 = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
        }

        public partial class MDFeVeiculoDecorator : IMDFeVeiculoEntity
{

                        private readonly IMDFeVeiculoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MDFeVeiculoDecorator(IMDFeVeiculoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MDFeVeiculoDecorator(
                            IMDFeVeiculoEntity inner,
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
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MDFeSolicitacaoFiscalId
                                    {
                                        get => _inner.MDFeSolicitacaoFiscalId;
                                        set
                                        {
                                            if (_inner.MDFeSolicitacaoFiscalId != value)
                                            {
                                                _inner.MDFeSolicitacaoFiscalId = value;
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.MDFeSolicitacaoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "MDFeSolicitacaoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Placa
                                    {
                                        get => _inner.Placa;
                                        set
                                        {
                                            if (_inner.Placa != value)
                                            {
                                                _inner.Placa = value;
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.Placa) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "Placa", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Renavam
                                    {
                                        get => _inner.Renavam;
                                        set
                                        {
                                            if (_inner.Renavam != value)
                                            {
                                                _inner.Renavam = value;
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.Renavam) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "Renavam", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? Tara
                                    {
                                        get => _inner.Tara;
                                        set
                                        {
                                            if (_inner.Tara != value)
                                            {
                                                _inner.Tara = value;
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.Tara) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "Tara", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CapacidadeKg
                                    {
                                        get => _inner.CapacidadeKg;
                                        set
                                        {
                                            if (_inner.CapacidadeKg != value)
                                            {
                                                _inner.CapacidadeKg = value;
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.CapacidadeKg) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "CapacidadeKg", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CapacidadeM3
                                    {
                                        get => _inner.CapacidadeM3;
                                        set
                                        {
                                            if (_inner.CapacidadeM3 != value)
                                            {
                                                _inner.CapacidadeM3 = value;
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.CapacidadeM3) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "CapacidadeM3", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeVeiculoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeVeiculo", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration