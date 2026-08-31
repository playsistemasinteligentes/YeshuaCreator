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
                    public static class ExperienciaPlanejamentoTransporteTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Tipo = 1UL << 1;
            public const ulong Referencia = 1UL << 2;
            public const ulong PedidoId = 1UL << 3;
            public const ulong ClienteId = 1UL << 4;
            public const ulong Municipio = 1UL << 5;
            public const ulong Regiao = 1UL << 6;
            public const ulong RotaId = 1UL << 7;
            public const ulong Peso = 1UL << 8;
            public const ulong Volume = 1UL << 9;
            public const ulong Observacao = 1UL << 10;
            public const ulong CriadoEm = 1UL << 11;
            public const ulong CriadoPor = 1UL << 12;
            public const ulong TenantID = 1UL << 13;
            public const ulong Deleted = 1UL << 14;
            public const ulong Changed = 1UL << 15;
            public const ulong UserId = 1UL << 16;
        }

        public partial class ExperienciaPlanejamentoTransporteDecorator : IExperienciaPlanejamentoTransporteEntity
{

                        private readonly IExperienciaPlanejamentoTransporteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ExperienciaPlanejamentoTransporteDecorator(IExperienciaPlanejamentoTransporteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ExperienciaPlanejamentoTransporteDecorator(
                            IExperienciaPlanejamentoTransporteEntity inner,
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
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Tipo
                                    {
                                        get => _inner.Tipo;
                                        set
                                        {
                                            if (_inner.Tipo != value)
                                            {
                                                _inner.Tipo = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Tipo) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Tipo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Referencia
                                    {
                                        get => _inner.Referencia;
                                        set
                                        {
                                            if (_inner.Referencia != value)
                                            {
                                                _inner.Referencia = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Referencia) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Referencia", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PedidoId
                                    {
                                        get => _inner.PedidoId;
                                        set
                                        {
                                            if (_inner.PedidoId != value)
                                            {
                                                _inner.PedidoId = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.PedidoId) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "PedidoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ClienteId
                                    {
                                        get => _inner.ClienteId;
                                        set
                                        {
                                            if (_inner.ClienteId != value)
                                            {
                                                _inner.ClienteId = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.ClienteId) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "ClienteId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Municipio
                                    {
                                        get => _inner.Municipio;
                                        set
                                        {
                                            if (_inner.Municipio != value)
                                            {
                                                _inner.Municipio = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Municipio) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Municipio", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Regiao
                                    {
                                        get => _inner.Regiao;
                                        set
                                        {
                                            if (_inner.Regiao != value)
                                            {
                                                _inner.Regiao = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Regiao) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Regiao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string RotaId
                                    {
                                        get => _inner.RotaId;
                                        set
                                        {
                                            if (_inner.RotaId != value)
                                            {
                                                _inner.RotaId = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.RotaId) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "RotaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? Peso
                                    {
                                        get => _inner.Peso;
                                        set
                                        {
                                            if (_inner.Peso != value)
                                            {
                                                _inner.Peso = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Peso) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Peso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? Volume
                                    {
                                        get => _inner.Volume;
                                        set
                                        {
                                            if (_inner.Volume != value)
                                            {
                                                _inner.Volume = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Volume) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Volume", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Observacao
                                    {
                                        get => _inner.Observacao;
                                        set
                                        {
                                            if (_inner.Observacao != value)
                                            {
                                                _inner.Observacao = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Observacao) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Observacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime CriadoEm
                                    {
                                        get => _inner.CriadoEm;
                                        set
                                        {
                                            if (_inner.CriadoEm != value)
                                            {
                                                _inner.CriadoEm = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.CriadoEm) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "CriadoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CriadoPor
                                    {
                                        get => _inner.CriadoPor;
                                        set
                                        {
                                            if (_inner.CriadoPor != value)
                                            {
                                                _inner.CriadoPor = value;
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.CriadoPor) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "CriadoPor", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ExperienciaPlanejamentoTransporteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ExperienciaPlanejamentoTransporte", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration