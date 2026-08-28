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
                    public static class MovimentosTrackingFields
        {
            public const ulong MOV_ID = 1UL << 0;
            public const ulong MOV_DATA = 1UL << 1;
            public const ulong MOV_VALOR = 1UL << 2;
            public const ulong MOV_PLAID = 1UL << 3;
            public const ulong MOV_UNID = 1UL << 4;
            public const ulong Tr_Unidade_UNI_ID = 1UL << 5;
            public const ulong TenantID = 1UL << 6;
            public const ulong Deleted = 1UL << 7;
            public const ulong Changed = 1UL << 8;
            public const ulong UserId = 1UL << 9;
        }

        public partial class MovimentosDecorator : IMovimentosEntity
{

                        private readonly IMovimentosEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MovimentosDecorator(IMovimentosEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MovimentosDecorator(
                            IMovimentosEntity inner,
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
                                    public int MOV_ID
                                    {
                                        get => _inner.MOV_ID;
                                        set
                                        {
                                            if (_inner.MOV_ID != value)
                                            {
                                                _inner.MOV_ID = value;
                                                if ((_trackingMask & MovimentosTrackingFields.MOV_ID) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "MOV_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_DATA
                                    {
                                        get => _inner.MOV_DATA;
                                        set
                                        {
                                            if (_inner.MOV_DATA != value)
                                            {
                                                _inner.MOV_DATA = value;
                                                if ((_trackingMask & MovimentosTrackingFields.MOV_DATA) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "MOV_DATA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal MOV_VALOR
                                    {
                                        get => _inner.MOV_VALOR;
                                        set
                                        {
                                            if (_inner.MOV_VALOR != value)
                                            {
                                                _inner.MOV_VALOR = value;
                                                if ((_trackingMask & MovimentosTrackingFields.MOV_VALOR) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "MOV_VALOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MOV_PLAID
                                    {
                                        get => _inner.MOV_PLAID;
                                        set
                                        {
                                            if (_inner.MOV_PLAID != value)
                                            {
                                                _inner.MOV_PLAID = value;
                                                if ((_trackingMask & MovimentosTrackingFields.MOV_PLAID) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "MOV_PLAID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int MOV_UNID
                                    {
                                        get => _inner.MOV_UNID;
                                        set
                                        {
                                            if (_inner.MOV_UNID != value)
                                            {
                                                _inner.MOV_UNID = value;
                                                if ((_trackingMask & MovimentosTrackingFields.MOV_UNID) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "MOV_UNID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Tr_Unidade_UNI_ID
                                    {
                                        get => _inner.Tr_Unidade_UNI_ID;
                                        set
                                        {
                                            if (_inner.Tr_Unidade_UNI_ID != value)
                                            {
                                                _inner.Tr_Unidade_UNI_ID = value;
                                                if ((_trackingMask & MovimentosTrackingFields.Tr_Unidade_UNI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "Tr_Unidade_UNI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentosTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentosTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentosTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentosTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Movimentos", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration