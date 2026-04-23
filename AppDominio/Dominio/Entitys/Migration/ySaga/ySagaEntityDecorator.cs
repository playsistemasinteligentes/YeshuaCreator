
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ySagaDecorator : IySagaEntity
{

                        private readonly IySagaEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public ySagaDecorator(IySagaEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string SagaId
                                    {
                                        get => _inner.SagaId;
                                        set
                                        {
                                            if (_inner.SagaId != value)
                                            {
                                                _logger.Info($"Propriedade SagaId: antes={_inner.SagaId}, depois={value}");
                                                _inner.SagaId = value;
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

                                    public string KeyCurrentStep
                                    {
                                        get => _inner.KeyCurrentStep;
                                        set
                                        {
                                            if (_inner.KeyCurrentStep != value)
                                            {
                                                _logger.Info($"Propriedade KeyCurrentStep: antes={_inner.KeyCurrentStep}, depois={value}");
                                                _inner.KeyCurrentStep = value;
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

                                    public DateTime? NextExecutionAt
                                    {
                                        get => _inner.NextExecutionAt;
                                        set
                                        {
                                            if (_inner.NextExecutionAt != value)
                                            {
                                                _logger.Info($"Propriedade NextExecutionAt: antes={_inner.NextExecutionAt}, depois={value}");
                                                _inner.NextExecutionAt = value;
                                            }
                                        }
                                    }

                                    public DateTime? LockedAt
                                    {
                                        get => _inner.LockedAt;
                                        set
                                        {
                                            if (_inner.LockedAt != value)
                                            {
                                                _logger.Info($"Propriedade LockedAt: antes={_inner.LockedAt}, depois={value}");
                                                _inner.LockedAt = value;
                                            }
                                        }
                                    }

                                    public string LockedBy
                                    {
                                        get => _inner.LockedBy;
                                        set
                                        {
                                            if (_inner.LockedBy != value)
                                            {
                                                _logger.Info($"Propriedade LockedBy: antes={_inner.LockedBy}, depois={value}");
                                                _inner.LockedBy = value;
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