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
                    public static class ColaboradorTrackingFields
        {
            public const ulong COL_CPF = 1UL << 0;
            public const ulong COL_NOME = 1UL << 1;
            public const ulong COL_NASCIMENTO = 1UL << 2;
            public const ulong COL_EMAIL = 1UL << 3;
            public const ulong COL_MATRICULA = 1UL << 4;
            public const ulong TURM_id = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class ColaboradorDecorator : IColaboradorEntity
{

                        private readonly IColaboradorEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ColaboradorDecorator(IColaboradorEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ColaboradorDecorator(
                            IColaboradorEntity inner,
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
                                    public string COL_CPF
                                    {
                                        get => _inner.COL_CPF;
                                        set
                                        {
                                            if (_inner.COL_CPF != value)
                                            {
                                                _inner.COL_CPF = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_CPF) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_CPF", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string COL_NOME
                                    {
                                        get => _inner.COL_NOME;
                                        set
                                        {
                                            if (_inner.COL_NOME != value)
                                            {
                                                _inner.COL_NOME = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_NOME) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime COL_NASCIMENTO
                                    {
                                        get => _inner.COL_NASCIMENTO;
                                        set
                                        {
                                            if (_inner.COL_NASCIMENTO != value)
                                            {
                                                _inner.COL_NASCIMENTO = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_NASCIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_NASCIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string COL_EMAIL
                                    {
                                        get => _inner.COL_EMAIL;
                                        set
                                        {
                                            if (_inner.COL_EMAIL != value)
                                            {
                                                _inner.COL_EMAIL = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_EMAIL) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_EMAIL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string COL_MATRICULA
                                    {
                                        get => _inner.COL_MATRICULA;
                                        set
                                        {
                                            if (_inner.COL_MATRICULA != value)
                                            {
                                                _inner.COL_MATRICULA = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.COL_MATRICULA) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "COL_MATRICULA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TURM_id
                                    {
                                        get => _inner.TURM_id;
                                        set
                                        {
                                            if (_inner.TURM_id != value)
                                            {
                                                _inner.TURM_id = value;
                                                if ((_trackingMask & ColaboradorTrackingFields.TURM_id) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "TURM_id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ColaboradorTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ColaboradorTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ColaboradorTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ColaboradorTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Colaborador", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration