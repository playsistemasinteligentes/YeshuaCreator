
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class MDFeDecorator : IMDFeEntity
{

                        private readonly IMDFeEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public MDFeDecorator(IMDFeEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string ChaveAcesso
                                    {
                                        get => _inner.ChaveAcesso;
                                        set
                                        {
                                            if (_inner.ChaveAcesso != value)
                                            {
                                                _logger.Info($"Propriedade ChaveAcesso: antes={_inner.ChaveAcesso}, depois={value}");
                                                _inner.ChaveAcesso = value;
                                            }
                                        }
                                    }

                                    public int Serie
                                    {
                                        get => _inner.Serie;
                                        set
                                        {
                                            if (_inner.Serie != value)
                                            {
                                                _logger.Info($"Propriedade Serie: antes={_inner.Serie}, depois={value}");
                                                _inner.Serie = value;
                                            }
                                        }
                                    }

                                    public int Numero
                                    {
                                        get => _inner.Numero;
                                        set
                                        {
                                            if (_inner.Numero != value)
                                            {
                                                _logger.Info($"Propriedade Numero: antes={_inner.Numero}, depois={value}");
                                                _inner.Numero = value;
                                            }
                                        }
                                    }

                                    public string UfCarregamento
                                    {
                                        get => _inner.UfCarregamento;
                                        set
                                        {
                                            if (_inner.UfCarregamento != value)
                                            {
                                                _logger.Info($"Propriedade UfCarregamento: antes={_inner.UfCarregamento}, depois={value}");
                                                _inner.UfCarregamento = value;
                                            }
                                        }
                                    }

                                    public string UfDescarregamento
                                    {
                                        get => _inner.UfDescarregamento;
                                        set
                                        {
                                            if (_inner.UfDescarregamento != value)
                                            {
                                                _logger.Info($"Propriedade UfDescarregamento: antes={_inner.UfDescarregamento}, depois={value}");
                                                _inner.UfDescarregamento = value;
                                            }
                                        }
                                    }

                                    public string PlacaVeiculo
                                    {
                                        get => _inner.PlacaVeiculo;
                                        set
                                        {
                                            if (_inner.PlacaVeiculo != value)
                                            {
                                                _logger.Info($"Propriedade PlacaVeiculo: antes={_inner.PlacaVeiculo}, depois={value}");
                                                _inner.PlacaVeiculo = value;
                                            }
                                        }
                                    }

                                    public DateTime EmitidoEm
                                    {
                                        get => _inner.EmitidoEm;
                                        set
                                        {
                                            if (_inner.EmitidoEm != value)
                                            {
                                                _logger.Info($"Propriedade EmitidoEm: antes={_inner.EmitidoEm}, depois={value}");
                                                _inner.EmitidoEm = value;
                                            }
                                        }
                                    }

                                    public DateTime? AutorizadoEm
                                    {
                                        get => _inner.AutorizadoEm;
                                        set
                                        {
                                            if (_inner.AutorizadoEm != value)
                                            {
                                                _logger.Info($"Propriedade AutorizadoEm: antes={_inner.AutorizadoEm}, depois={value}");
                                                _inner.AutorizadoEm = value;
                                            }
                                        }
                                    }

                                    public DateTime? IniciadoEm
                                    {
                                        get => _inner.IniciadoEm;
                                        set
                                        {
                                            if (_inner.IniciadoEm != value)
                                            {
                                                _logger.Info($"Propriedade IniciadoEm: antes={_inner.IniciadoEm}, depois={value}");
                                                _inner.IniciadoEm = value;
                                            }
                                        }
                                    }

                                    public DateTime? EncerradoEm
                                    {
                                        get => _inner.EncerradoEm;
                                        set
                                        {
                                            if (_inner.EncerradoEm != value)
                                            {
                                                _logger.Info($"Propriedade EncerradoEm: antes={_inner.EncerradoEm}, depois={value}");
                                                _inner.EncerradoEm = value;
                                            }
                                        }
                                    }

                                    public DateTime? CanceladoEm
                                    {
                                        get => _inner.CanceladoEm;
                                        set
                                        {
                                            if (_inner.CanceladoEm != value)
                                            {
                                                _logger.Info($"Propriedade CanceladoEm: antes={_inner.CanceladoEm}, depois={value}");
                                                _inner.CanceladoEm = value;
                                            }
                                        }
                                    }

                                    public int Situacao
                                    {
                                        get => _inner.Situacao;
                                        set
                                        {
                                            if (_inner.Situacao != value)
                                            {
                                                _logger.Info($"Propriedade Situacao: antes={_inner.Situacao}, depois={value}");
                                                _inner.Situacao = value;
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
                                                _logger.Info($"Propriedade TenantID: antes={_inner.TenantID}, depois={value}");
                                                _inner.TenantID = value;
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
                                                _logger.Info($"Propriedade Deleted: antes={_inner.Deleted}, depois={value}");
                                                _inner.Deleted = value;
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
                                                _logger.Info($"Propriedade Changed: antes={_inner.Changed}, depois={value}");
                                                _inner.Changed = value;
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
                                                _logger.Info($"Propriedade UserId: antes={_inner.UserId}, depois={value}");
                                                _inner.UserId = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration