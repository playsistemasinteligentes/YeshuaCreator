
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yUserGrantDecorator : IyUserGrantEntity
{

                        private readonly IyUserGrantEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public yUserGrantDecorator(IyUserGrantEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string GrantId
                                    {
                                        get => _inner.GrantId;
                                        set
                                        {
                                            if (_inner.GrantId != value)
                                            {
                                                _logger.Info($"Propriedade GrantId: antes={_inner.GrantId}, depois={value}");
                                                _inner.GrantId = value;
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