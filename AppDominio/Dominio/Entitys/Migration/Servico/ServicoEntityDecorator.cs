
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ServicoDecorator : IServicoEntity
{

                        private readonly IServicoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public ServicoDecorator(IServicoEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public int? GrupoServicoId
                                    {
                                        get => _inner.GrupoServicoId;
                                        set
                                        {
                                            if (_inner.GrupoServicoId != value)
                                            {
                                                _logger.Info($"Propriedade GrupoServicoId: antes={_inner.GrupoServicoId}, depois={value}");
                                                _inner.GrupoServicoId = value;
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

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration