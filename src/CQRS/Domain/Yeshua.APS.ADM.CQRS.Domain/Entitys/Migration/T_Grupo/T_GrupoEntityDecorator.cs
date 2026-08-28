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
                    public static class T_GrupoTrackingFields
        {
            public const ulong GRU_ID = 1UL << 0;
            public const ulong NOME = 1UL << 1;
            public const ulong EXIBELISTA = 1UL << 2;
            public const ulong GRU_DESCRICAO = 1UL << 3;
            public const ulong TenantID = 1UL << 4;
            public const ulong Deleted = 1UL << 5;
            public const ulong Changed = 1UL << 6;
            public const ulong UserId = 1UL << 7;
        }

        public partial class T_GrupoDecorator : IT_GrupoEntity
{

                        private readonly IT_GrupoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public T_GrupoDecorator(IT_GrupoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public T_GrupoDecorator(
                            IT_GrupoEntity inner,
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
                                    public int GRU_ID
                                    {
                                        get => _inner.GRU_ID;
                                        set
                                        {
                                            if (_inner.GRU_ID != value)
                                            {
                                                _inner.GRU_ID = value;
                                                if ((_trackingMask & T_GrupoTrackingFields.GRU_ID) != 0UL)
                                                    _logger.DomainValueChanged("T_Grupo", "GRU_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string NOME
                                    {
                                        get => _inner.NOME;
                                        set
                                        {
                                            if (_inner.NOME != value)
                                            {
                                                _inner.NOME = value;
                                                if ((_trackingMask & T_GrupoTrackingFields.NOME) != 0UL)
                                                    _logger.DomainValueChanged("T_Grupo", "NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int EXIBELISTA
                                    {
                                        get => _inner.EXIBELISTA;
                                        set
                                        {
                                            if (_inner.EXIBELISTA != value)
                                            {
                                                _inner.EXIBELISTA = value;
                                                if ((_trackingMask & T_GrupoTrackingFields.EXIBELISTA) != 0UL)
                                                    _logger.DomainValueChanged("T_Grupo", "EXIBELISTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string GRU_DESCRICAO
                                    {
                                        get => _inner.GRU_DESCRICAO;
                                        set
                                        {
                                            if (_inner.GRU_DESCRICAO != value)
                                            {
                                                _inner.GRU_DESCRICAO = value;
                                                if ((_trackingMask & T_GrupoTrackingFields.GRU_DESCRICAO) != 0UL)
                                                    _logger.DomainValueChanged("T_Grupo", "GRU_DESCRICAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_GrupoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("T_Grupo", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_GrupoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("T_Grupo", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_GrupoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("T_Grupo", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & T_GrupoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("T_Grupo", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration