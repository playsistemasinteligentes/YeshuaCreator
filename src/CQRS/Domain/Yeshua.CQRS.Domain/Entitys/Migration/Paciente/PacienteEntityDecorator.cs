
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class PacienteDecorator : IPacienteEntity
{

                        private readonly IPacienteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public PacienteDecorator(IPacienteEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string Nome
                                    {
                                        get => _inner.Nome;
                                        set
                                        {
                                            if (_inner.Nome != value)
                                            {
                                                _logger.Info($"Propriedade Nome: antes={_inner.Nome}, depois={value}");
                                                _inner.Nome = value;
                                            }
                                        }
                                    }

                                    public string Telefone
                                    {
                                        get => _inner.Telefone;
                                        set
                                        {
                                            if (_inner.Telefone != value)
                                            {
                                                _logger.Info($"Propriedade Telefone: antes={_inner.Telefone}, depois={value}");
                                                _inner.Telefone = value;
                                            }
                                        }
                                    }

                                    public DateTime? DataNascimento
                                    {
                                        get => _inner.DataNascimento;
                                        set
                                        {
                                            if (_inner.DataNascimento != value)
                                            {
                                                _logger.Info($"Propriedade DataNascimento: antes={_inner.DataNascimento}, depois={value}");
                                                _inner.DataNascimento = value;
                                            }
                                        }
                                    }

                                    public int? Genero
                                    {
                                        get => _inner.Genero;
                                        set
                                        {
                                            if (_inner.Genero != value)
                                            {
                                                _logger.Info($"Propriedade Genero: antes={_inner.Genero}, depois={value}");
                                                _inner.Genero = value;
                                            }
                                        }
                                    }

                                    public string Escolaridade
                                    {
                                        get => _inner.Escolaridade;
                                        set
                                        {
                                            if (_inner.Escolaridade != value)
                                            {
                                                _logger.Info($"Propriedade Escolaridade: antes={_inner.Escolaridade}, depois={value}");
                                                _inner.Escolaridade = value;
                                            }
                                        }
                                    }

                                    public string Profissao
                                    {
                                        get => _inner.Profissao;
                                        set
                                        {
                                            if (_inner.Profissao != value)
                                            {
                                                _logger.Info($"Propriedade Profissao: antes={_inner.Profissao}, depois={value}");
                                                _inner.Profissao = value;
                                            }
                                        }
                                    }

                                    public string Endereco
                                    {
                                        get => _inner.Endereco;
                                        set
                                        {
                                            if (_inner.Endereco != value)
                                            {
                                                _logger.Info($"Propriedade Endereco: antes={_inner.Endereco}, depois={value}");
                                                _inner.Endereco = value;
                                            }
                                        }
                                    }

                                    public string NomeResponsavel
                                    {
                                        get => _inner.NomeResponsavel;
                                        set
                                        {
                                            if (_inner.NomeResponsavel != value)
                                            {
                                                _logger.Info($"Propriedade NomeResponsavel: antes={_inner.NomeResponsavel}, depois={value}");
                                                _inner.NomeResponsavel = value;
                                            }
                                        }
                                    }

                                    public string TelefoneResponsavel
                                    {
                                        get => _inner.TelefoneResponsavel;
                                        set
                                        {
                                            if (_inner.TelefoneResponsavel != value)
                                            {
                                                _logger.Info($"Propriedade TelefoneResponsavel: antes={_inner.TelefoneResponsavel}, depois={value}");
                                                _inner.TelefoneResponsavel = value;
                                            }
                                        }
                                    }

                                    public string Observacao
                                    {
                                        get => _inner.Observacao;
                                        set
                                        {
                                            if (_inner.Observacao != value)
                                            {
                                                _logger.Info($"Propriedade Observacao: antes={_inner.Observacao}, depois={value}");
                                                _inner.Observacao = value;
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