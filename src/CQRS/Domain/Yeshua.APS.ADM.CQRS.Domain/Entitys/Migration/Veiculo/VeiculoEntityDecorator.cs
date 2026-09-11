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
                    public static class VeiculoTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong VEI_PLACA = 1UL << 1;
            public const ulong VEI_UF = 1UL << 2;
            public const ulong TIP_ID = 1UL << 3;
            public const ulong VEI_CAPACIDADE_M3 = 1UL << 4;
            public const ulong VEI_CAPACIDADE_LARGURA = 1UL << 5;
            public const ulong VEI_CAPACIDADE_COMPRIMENTO = 1UL << 6;
            public const ulong VEI_CAPACIDADE_ALTURA = 1UL << 7;
            public const ulong VEI_MODELO = 1UL << 8;
            public const ulong VEI_NOME_MOTORISTA = 1UL << 9;
            public const ulong VEI_DADOS_CONTATO = 1UL << 10;
            public const ulong VEI_CPF_MOTORISTA = 1UL << 11;
            public const ulong TCA_ID = 1UL << 12;
            public const ulong VEI_EMISSAO = 1UL << 13;
            public const ulong VEI_VENCIMENTO = 1UL << 14;
            public const ulong VEI_STATUS = 1UL << 15;
            public const ulong TenantID = 1UL << 16;
            public const ulong Deleted = 1UL << 17;
            public const ulong Changed = 1UL << 18;
            public const ulong UserId = 1UL << 19;
        }

        public partial class VeiculoDecorator : IVeiculoEntity
{

                        private readonly IVeiculoEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public VeiculoDecorator(IVeiculoEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public VeiculoDecorator(
                            IVeiculoEntity inner,
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
                                                if ((_trackingMask & VeiculoTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VEI_PLACA
                                    {
                                        get => _inner.VEI_PLACA;
                                        set
                                        {
                                            if (_inner.VEI_PLACA != value)
                                            {
                                                _inner.VEI_PLACA = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_PLACA) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_PLACA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VEI_UF
                                    {
                                        get => _inner.VEI_UF;
                                        set
                                        {
                                            if (_inner.VEI_UF != value)
                                            {
                                                _inner.VEI_UF = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_UF) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_UF", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int TIP_ID
                                    {
                                        get => _inner.TIP_ID;
                                        set
                                        {
                                            if (_inner.TIP_ID != value)
                                            {
                                                _inner.TIP_ID = value;
                                                if ((_trackingMask & VeiculoTrackingFields.TIP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "TIP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? VEI_CAPACIDADE_M3
                                    {
                                        get => _inner.VEI_CAPACIDADE_M3;
                                        set
                                        {
                                            if (_inner.VEI_CAPACIDADE_M3 != value)
                                            {
                                                _inner.VEI_CAPACIDADE_M3 = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_CAPACIDADE_M3) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_CAPACIDADE_M3", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? VEI_CAPACIDADE_LARGURA
                                    {
                                        get => _inner.VEI_CAPACIDADE_LARGURA;
                                        set
                                        {
                                            if (_inner.VEI_CAPACIDADE_LARGURA != value)
                                            {
                                                _inner.VEI_CAPACIDADE_LARGURA = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_CAPACIDADE_LARGURA) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_CAPACIDADE_LARGURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? VEI_CAPACIDADE_COMPRIMENTO
                                    {
                                        get => _inner.VEI_CAPACIDADE_COMPRIMENTO;
                                        set
                                        {
                                            if (_inner.VEI_CAPACIDADE_COMPRIMENTO != value)
                                            {
                                                _inner.VEI_CAPACIDADE_COMPRIMENTO = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_CAPACIDADE_COMPRIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_CAPACIDADE_COMPRIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? VEI_CAPACIDADE_ALTURA
                                    {
                                        get => _inner.VEI_CAPACIDADE_ALTURA;
                                        set
                                        {
                                            if (_inner.VEI_CAPACIDADE_ALTURA != value)
                                            {
                                                _inner.VEI_CAPACIDADE_ALTURA = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_CAPACIDADE_ALTURA) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_CAPACIDADE_ALTURA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VEI_MODELO
                                    {
                                        get => _inner.VEI_MODELO;
                                        set
                                        {
                                            if (_inner.VEI_MODELO != value)
                                            {
                                                _inner.VEI_MODELO = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_MODELO) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_MODELO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VEI_NOME_MOTORISTA
                                    {
                                        get => _inner.VEI_NOME_MOTORISTA;
                                        set
                                        {
                                            if (_inner.VEI_NOME_MOTORISTA != value)
                                            {
                                                _inner.VEI_NOME_MOTORISTA = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_NOME_MOTORISTA) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_NOME_MOTORISTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VEI_DADOS_CONTATO
                                    {
                                        get => _inner.VEI_DADOS_CONTATO;
                                        set
                                        {
                                            if (_inner.VEI_DADOS_CONTATO != value)
                                            {
                                                _inner.VEI_DADOS_CONTATO = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_DADOS_CONTATO) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_DADOS_CONTATO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VEI_CPF_MOTORISTA
                                    {
                                        get => _inner.VEI_CPF_MOTORISTA;
                                        set
                                        {
                                            if (_inner.VEI_CPF_MOTORISTA != value)
                                            {
                                                _inner.VEI_CPF_MOTORISTA = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_CPF_MOTORISTA) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_CPF_MOTORISTA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TCA_ID
                                    {
                                        get => _inner.TCA_ID;
                                        set
                                        {
                                            if (_inner.TCA_ID != value)
                                            {
                                                _inner.TCA_ID = value;
                                                if ((_trackingMask & VeiculoTrackingFields.TCA_ID) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "TCA_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? VEI_EMISSAO
                                    {
                                        get => _inner.VEI_EMISSAO;
                                        set
                                        {
                                            if (_inner.VEI_EMISSAO != value)
                                            {
                                                _inner.VEI_EMISSAO = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_EMISSAO) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_EMISSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? VEI_VENCIMENTO
                                    {
                                        get => _inner.VEI_VENCIMENTO;
                                        set
                                        {
                                            if (_inner.VEI_VENCIMENTO != value)
                                            {
                                                _inner.VEI_VENCIMENTO = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_VENCIMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_VENCIMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string VEI_STATUS
                                    {
                                        get => _inner.VEI_STATUS;
                                        set
                                        {
                                            if (_inner.VEI_STATUS != value)
                                            {
                                                _inner.VEI_STATUS = value;
                                                if ((_trackingMask & VeiculoTrackingFields.VEI_STATUS) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "VEI_STATUS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VeiculoTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VeiculoTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VeiculoTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & VeiculoTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Veiculo", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration