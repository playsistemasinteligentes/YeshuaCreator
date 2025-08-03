
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YperfilPermissionActionsDecorator : IYperfilPermissionActionsEntity
{

                        private readonly IYperfilPermissionActionsEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public YperfilPermissionActionsDecorator(IYperfilPermissionActionsEntity inner, Dominio.Interfaces.ILogger logger)
                        {
                            _inner = inner;
                            _logger = logger;
                        }
                                    public int? PerfilId
                                    {
                                        get => _inner.PerfilId;
                                        set
                                        {
                                            if (_inner.PerfilId != value)
                                            {
                                                _logger.Info($"Propriedade PerfilId: antes={_inner.PerfilId}, depois={value}");
                                                _inner.PerfilId = value;
                                            }
                                        }
                                    }

                                    public string permissionActionsId
                                    {
                                        get => _inner.permissionActionsId;
                                        set
                                        {
                                            if (_inner.permissionActionsId != value)
                                            {
                                                _logger.Info($"Propriedade permissionActionsId: antes={_inner.permissionActionsId}, depois={value}");
                                                _inner.permissionActionsId = value;
                                            }
                                        }
                                    }

                                    public bool? Grant
                                    {
                                        get => _inner.Grant;
                                        set
                                        {
                                            if (_inner.Grant != value)
                                            {
                                                _logger.Info($"Propriedade Grant: antes={_inner.Grant}, depois={value}");
                                                _inner.Grant = value;
                                            }
                                        }
                                    }

                                    public bool? Create
                                    {
                                        get => _inner.Create;
                                        set
                                        {
                                            if (_inner.Create != value)
                                            {
                                                _logger.Info($"Propriedade Create: antes={_inner.Create}, depois={value}");
                                                _inner.Create = value;
                                            }
                                        }
                                    }

                                    public bool? Read
                                    {
                                        get => _inner.Read;
                                        set
                                        {
                                            if (_inner.Read != value)
                                            {
                                                _logger.Info($"Propriedade Read: antes={_inner.Read}, depois={value}");
                                                _inner.Read = value;
                                            }
                                        }
                                    }

                                    public bool? Update
                                    {
                                        get => _inner.Update;
                                        set
                                        {
                                            if (_inner.Update != value)
                                            {
                                                _logger.Info($"Propriedade Update: antes={_inner.Update}, depois={value}");
                                                _inner.Update = value;
                                            }
                                        }
                                    }

                                    public bool? Delete
                                    {
                                        get => _inner.Delete;
                                        set
                                        {
                                            if (_inner.Delete != value)
                                            {
                                                _logger.Info($"Propriedade Delete: antes={_inner.Delete}, depois={value}");
                                                _inner.Delete = value;
                                            }
                                        }
                                    }

                                    public DateTime? ValidUntil
                                    {
                                        get => _inner.ValidUntil;
                                        set
                                        {
                                            if (_inner.ValidUntil != value)
                                            {
                                                _logger.Info($"Propriedade ValidUntil: antes={_inner.ValidUntil}, depois={value}");
                                                _inner.ValidUntil = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration