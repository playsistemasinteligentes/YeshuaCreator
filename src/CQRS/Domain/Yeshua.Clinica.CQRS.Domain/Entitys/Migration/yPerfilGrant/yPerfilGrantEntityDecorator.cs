
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yPerfilGrantDecorator : IyPerfilGrantEntity
{

                        private readonly IyPerfilGrantEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public yPerfilGrantDecorator(IyPerfilGrantEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public bool? CanGrant
                                    {
                                        get => _inner.CanGrant;
                                        set
                                        {
                                            if (_inner.CanGrant != value)
                                            {
                                                _logger.Info($"Propriedade CanGrant: antes={_inner.CanGrant}, depois={value}");
                                                _inner.CanGrant = value;
                                            }
                                        }
                                    }

                                    public bool? CanCreate
                                    {
                                        get => _inner.CanCreate;
                                        set
                                        {
                                            if (_inner.CanCreate != value)
                                            {
                                                _logger.Info($"Propriedade CanCreate: antes={_inner.CanCreate}, depois={value}");
                                                _inner.CanCreate = value;
                                            }
                                        }
                                    }

                                    public bool? CanRead
                                    {
                                        get => _inner.CanRead;
                                        set
                                        {
                                            if (_inner.CanRead != value)
                                            {
                                                _logger.Info($"Propriedade CanRead: antes={_inner.CanRead}, depois={value}");
                                                _inner.CanRead = value;
                                            }
                                        }
                                    }

                                    public bool? CanUpdate
                                    {
                                        get => _inner.CanUpdate;
                                        set
                                        {
                                            if (_inner.CanUpdate != value)
                                            {
                                                _logger.Info($"Propriedade CanUpdate: antes={_inner.CanUpdate}, depois={value}");
                                                _inner.CanUpdate = value;
                                            }
                                        }
                                    }

                                    public bool? CanDelete
                                    {
                                        get => _inner.CanDelete;
                                        set
                                        {
                                            if (_inner.CanDelete != value)
                                            {
                                                _logger.Info($"Propriedade CanDelete: antes={_inner.CanDelete}, depois={value}");
                                                _inner.CanDelete = value;
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