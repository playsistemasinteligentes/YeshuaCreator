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
                    public static class ChamadoSuporteTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Aplicativo = 1UL << 1;
            public const ulong Modulo = 1UL << 2;
            public const ulong Tela = 1UL << 3;
            public const ulong TituloTela = 1UL << 4;
            public const ulong Rota = 1UL << 5;
            public const ulong Caminho = 1UL << 6;
            public const ulong Versao = 1UL << 7;
            public const ulong FusoHorario = 1UL << 8;
            public const ulong MomentoClienteUtc = 1UL << 9;
            public const ulong Assunto = 1UL << 10;
            public const ulong Descricao = 1UL << 11;
            public const ulong Status = 1UL << 12;
            public const ulong CriadoEmUtc = 1UL << 13;
            public const ulong AbertoEmUtc = 1UL << 14;
            public const ulong TenantID = 1UL << 15;
            public const ulong Deleted = 1UL << 16;
            public const ulong Changed = 1UL << 17;
            public const ulong UserId = 1UL << 18;
            public const ulong OperationalEntityId = 1UL << 19;
        }

        public static class ChamadoSuporteOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Aplicativo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Modulo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Tela = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TituloTela = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Rota = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Caminho = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Versao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification FusoHorario = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MomentoClienteUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Assunto = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Descricao = Dominio.Operational.OperationalDataClassification.NeverCapture;
            public const Dominio.Operational.OperationalDataClassification Status = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification CriadoEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AbertoEmUtc = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class ChamadoSuporteDecorator : IChamadoSuporteEntity
{

                        private readonly IChamadoSuporteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ChamadoSuporteDecorator(IChamadoSuporteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ChamadoSuporteDecorator(
                            IChamadoSuporteEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingExecutionIdentity = context is null
                                ? default
                                : new Dominio.Operational.OperationalExecutionIdentity(
                                    context.RootOperationId,
                                    context.OperationId,
                                    context.ExecutionId,
                                    context.CausationId);
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public string? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Aplicativo
                                    {
                                        get => _inner.Aplicativo;
                                        set
                                        {
                                            if (_inner.Aplicativo != value)
                                            {
                                                _inner.Aplicativo = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Aplicativo) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Aplicativo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Aplicativo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Modulo
                                    {
                                        get => _inner.Modulo;
                                        set
                                        {
                                            if (_inner.Modulo != value)
                                            {
                                                _inner.Modulo = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Modulo) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Modulo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Modulo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Tela
                                    {
                                        get => _inner.Tela;
                                        set
                                        {
                                            if (_inner.Tela != value)
                                            {
                                                _inner.Tela = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Tela) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Tela", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Tela, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? TituloTela
                                    {
                                        get => _inner.TituloTela;
                                        set
                                        {
                                            if (_inner.TituloTela != value)
                                            {
                                                _inner.TituloTela = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.TituloTela) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "TituloTela", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.TituloTela, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Rota
                                    {
                                        get => _inner.Rota;
                                        set
                                        {
                                            if (_inner.Rota != value)
                                            {
                                                _inner.Rota = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Rota) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Rota", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Rota, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Caminho
                                    {
                                        get => _inner.Caminho;
                                        set
                                        {
                                            if (_inner.Caminho != value)
                                            {
                                                _inner.Caminho = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Caminho) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Caminho", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Caminho, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string Versao
                                    {
                                        get => _inner.Versao;
                                        set
                                        {
                                            if (_inner.Versao != value)
                                            {
                                                _inner.Versao = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Versao) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Versao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Versao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? FusoHorario
                                    {
                                        get => _inner.FusoHorario;
                                        set
                                        {
                                            if (_inner.FusoHorario != value)
                                            {
                                                _inner.FusoHorario = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.FusoHorario) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "FusoHorario", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.FusoHorario, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? MomentoClienteUtc
                                    {
                                        get => _inner.MomentoClienteUtc;
                                        set
                                        {
                                            if (_inner.MomentoClienteUtc != value)
                                            {
                                                _inner.MomentoClienteUtc = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.MomentoClienteUtc) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "MomentoClienteUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.MomentoClienteUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Assunto
                                    {
                                        get => _inner.Assunto;
                                        set
                                        {
                                            if (_inner.Assunto != value)
                                            {
                                                _inner.Assunto = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Assunto) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Assunto", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Assunto, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _inner.Descricao = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Descricao) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Descricao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Descricao, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Status) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Status", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Status, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime CriadoEmUtc
                                    {
                                        get => _inner.CriadoEmUtc;
                                        set
                                        {
                                            if (_inner.CriadoEmUtc != value)
                                            {
                                                _inner.CriadoEmUtc = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.CriadoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "CriadoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.CriadoEmUtc, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? AbertoEmUtc
                                    {
                                        get => _inner.AbertoEmUtc;
                                        set
                                        {
                                            if (_inner.AbertoEmUtc != value)
                                            {
                                                _inner.AbertoEmUtc = value;
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.AbertoEmUtc) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "AbertoEmUtc", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.AbertoEmUtc, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & ChamadoSuporteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("ChamadoSuporte", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, ChamadoSuporteOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration