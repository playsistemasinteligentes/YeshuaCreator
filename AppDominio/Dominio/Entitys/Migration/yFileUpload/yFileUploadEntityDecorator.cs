
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yFileUploadDecorator : IyFileUploadEntity
{

                        private readonly IyFileUploadEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public yFileUploadDecorator(IyFileUploadEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string Type
                                    {
                                        get => _inner.Type;
                                        set
                                        {
                                            if (_inner.Type != value)
                                            {
                                                _logger.Info($"Propriedade Type: antes={_inner.Type}, depois={value}");
                                                _inner.Type = value;
                                            }
                                        }
                                    }

                                    public int Status
                                    {
                                        get => _inner.Status;
                                        set
                                        {
                                            if (_inner.Status != value)
                                            {
                                                _logger.Info($"Propriedade Status: antes={_inner.Status}, depois={value}");
                                                _inner.Status = value;
                                            }
                                        }
                                    }

                                    public string FilePath
                                    {
                                        get => _inner.FilePath;
                                        set
                                        {
                                            if (_inner.FilePath != value)
                                            {
                                                _logger.Info($"Propriedade FilePath: antes={_inner.FilePath}, depois={value}");
                                                _inner.FilePath = value;
                                            }
                                        }
                                    }

                                    public long? FileSize
                                    {
                                        get => _inner.FileSize;
                                        set
                                        {
                                            if (_inner.FileSize != value)
                                            {
                                                _logger.Info($"Propriedade FileSize: antes={_inner.FileSize}, depois={value}");
                                                _inner.FileSize = value;
                                            }
                                        }
                                    }

                                    public string EntityType
                                    {
                                        get => _inner.EntityType;
                                        set
                                        {
                                            if (_inner.EntityType != value)
                                            {
                                                _logger.Info($"Propriedade EntityType: antes={_inner.EntityType}, depois={value}");
                                                _inner.EntityType = value;
                                            }
                                        }
                                    }

                                    public string EntityId
                                    {
                                        get => _inner.EntityId;
                                        set
                                        {
                                            if (_inner.EntityId != value)
                                            {
                                                _logger.Info($"Propriedade EntityId: antes={_inner.EntityId}, depois={value}");
                                                _inner.EntityId = value;
                                            }
                                        }
                                    }

                                    public DateTime CreatedAt
                                    {
                                        get => _inner.CreatedAt;
                                        set
                                        {
                                            if (_inner.CreatedAt != value)
                                            {
                                                _logger.Info($"Propriedade CreatedAt: antes={_inner.CreatedAt}, depois={value}");
                                                _inner.CreatedAt = value;
                                            }
                                        }
                                    }

                                    public DateTime? CompletedAt
                                    {
                                        get => _inner.CompletedAt;
                                        set
                                        {
                                            if (_inner.CompletedAt != value)
                                            {
                                                _logger.Info($"Propriedade CompletedAt: antes={_inner.CompletedAt}, depois={value}");
                                                _inner.CompletedAt = value;
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