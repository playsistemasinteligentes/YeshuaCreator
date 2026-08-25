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
                    public static class PacienteTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong Nome = 1UL << 1;
            public const ulong Telefone = 1UL << 2;
            public const ulong DataNascimento = 1UL << 3;
            public const ulong Genero = 1UL << 4;
            public const ulong Escolaridade = 1UL << 5;
            public const ulong Profissao = 1UL << 6;
            public const ulong Endereco = 1UL << 7;
            public const ulong NomeResponsavel = 1UL << 8;
            public const ulong TelefoneResponsavel = 1UL << 9;
            public const ulong Observacao = 1UL << 10;
            public const ulong TenantID = 1UL << 11;
            public const ulong Deleted = 1UL << 12;
            public const ulong Changed = 1UL << 13;
            public const ulong UserId = 1UL << 14;
        }

        public partial class PacienteDecorator : IPacienteEntity
{

                        private readonly IPacienteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public PacienteDecorator(IPacienteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public PacienteDecorator(
                            IPacienteEntity inner,
                            Dominio.Interfaces.ILogger logger,
                            Dominio.Patterns.Domain.DomainOperationContext? context,
                            ulong trackingMask)
                        {
                            _inner = inner;
                            _logger = logger;
                            _trackingMask = trackingMask;
                            _trackingTraceId = context?.TraceId ?? string.Empty;
                            _trackingOperation = context?.Intent;
                            _trackingRecordId = context?.RecordId;
                        }
                                    public int? Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & PacienteTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                _inner.Nome = value;
                                                if ((_trackingMask & PacienteTrackingFields.Nome) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Nome", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                _inner.Telefone = value;
                                                if ((_trackingMask & PacienteTrackingFields.Telefone) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Telefone", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? DataNascimento
                                    {
                                        get => _inner.DataNascimento;
                                        set
                                        {
                                            if (_inner.DataNascimento != value)
                                            {
                                                _inner.DataNascimento = value;
                                                if ((_trackingMask & PacienteTrackingFields.DataNascimento) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "DataNascimento", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? Genero
                                    {
                                        get => _inner.Genero;
                                        set
                                        {
                                            if (_inner.Genero != value)
                                            {
                                                _inner.Genero = value;
                                                if ((_trackingMask & PacienteTrackingFields.Genero) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Genero", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Escolaridade
                                    {
                                        get => _inner.Escolaridade;
                                        set
                                        {
                                            if (_inner.Escolaridade != value)
                                            {
                                                _inner.Escolaridade = value;
                                                if ((_trackingMask & PacienteTrackingFields.Escolaridade) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Escolaridade", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Profissao
                                    {
                                        get => _inner.Profissao;
                                        set
                                        {
                                            if (_inner.Profissao != value)
                                            {
                                                _inner.Profissao = value;
                                                if ((_trackingMask & PacienteTrackingFields.Profissao) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Profissao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Endereco
                                    {
                                        get => _inner.Endereco;
                                        set
                                        {
                                            if (_inner.Endereco != value)
                                            {
                                                _inner.Endereco = value;
                                                if ((_trackingMask & PacienteTrackingFields.Endereco) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Endereco", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string NomeResponsavel
                                    {
                                        get => _inner.NomeResponsavel;
                                        set
                                        {
                                            if (_inner.NomeResponsavel != value)
                                            {
                                                _inner.NomeResponsavel = value;
                                                if ((_trackingMask & PacienteTrackingFields.NomeResponsavel) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "NomeResponsavel", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TelefoneResponsavel
                                    {
                                        get => _inner.TelefoneResponsavel;
                                        set
                                        {
                                            if (_inner.TelefoneResponsavel != value)
                                            {
                                                _inner.TelefoneResponsavel = value;
                                                if ((_trackingMask & PacienteTrackingFields.TelefoneResponsavel) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "TelefoneResponsavel", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Observacao
                                    {
                                        get => _inner.Observacao;
                                        set
                                        {
                                            if (_inner.Observacao != value)
                                            {
                                                _inner.Observacao = value;
                                                if ((_trackingMask & PacienteTrackingFields.Observacao) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Observacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                _inner.TenantID = value;
                                                if ((_trackingMask & PacienteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                _inner.Deleted = value;
                                                if ((_trackingMask & PacienteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                _inner.Changed = value;
                                                if ((_trackingMask & PacienteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                _inner.UserId = value;
                                                if ((_trackingMask & PacienteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Paciente", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration