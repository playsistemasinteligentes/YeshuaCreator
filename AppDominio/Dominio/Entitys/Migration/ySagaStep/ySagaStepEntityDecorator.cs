
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ySagaStepDecorator : IySagaStepEntity
{

                        private readonly IySagaStepEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public ySagaStepDecorator(IySagaStepEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public int SagaId
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

                                    public string Key
                                    {
                                        get => _inner.Key;
                                        set
                                        {
                                            if (_inner.Key != value)
                                            {
                                                _logger.Info($"Propriedade Key: antes={_inner.Key}, depois={value}");
                                                _inner.Key = value;
                                            }
                                        }
                                    }

                                    public int Order
                                    {
                                        get => _inner.Order;
                                        set
                                        {
                                            if (_inner.Order != value)
                                            {
                                                _logger.Info($"Propriedade Order: antes={_inner.Order}, depois={value}");
                                                _inner.Order = value;
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

                                    public int ExecutionCount
                                    {
                                        get => _inner.ExecutionCount;
                                        set
                                        {
                                            if (_inner.ExecutionCount != value)
                                            {
                                                _logger.Info($"Propriedade ExecutionCount: antes={_inner.ExecutionCount}, depois={value}");
                                                _inner.ExecutionCount = value;
                                            }
                                        }
                                    }

                                    public DateTime? LastExecutionAt
                                    {
                                        get => _inner.LastExecutionAt;
                                        set
                                        {
                                            if (_inner.LastExecutionAt != value)
                                            {
                                                _logger.Info($"Propriedade LastExecutionAt: antes={_inner.LastExecutionAt}, depois={value}");
                                                _inner.LastExecutionAt = value;
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

                                    public string ErrorMessage
                                    {
                                        get => _inner.ErrorMessage;
                                        set
                                        {
                                            if (_inner.ErrorMessage != value)
                                            {
                                                _logger.Info($"Propriedade ErrorMessage: antes={_inner.ErrorMessage}, depois={value}");
                                                _inner.ErrorMessage = value;
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