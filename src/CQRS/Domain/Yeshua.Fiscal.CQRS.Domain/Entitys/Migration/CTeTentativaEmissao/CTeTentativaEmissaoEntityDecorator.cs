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
                    public static class CTeTentativaEmissaoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong CTeSolicitacaoFiscalId = 1UL << 1;
            public const ulong ChaveAcesso = 1UL << 2;
            public const ulong Numero = 1UL << 3;
            public const ulong Serie = 1UL << 4;
            public const ulong Tentativa = 1UL << 5;
            public const ulong XmlAssinadoStorageKey = 1UL << 6;
            public const ulong XmlProcStorageKey = 1UL << 7;
            public const ulong XmlHash = 1UL << 8;
            public const ulong CodigoRetorno = 1UL << 9;
            public const ulong MensagemRetorno = 1UL << 10;
            public const ulong ProtocoloAutorizacao = 1UL << 11;
            public const ulong EnviadoEmUtc = 1UL << 12;
            public const ulong AutorizadoEmUtc = 1UL << 13;
            public const ulong Status = 1UL << 14;
            public const ulong TenantID = 1UL << 15;
            public const ulong Deleted = 1UL << 16;
            public const ulong Changed = 1UL << 17;
            public const ulong UserId = 1UL << 18;
        }

        public partial class CTeTentativaEmissaoDecorator : ICTeTentativaEmissaoEntity
{

                        private readonly ICTeTentativaEmissaoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public CTeTentativaEmissaoDecorator(ICTeTentativaEmissaoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public CTeTentativaEmissaoDecorator(
                            ICTeTentativaEmissaoEntity inner,
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.CTeSolicitacaoFiscalId) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "CTeSolicitacaoFiscalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.ChaveAcesso) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "ChaveAcesso", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Numero
                                    {
                                        get => _inner.Numero;
                                        set
                                        {
                                            if (_inner.Numero != value)
                                            {
                                                _inner.Numero = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.Numero) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "Numero", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Serie
                                    {
                                        get => _inner.Serie;
                                        set
                                        {
                                            if (_inner.Serie != value)
                                            {
                                                _inner.Serie = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.Serie) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "Serie", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Tentativa
                                    {
                                        get => _inner.Tentativa;
                                        set
                                        {
                                            if (_inner.Tentativa != value)
                                            {
                                                _inner.Tentativa = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.Tentativa) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "Tentativa", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string XmlAssinadoStorageKey
                                    {
                                        get => _inner.XmlAssinadoStorageKey;
                                        set
                                        {
                                            if (_inner.XmlAssinadoStorageKey != value)
                                            {
                                                _inner.XmlAssinadoStorageKey = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.XmlAssinadoStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "XmlAssinadoStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string XmlProcStorageKey
                                    {
                                        get => _inner.XmlProcStorageKey;
                                        set
                                        {
                                            if (_inner.XmlProcStorageKey != value)
                                            {
                                                _inner.XmlProcStorageKey = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.XmlProcStorageKey) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "XmlProcStorageKey", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string XmlHash
                                    {
                                        get => _inner.XmlHash;
                                        set
                                        {
                                            if (_inner.XmlHash != value)
                                            {
                                                _inner.XmlHash = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.XmlHash) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "XmlHash", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.CodigoRetorno) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "CodigoRetorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.MensagemRetorno) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "MensagemRetorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ProtocoloAutorizacao
                                    {
                                        get => _inner.ProtocoloAutorizacao;
                                        set
                                        {
                                            if (_inner.ProtocoloAutorizacao != value)
                                            {
                                                _inner.ProtocoloAutorizacao = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.ProtocoloAutorizacao) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "ProtocoloAutorizacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? EnviadoEmUtc
                                    {
                                        get => _inner.EnviadoEmUtc;
                                        set
                                        {
                                            if (_inner.EnviadoEmUtc != value)
                                            {
                                                _inner.EnviadoEmUtc = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.EnviadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "EnviadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? AutorizadoEmUtc
                                    {
                                        get => _inner.AutorizadoEmUtc;
                                        set
                                        {
                                            if (_inner.AutorizadoEmUtc != value)
                                            {
                                                _inner.AutorizadoEmUtc = value;
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.AutorizadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "AutorizadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & CTeTentativaEmissaoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("CTeTentativaEmissao", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration