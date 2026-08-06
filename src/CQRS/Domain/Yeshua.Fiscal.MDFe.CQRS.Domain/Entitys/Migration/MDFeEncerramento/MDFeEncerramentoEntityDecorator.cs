
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class MDFeEncerramentoDecorator : IMDFeEncerramentoEntity
{

                        private readonly IMDFeEncerramentoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public MDFeEncerramentoDecorator(IMDFeEncerramentoEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public int MDFeId
                                    {
                                        get => _inner.MDFeId;
                                        set
                                        {
                                            if (_inner.MDFeId != value)
                                            {
                                                _logger.Info($"Propriedade MDFeId: antes={_inner.MDFeId}, depois={value}");
                                                _inner.MDFeId = value;
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

                                    public DateTime SolicitadoEm
                                    {
                                        get => _inner.SolicitadoEm;
                                        set
                                        {
                                            if (_inner.SolicitadoEm != value)
                                            {
                                                _logger.Info($"Propriedade SolicitadoEm: antes={_inner.SolicitadoEm}, depois={value}");
                                                _inner.SolicitadoEm = value;
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

                                    public string Protocolo
                                    {
                                        get => _inner.Protocolo;
                                        set
                                        {
                                            if (_inner.Protocolo != value)
                                            {
                                                _logger.Info($"Propriedade Protocolo: antes={_inner.Protocolo}, depois={value}");
                                                _inner.Protocolo = value;
                                            }
                                        }
                                    }

                                    public string CodigoRetorno
                                    {
                                        get => _inner.CodigoRetorno;
                                        set
                                        {
                                            if (_inner.CodigoRetorno != value)
                                            {
                                                _logger.Info($"Propriedade CodigoRetorno: antes={_inner.CodigoRetorno}, depois={value}");
                                                _inner.CodigoRetorno = value;
                                            }
                                        }
                                    }

                                    public string MensagemRetorno
                                    {
                                        get => _inner.MensagemRetorno;
                                        set
                                        {
                                            if (_inner.MensagemRetorno != value)
                                            {
                                                _logger.Info($"Propriedade MensagemRetorno: antes={_inner.MensagemRetorno}, depois={value}");
                                                _inner.MensagemRetorno = value;
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