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
                    public static class ClpMedicoesTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Id2 = 1UL << 1;
            public const ulong MaquinaId = 1UL << 2;
            public const ulong DataInicio = 1UL << 3;
            public const ulong DataFim = 1UL << 4;
            public const ulong Emissao = 1UL << 5;
            public const ulong Quantidade = 1UL << 6;
            public const ulong Grupo = 1UL << 7;
            public const ulong Status = 1UL << 8;
            public const ulong TurnoId = 1UL << 9;
            public const ulong TurmaId = 1UL << 10;
            public const ulong IdLoteClp = 1UL << 11;
            public const ulong OcorrenciaId = 1UL << 12;
            public const ulong Fase = 1UL << 13;
            public const ulong ClpOrigem = 1UL << 14;
            public const ulong CLP_LOTE = 1UL << 15;
            public const ulong COMPACTA = 1UL << 16;
            public const ulong BOL_ID = 1UL << 17;
            public const ulong COR_SEQUENCIA = 1UL << 18;
            public const ulong TenantID = 1UL << 19;
            public const ulong Deleted = 1UL << 20;
            public const ulong Changed = 1UL << 21;
            public const ulong UserId = 1UL << 22;
        }

        public partial class ClpMedicoesDecorator : IClpMedicoesEntity
{

                        private readonly IClpMedicoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ClpMedicoesDecorator(IClpMedicoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ClpMedicoesDecorator(
                            IClpMedicoesEntity inner,
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
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int Id2
                                    {
                                        get => _inner.Id2;
                                        set
                                        {
                                            if (_inner.Id2 != value)
                                            {
                                                _inner.Id2 = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Id2) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Id2", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MaquinaId
                                    {
                                        get => _inner.MaquinaId;
                                        set
                                        {
                                            if (_inner.MaquinaId != value)
                                            {
                                                _inner.MaquinaId = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.MaquinaId) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "MaquinaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DataInicio
                                    {
                                        get => _inner.DataInicio;
                                        set
                                        {
                                            if (_inner.DataInicio != value)
                                            {
                                                _inner.DataInicio = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.DataInicio) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "DataInicio", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DataFim
                                    {
                                        get => _inner.DataFim;
                                        set
                                        {
                                            if (_inner.DataFim != value)
                                            {
                                                _inner.DataFim = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.DataFim) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "DataFim", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? Emissao
                                    {
                                        get => _inner.Emissao;
                                        set
                                        {
                                            if (_inner.Emissao != value)
                                            {
                                                _inner.Emissao = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Emissao) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Emissao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal Quantidade
                                    {
                                        get => _inner.Quantidade;
                                        set
                                        {
                                            if (_inner.Quantidade != value)
                                            {
                                                _inner.Quantidade = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Quantidade) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Quantidade", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? Grupo
                                    {
                                        get => _inner.Grupo;
                                        set
                                        {
                                            if (_inner.Grupo != value)
                                            {
                                                _inner.Grupo = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Grupo) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Grupo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _inner.Status = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TurnoId
                                    {
                                        get => _inner.TurnoId;
                                        set
                                        {
                                            if (_inner.TurnoId != value)
                                            {
                                                _inner.TurnoId = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.TurnoId) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "TurnoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TurmaId
                                    {
                                        get => _inner.TurmaId;
                                        set
                                        {
                                            if (_inner.TurmaId != value)
                                            {
                                                _inner.TurmaId = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.TurmaId) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "TurmaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int IdLoteClp
                                    {
                                        get => _inner.IdLoteClp;
                                        set
                                        {
                                            if (_inner.IdLoteClp != value)
                                            {
                                                _inner.IdLoteClp = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.IdLoteClp) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "IdLoteClp", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OcorrenciaId
                                    {
                                        get => _inner.OcorrenciaId;
                                        set
                                        {
                                            if (_inner.OcorrenciaId != value)
                                            {
                                                _inner.OcorrenciaId = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.OcorrenciaId) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "OcorrenciaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Fase
                                    {
                                        get => _inner.Fase;
                                        set
                                        {
                                            if (_inner.Fase != value)
                                            {
                                                _inner.Fase = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Fase) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Fase", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ClpOrigem
                                    {
                                        get => _inner.ClpOrigem;
                                        set
                                        {
                                            if (_inner.ClpOrigem != value)
                                            {
                                                _inner.ClpOrigem = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.ClpOrigem) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "ClpOrigem", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CLP_LOTE
                                    {
                                        get => _inner.CLP_LOTE;
                                        set
                                        {
                                            if (_inner.CLP_LOTE != value)
                                            {
                                                _inner.CLP_LOTE = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.CLP_LOTE) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "CLP_LOTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COMPACTA
                                    {
                                        get => _inner.COMPACTA;
                                        set
                                        {
                                            if (_inner.COMPACTA != value)
                                            {
                                                _inner.COMPACTA = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.COMPACTA) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "COMPACTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string BOL_ID
                                    {
                                        get => _inner.BOL_ID;
                                        set
                                        {
                                            if (_inner.BOL_ID != value)
                                            {
                                                _inner.BOL_ID = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.BOL_ID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "BOL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_SEQUENCIA
                                    {
                                        get => _inner.COR_SEQUENCIA;
                                        set
                                        {
                                            if (_inner.COR_SEQUENCIA != value)
                                            {
                                                _inner.COR_SEQUENCIA = value;
                                                if ((_trackingMask & ClpMedicoesTrackingFields.COR_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "COR_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClpMedicoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClpMedicoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClpMedicoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ClpMedicoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration