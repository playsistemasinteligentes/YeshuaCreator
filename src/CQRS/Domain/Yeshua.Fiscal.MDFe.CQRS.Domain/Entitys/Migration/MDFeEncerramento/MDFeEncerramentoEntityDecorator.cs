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
                    public static class MDFeEncerramentoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong MDFeId = 1UL << 1;
            public const ulong ChaveAcesso = 1UL << 2;
            public const ulong UfCarregamento = 1UL << 3;
            public const ulong UfDescarregamento = 1UL << 4;
            public const ulong PlacaVeiculo = 1UL << 5;
            public const ulong SolicitadoEm = 1UL << 6;
            public const ulong AutorizadoEm = 1UL << 7;
            public const ulong Protocolo = 1UL << 8;
            public const ulong CodigoRetorno = 1UL << 9;
            public const ulong MensagemRetorno = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
        }

        public partial class MDFeEncerramentoDecorator : IMDFeEncerramentoEntity
{

                        private readonly IMDFeEncerramentoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MDFeEncerramentoDecorator(IMDFeEncerramentoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MDFeEncerramentoDecorator(
                            IMDFeEncerramentoEntity inner,
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
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MDFeId
                                    {
                                        get => _inner.MDFeId;
                                        set
                                        {
                                            if (_inner.MDFeId != value)
                                            {
                                                _inner.MDFeId = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.MDFeId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "MDFeId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ChaveAcesso
                                    {
                                        get => _inner.ChaveAcesso;
                                        set
                                        {
                                            if (_inner.ChaveAcesso != value)
                                            {
                                                _inner.ChaveAcesso = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UfCarregamento
                                    {
                                        get => _inner.UfCarregamento;
                                        set
                                        {
                                            if (_inner.UfCarregamento != value)
                                            {
                                                _inner.UfCarregamento = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.UfCarregamento) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "UfCarregamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string UfDescarregamento
                                    {
                                        get => _inner.UfDescarregamento;
                                        set
                                        {
                                            if (_inner.UfDescarregamento != value)
                                            {
                                                _inner.UfDescarregamento = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.UfDescarregamento) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "UfDescarregamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.PlacaVeiculo) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "PlacaVeiculo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime SolicitadoEm
                                    {
                                        get => _inner.SolicitadoEm;
                                        set
                                        {
                                            if (_inner.SolicitadoEm != value)
                                            {
                                                _inner.SolicitadoEm = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.SolicitadoEm) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "SolicitadoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? AutorizadoEm
                                    {
                                        get => _inner.AutorizadoEm;
                                        set
                                        {
                                            if (_inner.AutorizadoEm != value)
                                            {
                                                _inner.AutorizadoEm = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.AutorizadoEm) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "AutorizadoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Protocolo
                                    {
                                        get => _inner.Protocolo;
                                        set
                                        {
                                            if (_inner.Protocolo != value)
                                            {
                                                _inner.Protocolo = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.Protocolo) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "Protocolo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CodigoRetorno
                                    {
                                        get => _inner.CodigoRetorno;
                                        set
                                        {
                                            if (_inner.CodigoRetorno != value)
                                            {
                                                _inner.CodigoRetorno = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.CodigoRetorno) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "CodigoRetorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MensagemRetorno
                                    {
                                        get => _inner.MensagemRetorno;
                                        set
                                        {
                                            if (_inner.MensagemRetorno != value)
                                            {
                                                _inner.MensagemRetorno = value;
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.MensagemRetorno) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "MensagemRetorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeEncerramentoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MDFeEncerramento", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration