
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YpermissionActionsDecorator : IYpermissionActionsEntity
{

                        private readonly IYpermissionActionsEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public YpermissionActionsDecorator(IYpermissionActionsEntity inner, Dominio.Interfaces.ILogger logger)
                        {
                            _inner = inner;
                            _logger = logger;
                        }
                                    public string Id
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

                                    public string Description
                                    {
                                        get => _inner.Description;
                                        set
                                        {
                                            if (_inner.Description != value)
                                            {
                                                _logger.Info($"Propriedade Description: antes={_inner.Description}, depois={value}");
                                                _inner.Description = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration