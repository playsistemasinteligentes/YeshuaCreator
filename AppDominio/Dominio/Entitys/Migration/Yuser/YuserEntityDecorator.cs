
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YuserDecorator : IYuserEntity
{

                        private readonly IYuserEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public YuserDecorator(IYuserEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string Email
                                    {
                                        get => _inner.Email;
                                        set
                                        {
                                            if (_inner.Email != value)
                                            {
                                                _logger.Info($"Propriedade Email: antes={_inner.Email}, depois={value}");
                                                _inner.Email = value;
                                            }
                                        }
                                    }

                                    public string Senha
                                    {
                                        get => _inner.Senha;
                                        set
                                        {
                                            if (_inner.Senha != value)
                                            {
                                                _logger.Info($"Propriedade Senha: antes={_inner.Senha}, depois={value}");
                                                _inner.Senha = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration