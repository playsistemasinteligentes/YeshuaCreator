
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_UserPermitionsDecorator : IY_UserPermitionsEntity
{

                        private readonly IY_UserPermitionsEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public Y_UserPermitionsDecorator(IY_UserPermitionsEntity inner, Dominio.Interfaces.ILogger logger)
                        {
                            _inner = inner;
                            _logger = logger;
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

                                    public string PermitionsId
                                    {
                                        get => _inner.PermitionsId;
                                        set
                                        {
                                            if (_inner.PermitionsId != value)
                                            {
                                                _logger.Info($"Propriedade PermitionsId: antes={_inner.PermitionsId}, depois={value}");
                                                _inner.PermitionsId = value;
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration