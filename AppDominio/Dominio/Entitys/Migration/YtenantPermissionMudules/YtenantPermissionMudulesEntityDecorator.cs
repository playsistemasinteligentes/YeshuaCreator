
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YtenantPermissionMudulesDecorator : IYtenantPermissionMudulesEntity
{

                        private readonly IYtenantPermissionMudulesEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public YtenantPermissionMudulesDecorator(IYtenantPermissionMudulesEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string permissionModulesId
                                    {
                                        get => _inner.permissionModulesId;
                                        set
                                        {
                                            if (_inner.permissionModulesId != value)
                                            {
                                                _logger.Info($"Propriedade permissionModulesId: antes={_inner.permissionModulesId}, depois={value}");
                                                _inner.permissionModulesId = value;
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