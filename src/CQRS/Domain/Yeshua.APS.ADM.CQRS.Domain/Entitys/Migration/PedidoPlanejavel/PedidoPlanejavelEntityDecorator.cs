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
                    public static class PedidoPlanejavelTrackingFields
        {
            public const ulong PedidoId = 1UL << 0;
            public const ulong ClienteId = 1UL << 1;
            public const ulong ClienteNome = 1UL << 2;
            public const ulong Estado = 1UL << 3;
            public const ulong Municipio = 1UL << 4;
            public const ulong Regiao = 1UL << 5;
            public const ulong Bairro = 1UL << 6;
            public const ulong RotaId = 1UL << 7;
            public const ulong EmbarqueAlvo = 1UL << 8;
            public const ulong DataEntregaDe = 1UL << 9;
            public const ulong DataEntregaAte = 1UL << 10;
            public const ulong Peso = 1UL << 11;
            public const ulong Volume = 1UL << 12;
            public const ulong SaldoAExpedir = 1UL << 13;
            public const ulong Status = 1UL << 14;
            public const ulong CargaAtualId = 1UL << 15;
            public const ulong VersaoPlanejamento = 1UL << 16;
            public const ulong AlertasResumo = 1UL << 17;
        }

        public static class PedidoPlanejavelOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification PedidoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ClienteId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ClienteNome = Dominio.Operational.OperationalDataClassification.Confidential;
            public const Dominio.Operational.OperationalDataClassification Estado = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Municipio = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Regiao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Bairro = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RotaId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EmbarqueAlvo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DataEntregaDe = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DataEntregaAte = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Peso = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Volume = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SaldoAExpedir = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CargaAtualId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VersaoPlanejamento = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AlertasResumo = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class PedidoPlanejavelDecorator : IPedidoPlanejavelEntity
{

                        private readonly IPedidoPlanejavelEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PedidoPlanejavelDecorator(IPedidoPlanejavelEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PedidoPlanejavelDecorator(
                            IPedidoPlanejavelEntity inner,
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
                                    public string PedidoId
                                    {
                                        get => _inner.PedidoId;
                                        set
                                        {
                                            if (_inner.PedidoId != value)
                                            {
                                                _inner.PedidoId = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.PedidoId) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "PedidoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.PedidoId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.ClienteId) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "ClienteId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.ClienteId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string ClienteNome
                                    {
                                        get => _inner.ClienteNome;
                                        set
                                        {
                                            if (_inner.ClienteNome != value)
                                            {
                                                _inner.ClienteNome = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.ClienteNome) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "ClienteNome", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.ClienteNome, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Estado
                                    {
                                        get => _inner.Estado;
                                        set
                                        {
                                            if (_inner.Estado != value)
                                            {
                                                _inner.Estado = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.Estado) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "Estado", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.Estado, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.Municipio) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "Municipio", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.Municipio, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Regiao
                                    {
                                        get => _inner.Regiao;
                                        set
                                        {
                                            if (_inner.Regiao != value)
                                            {
                                                _inner.Regiao = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.Regiao) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "Regiao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.Regiao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Bairro
                                    {
                                        get => _inner.Bairro;
                                        set
                                        {
                                            if (_inner.Bairro != value)
                                            {
                                                _inner.Bairro = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.Bairro) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "Bairro", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.Bairro, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? RotaId
                                    {
                                        get => _inner.RotaId;
                                        set
                                        {
                                            if (_inner.RotaId != value)
                                            {
                                                _inner.RotaId = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.RotaId) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "RotaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.RotaId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? EmbarqueAlvo
                                    {
                                        get => _inner.EmbarqueAlvo;
                                        set
                                        {
                                            if (_inner.EmbarqueAlvo != value)
                                            {
                                                _inner.EmbarqueAlvo = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.EmbarqueAlvo) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "EmbarqueAlvo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.EmbarqueAlvo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? DataEntregaDe
                                    {
                                        get => _inner.DataEntregaDe;
                                        set
                                        {
                                            if (_inner.DataEntregaDe != value)
                                            {
                                                _inner.DataEntregaDe = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.DataEntregaDe) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "DataEntregaDe", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.DataEntregaDe, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? DataEntregaAte
                                    {
                                        get => _inner.DataEntregaAte;
                                        set
                                        {
                                            if (_inner.DataEntregaAte != value)
                                            {
                                                _inner.DataEntregaAte = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.DataEntregaAte) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "DataEntregaAte", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.DataEntregaAte, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.Peso) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "Peso", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.Peso, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.Volume) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "Volume", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.Volume, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public Decimal? SaldoAExpedir
                                    {
                                        get => _inner.SaldoAExpedir;
                                        set
                                        {
                                            if (_inner.SaldoAExpedir != value)
                                            {
                                                _inner.SaldoAExpedir = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.SaldoAExpedir) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "SaldoAExpedir", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.SaldoAExpedir, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.Status, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? CargaAtualId
                                    {
                                        get => _inner.CargaAtualId;
                                        set
                                        {
                                            if (_inner.CargaAtualId != value)
                                            {
                                                _inner.CargaAtualId = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.CargaAtualId) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "CargaAtualId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.CargaAtualId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? VersaoPlanejamento
                                    {
                                        get => _inner.VersaoPlanejamento;
                                        set
                                        {
                                            if (_inner.VersaoPlanejamento != value)
                                            {
                                                _inner.VersaoPlanejamento = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.VersaoPlanejamento) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "VersaoPlanejamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.VersaoPlanejamento, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? AlertasResumo
                                    {
                                        get => _inner.AlertasResumo;
                                        set
                                        {
                                            if (_inner.AlertasResumo != value)
                                            {
                                                _inner.AlertasResumo = value;
                                                if ((_trackingMask & PedidoPlanejavelTrackingFields.AlertasResumo) != 0UL)
                                                    _logger.DomainValueChanged("PedidoPlanejavel", "AlertasResumo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, PedidoPlanejavelOperationalFields.AlertasResumo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration