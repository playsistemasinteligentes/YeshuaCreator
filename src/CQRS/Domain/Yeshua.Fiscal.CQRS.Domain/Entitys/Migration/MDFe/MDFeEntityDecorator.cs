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
                    public static class MDFeTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ChaveAcesso = 1UL << 1;
            public const ulong Serie = 1UL << 2;
            public const ulong Numero = 1UL << 3;
            public const ulong UfCarregamento = 1UL << 4;
            public const ulong UfDescarregamento = 1UL << 5;
            public const ulong PlacaVeiculo = 1UL << 6;
            public const ulong EmitidoEm = 1UL << 7;
            public const ulong AutorizadoEm = 1UL << 8;
            public const ulong IniciadoEm = 1UL << 9;
            public const ulong EncerradoEm = 1UL << 10;
            public const ulong CanceladoEm = 1UL << 11;
            public const ulong Situacao = 1UL << 12;
            public const ulong TenantID = 1UL << 13;
            public const ulong Deleted = 1UL << 14;
            public const ulong Changed = 1UL << 15;
            public const ulong UserId = 1UL << 16;
        }

        public partial class MDFeDecorator : IMDFeEntity
{

                        private readonly IMDFeEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MDFeDecorator(IMDFeEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MDFeDecorator(
                            IMDFeEntity inner,
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
                                                if ((_trackingMask & MDFeTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Serie
                                    {
                                        get => _inner.Serie;
                                        set
                                        {
                                            if (_inner.Serie != value)
                                            {
                                                _inner.Serie = value;
                                                if ((_trackingMask & MDFeTrackingFields.Serie) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "Serie", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Numero
                                    {
                                        get => _inner.Numero;
                                        set
                                        {
                                            if (_inner.Numero != value)
                                            {
                                                _inner.Numero = value;
                                                if ((_trackingMask & MDFeTrackingFields.Numero) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "Numero", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.UfCarregamento) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "UfCarregamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.UfDescarregamento) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "UfDescarregamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.PlacaVeiculo) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "PlacaVeiculo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime EmitidoEm
                                    {
                                        get => _inner.EmitidoEm;
                                        set
                                        {
                                            if (_inner.EmitidoEm != value)
                                            {
                                                _inner.EmitidoEm = value;
                                                if ((_trackingMask & MDFeTrackingFields.EmitidoEm) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "EmitidoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.AutorizadoEm) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "AutorizadoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? IniciadoEm
                                    {
                                        get => _inner.IniciadoEm;
                                        set
                                        {
                                            if (_inner.IniciadoEm != value)
                                            {
                                                _inner.IniciadoEm = value;
                                                if ((_trackingMask & MDFeTrackingFields.IniciadoEm) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "IniciadoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? EncerradoEm
                                    {
                                        get => _inner.EncerradoEm;
                                        set
                                        {
                                            if (_inner.EncerradoEm != value)
                                            {
                                                _inner.EncerradoEm = value;
                                                if ((_trackingMask & MDFeTrackingFields.EncerradoEm) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "EncerradoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? CanceladoEm
                                    {
                                        get => _inner.CanceladoEm;
                                        set
                                        {
                                            if (_inner.CanceladoEm != value)
                                            {
                                                _inner.CanceladoEm = value;
                                                if ((_trackingMask & MDFeTrackingFields.CanceladoEm) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "CanceladoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Situacao
                                    {
                                        get => _inner.Situacao;
                                        set
                                        {
                                            if (_inner.Situacao != value)
                                            {
                                                _inner.Situacao = value;
                                                if ((_trackingMask & MDFeTrackingFields.Situacao) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "Situacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MDFeTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MDFe", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration