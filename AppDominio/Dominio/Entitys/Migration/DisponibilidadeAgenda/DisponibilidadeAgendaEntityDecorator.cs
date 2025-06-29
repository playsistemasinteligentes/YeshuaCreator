
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class DisponibilidadeAgendaDecorator : IDisponibilidadeAgendaEntity
{

                        private readonly IDisponibilidadeAgendaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public DisponibilidadeAgendaDecorator(IDisponibilidadeAgendaEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public DateTime DataHora
                                    {
                                        get => _inner.DataHora;
                                        set
                                        {
                                            if (_inner.DataHora != value)
                                            {
                                                _logger.Info($"Propriedade DataHora: antes={_inner.DataHora}, depois={value}");
                                                _inner.DataHora = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration