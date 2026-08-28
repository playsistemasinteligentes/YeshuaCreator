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
                    public static class RelatoriosTrackingFields
        {
            public const ulong REL_ID = 1UL << 0;
            public const ulong REL_NOME_RELATORIO = 1UL << 1;
            public const ulong REL_NOME_CAMPO = 1UL << 2;
            public const ulong REL_TIPO_CAMPO = 1UL << 3;
            public const ulong REL_POS_X = 1UL << 4;
            public const ulong REL_POS_Y = 1UL << 5;
            public const ulong REL_TAMANHO_FONTE = 1UL << 6;
            public const ulong TenantID = 1UL << 7;
            public const ulong Deleted = 1UL << 8;
            public const ulong Changed = 1UL << 9;
            public const ulong UserId = 1UL << 10;
        }

        public partial class RelatoriosDecorator : IRelatoriosEntity
{

                        private readonly IRelatoriosEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public RelatoriosDecorator(IRelatoriosEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public RelatoriosDecorator(
                            IRelatoriosEntity inner,
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
                                    public int REL_ID
                                    {
                                        get => _inner.REL_ID;
                                        set
                                        {
                                            if (_inner.REL_ID != value)
                                            {
                                                _inner.REL_ID = value;
                                                if ((_trackingMask & RelatoriosTrackingFields.REL_ID) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "REL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REL_NOME_RELATORIO
                                    {
                                        get => _inner.REL_NOME_RELATORIO;
                                        set
                                        {
                                            if (_inner.REL_NOME_RELATORIO != value)
                                            {
                                                _inner.REL_NOME_RELATORIO = value;
                                                if ((_trackingMask & RelatoriosTrackingFields.REL_NOME_RELATORIO) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "REL_NOME_RELATORIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REL_NOME_CAMPO
                                    {
                                        get => _inner.REL_NOME_CAMPO;
                                        set
                                        {
                                            if (_inner.REL_NOME_CAMPO != value)
                                            {
                                                _inner.REL_NOME_CAMPO = value;
                                                if ((_trackingMask & RelatoriosTrackingFields.REL_NOME_CAMPO) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "REL_NOME_CAMPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REL_TIPO_CAMPO
                                    {
                                        get => _inner.REL_TIPO_CAMPO;
                                        set
                                        {
                                            if (_inner.REL_TIPO_CAMPO != value)
                                            {
                                                _inner.REL_TIPO_CAMPO = value;
                                                if ((_trackingMask & RelatoriosTrackingFields.REL_TIPO_CAMPO) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "REL_TIPO_CAMPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? REL_POS_X
                                    {
                                        get => _inner.REL_POS_X;
                                        set
                                        {
                                            if (_inner.REL_POS_X != value)
                                            {
                                                _inner.REL_POS_X = value;
                                                if ((_trackingMask & RelatoriosTrackingFields.REL_POS_X) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "REL_POS_X", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? REL_POS_Y
                                    {
                                        get => _inner.REL_POS_Y;
                                        set
                                        {
                                            if (_inner.REL_POS_Y != value)
                                            {
                                                _inner.REL_POS_Y = value;
                                                if ((_trackingMask & RelatoriosTrackingFields.REL_POS_Y) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "REL_POS_Y", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? REL_TAMANHO_FONTE
                                    {
                                        get => _inner.REL_TAMANHO_FONTE;
                                        set
                                        {
                                            if (_inner.REL_TAMANHO_FONTE != value)
                                            {
                                                _inner.REL_TAMANHO_FONTE = value;
                                                if ((_trackingMask & RelatoriosTrackingFields.REL_TAMANHO_FONTE) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "REL_TAMANHO_FONTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RelatoriosTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RelatoriosTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RelatoriosTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & RelatoriosTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Relatorios", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration