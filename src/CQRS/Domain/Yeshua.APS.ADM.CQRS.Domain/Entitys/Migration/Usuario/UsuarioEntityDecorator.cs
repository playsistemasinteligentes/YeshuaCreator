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
                    public static class UsuarioTrackingFields
        {
            public const ulong USE_ID = 1UL << 0;
            public const ulong USE_NOME = 1UL << 1;
            public const ulong USE_EMAIL = 1UL << 2;
            public const ulong USE_SENHA = 1UL << 3;
            public const ulong TURM_ID = 1UL << 4;
            public const ulong USE_ATIVO = 1UL << 5;
            public const ulong USE_CODERP = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
        }

        public partial class UsuarioDecorator : IUsuarioEntity
{

                        private readonly IUsuarioEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public UsuarioDecorator(IUsuarioEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public UsuarioDecorator(
                            IUsuarioEntity inner,
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
                                    public int USE_ID
                                    {
                                        get => _inner.USE_ID;
                                        set
                                        {
                                            if (_inner.USE_ID != value)
                                            {
                                                _inner.USE_ID = value;
                                                if ((_trackingMask & UsuarioTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string USE_NOME
                                    {
                                        get => _inner.USE_NOME;
                                        set
                                        {
                                            if (_inner.USE_NOME != value)
                                            {
                                                _inner.USE_NOME = value;
                                                if ((_trackingMask & UsuarioTrackingFields.USE_NOME) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "USE_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string USE_EMAIL
                                    {
                                        get => _inner.USE_EMAIL;
                                        set
                                        {
                                            if (_inner.USE_EMAIL != value)
                                            {
                                                _inner.USE_EMAIL = value;
                                                if ((_trackingMask & UsuarioTrackingFields.USE_EMAIL) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "USE_EMAIL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string USE_SENHA
                                    {
                                        get => _inner.USE_SENHA;
                                        set
                                        {
                                            if (_inner.USE_SENHA != value)
                                            {
                                                _inner.USE_SENHA = value;
                                                if ((_trackingMask & UsuarioTrackingFields.USE_SENHA) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "USE_SENHA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TURM_ID
                                    {
                                        get => _inner.TURM_ID;
                                        set
                                        {
                                            if (_inner.TURM_ID != value)
                                            {
                                                _inner.TURM_ID = value;
                                                if ((_trackingMask & UsuarioTrackingFields.TURM_ID) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "TURM_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int USE_ATIVO
                                    {
                                        get => _inner.USE_ATIVO;
                                        set
                                        {
                                            if (_inner.USE_ATIVO != value)
                                            {
                                                _inner.USE_ATIVO = value;
                                                if ((_trackingMask & UsuarioTrackingFields.USE_ATIVO) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "USE_ATIVO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string USE_CODERP
                                    {
                                        get => _inner.USE_CODERP;
                                        set
                                        {
                                            if (_inner.USE_CODERP != value)
                                            {
                                                _inner.USE_CODERP = value;
                                                if ((_trackingMask & UsuarioTrackingFields.USE_CODERP) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "USE_CODERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & UsuarioTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & UsuarioTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & UsuarioTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & UsuarioTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Usuario", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration