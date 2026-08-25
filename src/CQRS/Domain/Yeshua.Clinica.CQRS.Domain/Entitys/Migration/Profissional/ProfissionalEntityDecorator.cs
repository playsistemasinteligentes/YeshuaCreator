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
                    public static class ProfissionalTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Nome = 1UL << 1;
            public const ulong EspecialidadeId = 1UL << 2;
            public const ulong Telefone = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public partial class ProfissionalDecorator : IProfissionalEntity
{

                        private readonly IProfissionalEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ProfissionalDecorator(IProfissionalEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ProfissionalDecorator(
                            IProfissionalEntity inner,
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
                                                if ((_trackingMask & ProfissionalTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Profissional", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProfissionalTrackingFields.Nome) != 0UL)
                                                    _logger.DomainValueChanged("Profissional", "Nome", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? EspecialidadeId
                                    {
                                        get => _inner.EspecialidadeId;
                                        set
                                        {
                                            if (_inner.EspecialidadeId != value)
                                            {
                                                _inner.EspecialidadeId = value;
                                                if ((_trackingMask & ProfissionalTrackingFields.EspecialidadeId) != 0UL)
                                                    _logger.DomainValueChanged("Profissional", "EspecialidadeId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Telefone
                                    {
                                        get => _inner.Telefone;
                                        set
                                        {
                                            if (_inner.Telefone != value)
                                            {
                                                _inner.Telefone = value;
                                                if ((_trackingMask & ProfissionalTrackingFields.Telefone) != 0UL)
                                                    _logger.DomainValueChanged("Profissional", "Telefone", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProfissionalTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Profissional", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProfissionalTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Profissional", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProfissionalTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Profissional", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ProfissionalTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Profissional", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration