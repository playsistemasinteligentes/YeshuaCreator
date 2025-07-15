
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YtenantDecorator : IYtenantEntity
{

                        private readonly IYtenantEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public YtenantDecorator(IYtenantEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public int CnpjCpf
                                    {
                                        get => _inner.CnpjCpf;
                                        set
                                        {
                                            if (_inner.CnpjCpf != value)
                                            {
                                                _logger.Info($"Propriedade CnpjCpf: antes={_inner.CnpjCpf}, depois={value}");
                                                _inner.CnpjCpf = value;
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

                                    public int? UserIDAdmin
                                    {
                                        get => _inner.UserIDAdmin;
                                        set
                                        {
                                            if (_inner.UserIDAdmin != value)
                                            {
                                                _logger.Info($"Propriedade UserIDAdmin: antes={_inner.UserIDAdmin}, depois={value}");
                                                _inner.UserIDAdmin = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration