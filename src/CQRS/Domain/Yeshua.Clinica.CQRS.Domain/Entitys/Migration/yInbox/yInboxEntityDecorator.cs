// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeEntityMigration
// </yeshua>


                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class yInboxDecorator : IyInboxEntity
{

                        private readonly IyInboxEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public yInboxDecorator(IyInboxEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string MessageId
                                    {
                                        get => _inner.MessageId;
                                        set
                                        {
                                            if (_inner.MessageId != value)
                                            {
                                                _logger.Info($"Propriedade MessageId: antes={_inner.MessageId}, depois={value}");
                                                _inner.MessageId = value;
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

                                    public string CorrelationId
                                    {
                                        get => _inner.CorrelationId;
                                        set
                                        {
                                            if (_inner.CorrelationId != value)
                                            {
                                                _logger.Info($"Propriedade CorrelationId: antes={_inner.CorrelationId}, depois={value}");
                                                _inner.CorrelationId = value;
                                            }
                                        }
                                    }

                                    public string Payload
                                    {
                                        get => _inner.Payload;
                                        set
                                        {
                                            if (_inner.Payload != value)
                                            {
                                                _logger.Info($"Propriedade Payload: antes={_inner.Payload}, depois={value}");
                                                _inner.Payload = value;
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

                                    public int RetryCount
                                    {
                                        get => _inner.RetryCount;
                                        set
                                        {
                                            if (_inner.RetryCount != value)
                                            {
                                                _logger.Info($"Propriedade RetryCount: antes={_inner.RetryCount}, depois={value}");
                                                _inner.RetryCount = value;
                                            }
                                        }
                                    }

                                    public string LastError
                                    {
                                        get => _inner.LastError;
                                        set
                                        {
                                            if (_inner.LastError != value)
                                            {
                                                _logger.Info($"Propriedade LastError: antes={_inner.LastError}, depois={value}");
                                                _inner.LastError = value;
                                            }
                                        }
                                    }

                                    public DateTime? ProcessingAt
                                    {
                                        get => _inner.ProcessingAt;
                                        set
                                        {
                                            if (_inner.ProcessingAt != value)
                                            {
                                                _logger.Info($"Propriedade ProcessingAt: antes={_inner.ProcessingAt}, depois={value}");
                                                _inner.ProcessingAt = value;
                                            }
                                        }
                                    }

                                    public DateTime? NextAttemptAt
                                    {
                                        get => _inner.NextAttemptAt;
                                        set
                                        {
                                            if (_inner.NextAttemptAt != value)
                                            {
                                                _logger.Info($"Propriedade NextAttemptAt: antes={_inner.NextAttemptAt}, depois={value}");
                                                _inner.NextAttemptAt = value;
                                            }
                                        }
                                    }

                                    public int? SagaId
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

                                    public int? SagaStepId
                                    {
                                        get => _inner.SagaStepId;
                                        set
                                        {
                                            if (_inner.SagaStepId != value)
                                            {
                                                _logger.Info($"Propriedade SagaStepId: antes={_inner.SagaStepId}, depois={value}");
                                                _inner.SagaStepId = value;
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