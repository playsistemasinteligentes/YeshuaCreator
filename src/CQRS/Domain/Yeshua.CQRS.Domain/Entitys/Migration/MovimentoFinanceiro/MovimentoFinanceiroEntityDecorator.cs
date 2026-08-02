
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class MovimentoFinanceiroDecorator : IMovimentoFinanceiroEntity
{

                        private readonly IMovimentoFinanceiroEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public MovimentoFinanceiroDecorator(IMovimentoFinanceiroEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string IdOrigem
                                    {
                                        get => _inner.IdOrigem;
                                        set
                                        {
                                            if (_inner.IdOrigem != value)
                                            {
                                                _logger.Info($"Propriedade IdOrigem: antes={_inner.IdOrigem}, depois={value}");
                                                _inner.IdOrigem = value;
                                            }
                                        }
                                    }

                                    public int ContaDebitoId
                                    {
                                        get => _inner.ContaDebitoId;
                                        set
                                        {
                                            if (_inner.ContaDebitoId != value)
                                            {
                                                _logger.Info($"Propriedade ContaDebitoId: antes={_inner.ContaDebitoId}, depois={value}");
                                                _inner.ContaDebitoId = value;
                                            }
                                        }
                                    }

                                    public Decimal Valor
                                    {
                                        get => _inner.Valor;
                                        set
                                        {
                                            if (_inner.Valor != value)
                                            {
                                                _logger.Info($"Propriedade Valor: antes={_inner.Valor}, depois={value}");
                                                _inner.Valor = value;
                                            }
                                        }
                                    }

                                    public DateTime DataMovimento
                                    {
                                        get => _inner.DataMovimento;
                                        set
                                        {
                                            if (_inner.DataMovimento != value)
                                            {
                                                _logger.Info($"Propriedade DataMovimento: antes={_inner.DataMovimento}, depois={value}");
                                                _inner.DataMovimento = value;
                                            }
                                        }
                                    }

                                    public DateTime? DataVencimento
                                    {
                                        get => _inner.DataVencimento;
                                        set
                                        {
                                            if (_inner.DataVencimento != value)
                                            {
                                                _logger.Info($"Propriedade DataVencimento: antes={_inner.DataVencimento}, depois={value}");
                                                _inner.DataVencimento = value;
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
                                                _logger.Info($"Propriedade Status: antes={_inner.Status}, depois={value}");
                                                _inner.Status = value;
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