
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class EspecialidadeDecorator : IEspecialidadeEntity
{

                        private readonly IEspecialidadeEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public EspecialidadeDecorator(IEspecialidadeEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string Descricao
                                    {
                                        get => _inner.Descricao;
                                        set
                                        {
                                            if (_inner.Descricao != value)
                                            {
                                                _logger.Info($"Propriedade Descricao: antes={_inner.Descricao}, depois={value}");
                                                _inner.Descricao = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration