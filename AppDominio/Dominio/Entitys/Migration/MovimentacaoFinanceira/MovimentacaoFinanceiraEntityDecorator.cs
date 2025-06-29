
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class MovimentacaoFinanceiraDecorator : IMovimentacaoFinanceiraEntity
{

                        private readonly IMovimentacaoFinanceiraEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public MovimentacaoFinanceiraDecorator(IMovimentacaoFinanceiraEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public int TipoMovimentacao
                                    {
                                        get => _inner.TipoMovimentacao;
                                        set
                                        {
                                            if (_inner.TipoMovimentacao != value)
                                            {
                                                _logger.Info($"Propriedade TipoMovimentacao: antes={_inner.TipoMovimentacao}, depois={value}");
                                                _inner.TipoMovimentacao = value;
                                            }
                                        }
                                    }

                                    public DateTime DataMovimentacao
                                    {
                                        get => _inner.DataMovimentacao;
                                        set
                                        {
                                            if (_inner.DataMovimentacao != value)
                                            {
                                                _logger.Info($"Propriedade DataMovimentacao: antes={_inner.DataMovimentacao}, depois={value}");
                                                _inner.DataMovimentacao = value;
                                            }
                                        }
                                    }

                                    public Decimal SaldoAtual
                                    {
                                        get => _inner.SaldoAtual;
                                        set
                                        {
                                            if (_inner.SaldoAtual != value)
                                            {
                                                _logger.Info($"Propriedade SaldoAtual: antes={_inner.SaldoAtual}, depois={value}");
                                                _inner.SaldoAtual = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration