
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

                                    public string EmailAdress
                                    {
                                        get => _inner.EmailAdress;
                                        set
                                        {
                                            if (_inner.EmailAdress != value)
                                            {
                                                _logger.Info($"Propriedade EmailAdress: antes={_inner.EmailAdress}, depois={value}");
                                                _inner.EmailAdress = value;
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