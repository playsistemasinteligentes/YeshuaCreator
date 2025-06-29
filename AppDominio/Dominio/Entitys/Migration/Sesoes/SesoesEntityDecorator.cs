
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class SesoesDecorator : ISesoesEntity
{

                        private readonly ISesoesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public SesoesDecorator(ISesoesEntity inner, Dominio.Interfaces.ILogger logger)
                        {
                            _inner = inner;
                            _logger = logger;
                        }
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _logger.Info($"Propriedade Id: antes={_inner.Id}, depois={value}");
                                                _inner.Id = value;
                                            }
                                        }
                                    }

                                    public int? PacienteId
                                    {
                                        get => _inner.PacienteId;
                                        set
                                        {
                                            if (_inner.PacienteId != value)
                                            {
                                                _logger.Info($"Propriedade PacienteId: antes={_inner.PacienteId}, depois={value}");
                                                _inner.PacienteId = value;
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
                                                _logger.Info($"Propriedade ProfissionalId: antes={_inner.ProfissionalId}, depois={value}");
                                                _inner.ProfissionalId = value;
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
                                                _logger.Info($"Propriedade ServicoId: antes={_inner.ServicoId}, depois={value}");
                                                _inner.ServicoId = value;
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
                                                _logger.Info($"Propriedade DataInicio: antes={_inner.DataInicio}, depois={value}");
                                                _inner.DataInicio = value;
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
                                                _logger.Info($"Propriedade DataFim: antes={_inner.DataFim}, depois={value}");
                                                _inner.DataFim = value;
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
                                                _logger.Info($"Propriedade Status: antes={_inner.Status}, depois={value}");
                                                _inner.Status = value;
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
                                                _logger.Info($"Propriedade MovimentacaoFinanceiraId: antes={_inner.MovimentacaoFinanceiraId}, depois={value}");
                                                _inner.MovimentacaoFinanceiraId = value;
                                            }
                                        }
                                    }

                                    public string SinteseProntuario
                                    {
                                        get => _inner.SinteseProntuario;
                                        set
                                        {
                                            if (_inner.SinteseProntuario != value)
                                            {
                                                _logger.Info($"Propriedade SinteseProntuario: antes={_inner.SinteseProntuario}, depois={value}");
                                                _inner.SinteseProntuario = value;
                                            }
                                        }
                                    }

                                    public string QueixaPrincipal
                                    {
                                        get => _inner.QueixaPrincipal;
                                        set
                                        {
                                            if (_inner.QueixaPrincipal != value)
                                            {
                                                _logger.Info($"Propriedade QueixaPrincipal: antes={_inner.QueixaPrincipal}, depois={value}");
                                                _inner.QueixaPrincipal = value;
                                            }
                                        }
                                    }

                                    public string MotivoConsultaAtual
                                    {
                                        get => _inner.MotivoConsultaAtual;
                                        set
                                        {
                                            if (_inner.MotivoConsultaAtual != value)
                                            {
                                                _logger.Info($"Propriedade MotivoConsultaAtual: antes={_inner.MotivoConsultaAtual}, depois={value}");
                                                _inner.MotivoConsultaAtual = value;
                                            }
                                        }
                                    }

                                    public string SintomasRelatados
                                    {
                                        get => _inner.SintomasRelatados;
                                        set
                                        {
                                            if (_inner.SintomasRelatados != value)
                                            {
                                                _logger.Info($"Propriedade SintomasRelatados: antes={_inner.SintomasRelatados}, depois={value}");
                                                _inner.SintomasRelatados = value;
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
                                                _logger.Info($"Propriedade MudancasDesdeUltimaSessaao: antes={_inner.MudancasDesdeUltimaSessaao}, depois={value}");
                                                _inner.MudancasDesdeUltimaSessaao = value;
                                            }
                                        }
                                    }

                                    public string ComportamentoObservado
                                    {
                                        get => _inner.ComportamentoObservado;
                                        set
                                        {
                                            if (_inner.ComportamentoObservado != value)
                                            {
                                                _logger.Info($"Propriedade ComportamentoObservado: antes={_inner.ComportamentoObservado}, depois={value}");
                                                _inner.ComportamentoObservado = value;
                                            }
                                        }
                                    }

                                    public string EstadoEmocionalGeral
                                    {
                                        get => _inner.EstadoEmocionalGeral;
                                        set
                                        {
                                            if (_inner.EstadoEmocionalGeral != value)
                                            {
                                                _logger.Info($"Propriedade EstadoEmocionalGeral: antes={_inner.EstadoEmocionalGeral}, depois={value}");
                                                _inner.EstadoEmocionalGeral = value;
                                            }
                                        }
                                    }

                                    public string DiscursoPensamentos
                                    {
                                        get => _inner.DiscursoPensamentos;
                                        set
                                        {
                                            if (_inner.DiscursoPensamentos != value)
                                            {
                                                _logger.Info($"Propriedade DiscursoPensamentos: antes={_inner.DiscursoPensamentos}, depois={value}");
                                                _inner.DiscursoPensamentos = value;
                                            }
                                        }
                                    }

                                    public string TecnicasUtilizadas
                                    {
                                        get => _inner.TecnicasUtilizadas;
                                        set
                                        {
                                            if (_inner.TecnicasUtilizadas != value)
                                            {
                                                _logger.Info($"Propriedade TecnicasUtilizadas: antes={_inner.TecnicasUtilizadas}, depois={value}");
                                                _inner.TecnicasUtilizadas = value;
                                            }
                                        }
                                    }

                                    public string QuestionamentosReflexoesAbordadas
                                    {
                                        get => _inner.QuestionamentosReflexoesAbordadas;
                                        set
                                        {
                                            if (_inner.QuestionamentosReflexoesAbordadas != value)
                                            {
                                                _logger.Info($"Propriedade QuestionamentosReflexoesAbordadas: antes={_inner.QuestionamentosReflexoesAbordadas}, depois={value}");
                                                _inner.QuestionamentosReflexoesAbordadas = value;
                                            }
                                        }
                                    }

                                    public string ExerciciosTarefasSugeridas
                                    {
                                        get => _inner.ExerciciosTarefasSugeridas;
                                        set
                                        {
                                            if (_inner.ExerciciosTarefasSugeridas != value)
                                            {
                                                _logger.Info($"Propriedade ExerciciosTarefasSugeridas: antes={_inner.ExerciciosTarefasSugeridas}, depois={value}");
                                                _inner.ExerciciosTarefasSugeridas = value;
                                            }
                                        }
                                    }

                                    public string DiagnoosticoHipoteseDiagnoostica
                                    {
                                        get => _inner.DiagnoosticoHipoteseDiagnoostica;
                                        set
                                        {
                                            if (_inner.DiagnoosticoHipoteseDiagnoostica != value)
                                            {
                                                _logger.Info($"Propriedade DiagnoosticoHipoteseDiagnoostica: antes={_inner.DiagnoosticoHipoteseDiagnoostica}, depois={value}");
                                                _inner.DiagnoosticoHipoteseDiagnoostica = value;
                                            }
                                        }
                                    }

                                    public string ObjetivosCurtoPrazo
                                    {
                                        get => _inner.ObjetivosCurtoPrazo;
                                        set
                                        {
                                            if (_inner.ObjetivosCurtoPrazo != value)
                                            {
                                                _logger.Info($"Propriedade ObjetivosCurtoPrazo: antes={_inner.ObjetivosCurtoPrazo}, depois={value}");
                                                _inner.ObjetivosCurtoPrazo = value;
                                            }
                                        }
                                    }

                                    public string ObjetivosLongoPrazo
                                    {
                                        get => _inner.ObjetivosLongoPrazo;
                                        set
                                        {
                                            if (_inner.ObjetivosLongoPrazo != value)
                                            {
                                                _logger.Info($"Propriedade ObjetivosLongoPrazo: antes={_inner.ObjetivosLongoPrazo}, depois={value}");
                                                _inner.ObjetivosLongoPrazo = value;
                                            }
                                        }
                                    }

                                    public string FrequenciaSugeridaSessooes
                                    {
                                        get => _inner.FrequenciaSugeridaSessooes;
                                        set
                                        {
                                            if (_inner.FrequenciaSugeridaSessooes != value)
                                            {
                                                _logger.Info($"Propriedade FrequenciaSugeridaSessooes: antes={_inner.FrequenciaSugeridaSessooes}, depois={value}");
                                                _inner.FrequenciaSugeridaSessooes = value;
                                            }
                                        }
                                    }

                                    public string EncaminhamentoOutrosProfissionais
                                    {
                                        get => _inner.EncaminhamentoOutrosProfissionais;
                                        set
                                        {
                                            if (_inner.EncaminhamentoOutrosProfissionais != value)
                                            {
                                                _logger.Info($"Propriedade EncaminhamentoOutrosProfissionais: antes={_inner.EncaminhamentoOutrosProfissionais}, depois={value}");
                                                _inner.EncaminhamentoOutrosProfissionais = value;
                                            }
                                        }
                                    }

                                    public string InformacoesRelevantesFuturasConsultas
                                    {
                                        get => _inner.InformacoesRelevantesFuturasConsultas;
                                        set
                                        {
                                            if (_inner.InformacoesRelevantesFuturasConsultas != value)
                                            {
                                                _logger.Info($"Propriedade InformacoesRelevantesFuturasConsultas: antes={_inner.InformacoesRelevantesFuturasConsultas}, depois={value}");
                                                _inner.InformacoesRelevantesFuturasConsultas = value;
                                            }
                                        }
                                    }

                                    public string FeedbackPacienteSobreProcessoTerapeeutico
                                    {
                                        get => _inner.FeedbackPacienteSobreProcessoTerapeeutico;
                                        set
                                        {
                                            if (_inner.FeedbackPacienteSobreProcessoTerapeeutico != value)
                                            {
                                                _logger.Info($"Propriedade FeedbackPacienteSobreProcessoTerapeeutico: antes={_inner.FeedbackPacienteSobreProcessoTerapeeutico}, depois={value}");
                                                _inner.FeedbackPacienteSobreProcessoTerapeeutico = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration