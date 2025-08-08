
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public partial class ProfissionalDecorator : IProfissionalEntity
{

                        private readonly IProfissionalEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        public ProfissionalDecorator(IProfissionalEntity inner, Dominio.Interfaces.ILogger logger)
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

                                    public string Nome
                                    {
                                        get => _inner.Nome;
                                        set
                                        {
                                            if (_inner.Nome != value)
                                            {
                                                _logger.Info($"Propriedade Nome: antes={_inner.Nome}, depois={value}");
                                                _inner.Nome = value;
                                            }
                                        }
                                    }

                                    public int? EspecialidadeId
                                    {
                                        get => _inner.EspecialidadeId;
                                        set
                                        {
                                            if (_inner.EspecialidadeId != value)
                                            {
                                                _logger.Info($"Propriedade EspecialidadeId: antes={_inner.EspecialidadeId}, depois={value}");
                                                _inner.EspecialidadeId = value;
                                            }
                                        }
                                    }

                                    public string Telefone
                                    {
                                        get => _inner.Telefone;
                                        set
                                        {
                                            if (_inner.Telefone != value)
                                            {
                                                _logger.Info($"Propriedade Telefone: antes={_inner.Telefone}, depois={value}");
                                                _inner.Telefone = value;
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