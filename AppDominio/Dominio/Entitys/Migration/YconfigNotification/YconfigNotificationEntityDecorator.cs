
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class YconfigNotificationDecorator : IYconfigNotificationEntity
{

                        private readonly IYconfigNotificationEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public YconfigNotificationDecorator(IYconfigNotificationEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string EmailSmtpClient
                                    {
                                        get => _inner.EmailSmtpClient;
                                        set
                                        {
                                            if (_inner.EmailSmtpClient != value)
                                            {
                                                _logger.Info($"Propriedade EmailSmtpClient: antes={_inner.EmailSmtpClient}, depois={value}");
                                                _inner.EmailSmtpClient = value;
                                            }
                                        }
                                    }

                                    public int? EmailPort
                                    {
                                        get => _inner.EmailPort;
                                        set
                                        {
                                            if (_inner.EmailPort != value)
                                            {
                                                _logger.Info($"Propriedade EmailPort: antes={_inner.EmailPort}, depois={value}");
                                                _inner.EmailPort = value;
                                            }
                                        }
                                    }

                                    public string EmailUserName
                                    {
                                        get => _inner.EmailUserName;
                                        set
                                        {
                                            if (_inner.EmailUserName != value)
                                            {
                                                _logger.Info($"Propriedade EmailUserName: antes={_inner.EmailUserName}, depois={value}");
                                                _inner.EmailUserName = value;
                                            }
                                        }
                                    }

                                    public string EmailPassword
                                    {
                                        get => _inner.EmailPassword;
                                        set
                                        {
                                            if (_inner.EmailPassword != value)
                                            {
                                                _logger.Info($"Propriedade EmailPassword: antes={_inner.EmailPassword}, depois={value}");
                                                _inner.EmailPassword = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration