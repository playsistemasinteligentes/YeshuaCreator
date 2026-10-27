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
                    public static class SesoesTrackingFields
        {
            public const ulong PacienteId = 1UL << 0;
            public const ulong DataInicio = 1UL << 1;
            public const ulong DataFim = 1UL << 2;
            public const ulong StatusAgendamento = 1UL << 3;
            public const ulong StatusProntuario = 1UL << 4;
            public const ulong Prontuario = 1UL << 5;
            public const ulong QueixaPrincipal = 1UL << 6;
            public const ulong RegistroDocumental = 1UL << 7;
            public const ulong SintomasRelatados = 1UL << 8;
            public const ulong MudancasDesdeUltimaSessaao = 1UL << 9;
            public const ulong ComportamentoObservado = 1UL << 10;
            public const ulong EstadoEmocionalGeral = 1UL << 11;
            public const ulong DiscursoPensamentos = 1UL << 12;
            public const ulong UsoMedicacao = 1UL << 13;
            public const ulong TecnicasUtilizadas = 1UL << 14;
            public const ulong QuestionamentosReflexoesAbordadas = 1UL << 15;
            public const ulong ExerciciosTarefasSugeridas = 1UL << 16;
            public const ulong DiagnoosticoHipoteseDiagnoostica = 1UL << 17;
            public const ulong ObjetivosCurtoPrazo = 1UL << 18;
            public const ulong ObjetivosLongoPrazo = 1UL << 19;
            public const ulong FrequenciaSugeridaSessooes = 1UL << 20;
            public const ulong EncaminhamentoOutrosProfissionais = 1UL << 21;
            public const ulong InformacoesRelevantesFuturasConsultas = 1UL << 22;
            public const ulong FeedbackPacienteSobreProcessoTerapeeutico = 1UL << 23;
            public const ulong Id = 1UL << 24;
            public const ulong ServicoId = 1UL << 25;
            public const ulong MovimentacaoFinanceiraId = 1UL << 26;
            public const ulong ProfissionalId = 1UL << 27;
            public const ulong TenantID = 1UL << 28;
            public const ulong Deleted = 1UL << 29;
            public const ulong Changed = 1UL << 30;
            public const ulong UserId = 1UL << 31;
            public const ulong OperationalEntityId = 1UL << 32;
            public const ulong AtendimentoIniciadoEm = 1UL << 33;
            public const ulong AtendimentoEncerradoEm = 1UL << 34;
            public const ulong VersaoAtendimento = 1UL << 35;
            public const ulong RegistroFinalizadoEm = 1UL << 36;
            public const ulong RegistroFinalizadoPorUserId = 1UL << 37;
            public const ulong SugestoesIncorporadas = 1UL << 38;
        }

        public static class SesoesOperationalFields
        {
            public const Dominio.Operational.OperationalDataClassification PacienteId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DataInicio = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DataFim = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification StatusAgendamento = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification StatusProntuario = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Prontuario = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification QueixaPrincipal = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RegistroDocumental = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SintomasRelatados = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MudancasDesdeUltimaSessaao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ComportamentoObservado = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EstadoEmocionalGeral = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DiscursoPensamentos = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UsoMedicacao = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TecnicasUtilizadas = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification QuestionamentosReflexoesAbordadas = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ExerciciosTarefasSugeridas = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification DiagnoosticoHipoteseDiagnoostica = Dominio.Operational.OperationalDataClassification.NeverCapture;
            public const Dominio.Operational.OperationalDataClassification ObjetivosCurtoPrazo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ObjetivosLongoPrazo = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification FrequenciaSugeridaSessooes = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification EncaminhamentoOutrosProfissionais = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification InformacoesRelevantesFuturasConsultas = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification FeedbackPacienteSobreProcessoTerapeeutico = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Id = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ServicoId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification MovimentacaoFinanceiraId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification ProfissionalId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification TenantID = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Deleted = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification Changed = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification UserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification OperationalEntityId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AtendimentoIniciadoEm = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification AtendimentoEncerradoEm = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification VersaoAtendimento = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RegistroFinalizadoEm = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification RegistroFinalizadoPorUserId = Dominio.Operational.OperationalDataClassification.Internal;
            public const Dominio.Operational.OperationalDataClassification SugestoesIncorporadas = Dominio.Operational.OperationalDataClassification.Internal;
        }

        public partial class SesoesDecorator : ISesoesEntity
{

                        private readonly ISesoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly Dominio.Operational.OperationalExecutionIdentity _trackingExecutionIdentity;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public SesoesDecorator(ISesoesEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public SesoesDecorator(
                            ISesoesEntity inner,
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
                                    public int? PacienteId
                                    {
                                        get => _inner.PacienteId;
                                        set
                                        {
                                            if (_inner.PacienteId != value)
                                            {
                                                _inner.PacienteId = value;
                                                if ((_trackingMask & SesoesTrackingFields.PacienteId) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "PacienteId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.PacienteId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & SesoesTrackingFields.DataInicio) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "DataInicio", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.DataInicio, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & SesoesTrackingFields.DataFim) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "DataFim", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.DataFim, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? StatusAgendamento
                                    {
                                        get => _inner.StatusAgendamento;
                                        set
                                        {
                                            if (_inner.StatusAgendamento != value)
                                            {
                                                _inner.StatusAgendamento = value;
                                                if ((_trackingMask & SesoesTrackingFields.StatusAgendamento) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "StatusAgendamento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.StatusAgendamento, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? StatusProntuario
                                    {
                                        get => _inner.StatusProntuario;
                                        set
                                        {
                                            if (_inner.StatusProntuario != value)
                                            {
                                                _inner.StatusProntuario = value;
                                                if ((_trackingMask & SesoesTrackingFields.StatusProntuario) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "StatusProntuario", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.StatusProntuario, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? Prontuario
                                    {
                                        get => _inner.Prontuario;
                                        set
                                        {
                                            if (_inner.Prontuario != value)
                                            {
                                                _inner.Prontuario = value;
                                                if ((_trackingMask & SesoesTrackingFields.Prontuario) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "Prontuario", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.Prontuario, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? QueixaPrincipal
                                    {
                                        get => _inner.QueixaPrincipal;
                                        set
                                        {
                                            if (_inner.QueixaPrincipal != value)
                                            {
                                                _inner.QueixaPrincipal = value;
                                                if ((_trackingMask & SesoesTrackingFields.QueixaPrincipal) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "QueixaPrincipal", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.QueixaPrincipal, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? RegistroDocumental
                                    {
                                        get => _inner.RegistroDocumental;
                                        set
                                        {
                                            if (_inner.RegistroDocumental != value)
                                            {
                                                _inner.RegistroDocumental = value;
                                                if ((_trackingMask & SesoesTrackingFields.RegistroDocumental) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "RegistroDocumental", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.RegistroDocumental, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? SintomasRelatados
                                    {
                                        get => _inner.SintomasRelatados;
                                        set
                                        {
                                            if (_inner.SintomasRelatados != value)
                                            {
                                                _inner.SintomasRelatados = value;
                                                if ((_trackingMask & SesoesTrackingFields.SintomasRelatados) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "SintomasRelatados", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.SintomasRelatados, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? MudancasDesdeUltimaSessaao
                                    {
                                        get => _inner.MudancasDesdeUltimaSessaao;
                                        set
                                        {
                                            if (_inner.MudancasDesdeUltimaSessaao != value)
                                            {
                                                _inner.MudancasDesdeUltimaSessaao = value;
                                                if ((_trackingMask & SesoesTrackingFields.MudancasDesdeUltimaSessaao) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "MudancasDesdeUltimaSessaao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.MudancasDesdeUltimaSessaao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ComportamentoObservado
                                    {
                                        get => _inner.ComportamentoObservado;
                                        set
                                        {
                                            if (_inner.ComportamentoObservado != value)
                                            {
                                                _inner.ComportamentoObservado = value;
                                                if ((_trackingMask & SesoesTrackingFields.ComportamentoObservado) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "ComportamentoObservado", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.ComportamentoObservado, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? EstadoEmocionalGeral
                                    {
                                        get => _inner.EstadoEmocionalGeral;
                                        set
                                        {
                                            if (_inner.EstadoEmocionalGeral != value)
                                            {
                                                _inner.EstadoEmocionalGeral = value;
                                                if ((_trackingMask & SesoesTrackingFields.EstadoEmocionalGeral) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "EstadoEmocionalGeral", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.EstadoEmocionalGeral, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? DiscursoPensamentos
                                    {
                                        get => _inner.DiscursoPensamentos;
                                        set
                                        {
                                            if (_inner.DiscursoPensamentos != value)
                                            {
                                                _inner.DiscursoPensamentos = value;
                                                if ((_trackingMask & SesoesTrackingFields.DiscursoPensamentos) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "DiscursoPensamentos", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.DiscursoPensamentos, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? UsoMedicacao
                                    {
                                        get => _inner.UsoMedicacao;
                                        set
                                        {
                                            if (_inner.UsoMedicacao != value)
                                            {
                                                _inner.UsoMedicacao = value;
                                                if ((_trackingMask & SesoesTrackingFields.UsoMedicacao) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "UsoMedicacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.UsoMedicacao, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? TecnicasUtilizadas
                                    {
                                        get => _inner.TecnicasUtilizadas;
                                        set
                                        {
                                            if (_inner.TecnicasUtilizadas != value)
                                            {
                                                _inner.TecnicasUtilizadas = value;
                                                if ((_trackingMask & SesoesTrackingFields.TecnicasUtilizadas) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "TecnicasUtilizadas", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.TecnicasUtilizadas, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? QuestionamentosReflexoesAbordadas
                                    {
                                        get => _inner.QuestionamentosReflexoesAbordadas;
                                        set
                                        {
                                            if (_inner.QuestionamentosReflexoesAbordadas != value)
                                            {
                                                _inner.QuestionamentosReflexoesAbordadas = value;
                                                if ((_trackingMask & SesoesTrackingFields.QuestionamentosReflexoesAbordadas) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "QuestionamentosReflexoesAbordadas", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.QuestionamentosReflexoesAbordadas, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ExerciciosTarefasSugeridas
                                    {
                                        get => _inner.ExerciciosTarefasSugeridas;
                                        set
                                        {
                                            if (_inner.ExerciciosTarefasSugeridas != value)
                                            {
                                                _inner.ExerciciosTarefasSugeridas = value;
                                                if ((_trackingMask & SesoesTrackingFields.ExerciciosTarefasSugeridas) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "ExerciciosTarefasSugeridas", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.ExerciciosTarefasSugeridas, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? DiagnoosticoHipoteseDiagnoostica
                                    {
                                        get => _inner.DiagnoosticoHipoteseDiagnoostica;
                                        set
                                        {
                                            if (_inner.DiagnoosticoHipoteseDiagnoostica != value)
                                            {
                                                _inner.DiagnoosticoHipoteseDiagnoostica = value;
                                                if ((_trackingMask & SesoesTrackingFields.DiagnoosticoHipoteseDiagnoostica) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "DiagnoosticoHipoteseDiagnoostica", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.DiagnoosticoHipoteseDiagnoostica, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ObjetivosCurtoPrazo
                                    {
                                        get => _inner.ObjetivosCurtoPrazo;
                                        set
                                        {
                                            if (_inner.ObjetivosCurtoPrazo != value)
                                            {
                                                _inner.ObjetivosCurtoPrazo = value;
                                                if ((_trackingMask & SesoesTrackingFields.ObjetivosCurtoPrazo) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "ObjetivosCurtoPrazo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.ObjetivosCurtoPrazo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? ObjetivosLongoPrazo
                                    {
                                        get => _inner.ObjetivosLongoPrazo;
                                        set
                                        {
                                            if (_inner.ObjetivosLongoPrazo != value)
                                            {
                                                _inner.ObjetivosLongoPrazo = value;
                                                if ((_trackingMask & SesoesTrackingFields.ObjetivosLongoPrazo) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "ObjetivosLongoPrazo", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.ObjetivosLongoPrazo, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? FrequenciaSugeridaSessooes
                                    {
                                        get => _inner.FrequenciaSugeridaSessooes;
                                        set
                                        {
                                            if (_inner.FrequenciaSugeridaSessooes != value)
                                            {
                                                _inner.FrequenciaSugeridaSessooes = value;
                                                if ((_trackingMask & SesoesTrackingFields.FrequenciaSugeridaSessooes) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "FrequenciaSugeridaSessooes", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.FrequenciaSugeridaSessooes, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? EncaminhamentoOutrosProfissionais
                                    {
                                        get => _inner.EncaminhamentoOutrosProfissionais;
                                        set
                                        {
                                            if (_inner.EncaminhamentoOutrosProfissionais != value)
                                            {
                                                _inner.EncaminhamentoOutrosProfissionais = value;
                                                if ((_trackingMask & SesoesTrackingFields.EncaminhamentoOutrosProfissionais) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "EncaminhamentoOutrosProfissionais", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.EncaminhamentoOutrosProfissionais, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? InformacoesRelevantesFuturasConsultas
                                    {
                                        get => _inner.InformacoesRelevantesFuturasConsultas;
                                        set
                                        {
                                            if (_inner.InformacoesRelevantesFuturasConsultas != value)
                                            {
                                                _inner.InformacoesRelevantesFuturasConsultas = value;
                                                if ((_trackingMask & SesoesTrackingFields.InformacoesRelevantesFuturasConsultas) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "InformacoesRelevantesFuturasConsultas", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.InformacoesRelevantesFuturasConsultas, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? FeedbackPacienteSobreProcessoTerapeeutico
                                    {
                                        get => _inner.FeedbackPacienteSobreProcessoTerapeeutico;
                                        set
                                        {
                                            if (_inner.FeedbackPacienteSobreProcessoTerapeeutico != value)
                                            {
                                                _inner.FeedbackPacienteSobreProcessoTerapeeutico = value;
                                                if ((_trackingMask & SesoesTrackingFields.FeedbackPacienteSobreProcessoTerapeeutico) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "FeedbackPacienteSobreProcessoTerapeeutico", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.FeedbackPacienteSobreProcessoTerapeeutico, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & SesoesTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.Id, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ServicoId
                                    {
                                        get => _inner.ServicoId;
                                        set
                                        {
                                            if (_inner.ServicoId != value)
                                            {
                                                _inner.ServicoId = value;
                                                if ((_trackingMask & SesoesTrackingFields.ServicoId) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "ServicoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.ServicoId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? MovimentacaoFinanceiraId
                                    {
                                        get => _inner.MovimentacaoFinanceiraId;
                                        set
                                        {
                                            if (_inner.MovimentacaoFinanceiraId != value)
                                            {
                                                _inner.MovimentacaoFinanceiraId = value;
                                                if ((_trackingMask & SesoesTrackingFields.MovimentacaoFinanceiraId) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "MovimentacaoFinanceiraId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.MovimentacaoFinanceiraId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? ProfissionalId
                                    {
                                        get => _inner.ProfissionalId;
                                        set
                                        {
                                            if (_inner.ProfissionalId != value)
                                            {
                                                _inner.ProfissionalId = value;
                                                if ((_trackingMask & SesoesTrackingFields.ProfissionalId) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "ProfissionalId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.ProfissionalId, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & SesoesTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.TenantID, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & SesoesTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.Deleted, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & SesoesTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.Changed, _trackingExecutionIdentity);
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
                                                if ((_trackingMask & SesoesTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.UserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }
    public string OperationalEntityId => _inner.OperationalEntityId;

                                    public DateTime? AtendimentoIniciadoEm
                                    {
                                        get => _inner.AtendimentoIniciadoEm;
                                        set
                                        {
                                            if (_inner.AtendimentoIniciadoEm != value)
                                            {
                                                _inner.AtendimentoIniciadoEm = value;
                                                if ((_trackingMask & SesoesTrackingFields.AtendimentoIniciadoEm) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "AtendimentoIniciadoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.AtendimentoIniciadoEm, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? AtendimentoEncerradoEm
                                    {
                                        get => _inner.AtendimentoEncerradoEm;
                                        set
                                        {
                                            if (_inner.AtendimentoEncerradoEm != value)
                                            {
                                                _inner.AtendimentoEncerradoEm = value;
                                                if ((_trackingMask & SesoesTrackingFields.AtendimentoEncerradoEm) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "AtendimentoEncerradoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.AtendimentoEncerradoEm, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int VersaoAtendimento
                                    {
                                        get => _inner.VersaoAtendimento;
                                        set
                                        {
                                            if (_inner.VersaoAtendimento != value)
                                            {
                                                _inner.VersaoAtendimento = value;
                                                if ((_trackingMask & SesoesTrackingFields.VersaoAtendimento) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "VersaoAtendimento", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.VersaoAtendimento, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public DateTime? RegistroFinalizadoEm
                                    {
                                        get => _inner.RegistroFinalizadoEm;
                                        set
                                        {
                                            if (_inner.RegistroFinalizadoEm != value)
                                            {
                                                _inner.RegistroFinalizadoEm = value;
                                                if ((_trackingMask & SesoesTrackingFields.RegistroFinalizadoEm) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "RegistroFinalizadoEm", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.RegistroFinalizadoEm, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public int? RegistroFinalizadoPorUserId
                                    {
                                        get => _inner.RegistroFinalizadoPorUserId;
                                        set
                                        {
                                            if (_inner.RegistroFinalizadoPorUserId != value)
                                            {
                                                _inner.RegistroFinalizadoPorUserId = value;
                                                if ((_trackingMask & SesoesTrackingFields.RegistroFinalizadoPorUserId) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "RegistroFinalizadoPorUserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.RegistroFinalizadoPorUserId, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                                    public string? SugestoesIncorporadas
                                    {
                                        get => _inner.SugestoesIncorporadas;
                                        set
                                        {
                                            if (_inner.SugestoesIncorporadas != value)
                                            {
                                                _inner.SugestoesIncorporadas = value;
                                                if ((_trackingMask & SesoesTrackingFields.SugestoesIncorporadas) != 0UL)
                                                    _logger.DomainValueChanged("Sesoes", "SugestoesIncorporadas", _trackingTraceId, _trackingOperation, _trackingRecordId, value, SesoesOperationalFields.SugestoesIncorporadas, _trackingExecutionIdentity);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration