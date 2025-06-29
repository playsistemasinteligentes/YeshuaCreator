
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_Tenant_ConfigurationDecorator : IY_Tenant_ConfigurationEntity
{

                        private readonly IY_Tenant_ConfigurationEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public Y_Tenant_ConfigurationDecorator(IY_Tenant_ConfigurationEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public int? AuditTrackerActived
                                    {
                                        get => _inner.AuditTrackerActived;
                                        set
                                        {
                                            if (_inner.AuditTrackerActived != value)
                                            {
                                                _logger.Info($"Propriedade AuditTrackerActived: antes={_inner.AuditTrackerActived}, depois={value}");
                                                _inner.AuditTrackerActived = value;
                                            }
                                        }
                                    }

                                    public int? AuditCRUDActived
                                    {
                                        get => _inner.AuditCRUDActived;
                                        set
                                        {
                                            if (_inner.AuditCRUDActived != value)
                                            {
                                                _logger.Info($"Propriedade AuditCRUDActived: antes={_inner.AuditCRUDActived}, depois={value}");
                                                _inner.AuditCRUDActived = value;
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

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration