
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class Y_PerfilPermitionsDecorator : IY_PerfilPermitionsEntity
{

                        private readonly IY_PerfilPermitionsEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public Y_PerfilPermitionsDecorator(IY_PerfilPermitionsEntity inner, Dominio.Interfaces.ILogger logger)
                        {
                            _inner = inner;
                            _logger = logger;
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