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
                    public static class ClienteTrackingFields
        {
            public const ulong CLI_ID = 1UL << 0;
            public const ulong CLI_NOME = 1UL << 1;
            public const ulong CLI_FONE = 1UL << 2;
            public const ulong CLI_OBS = 1UL << 3;
            public const ulong CLI_ENDERECO_ENTREGA = 1UL << 4;
            public const ulong CLI_CPF_CNPJ = 1UL << 5;
            public const ulong CLI_BAIRRO_ENTREGA = 1UL << 6;
            public const ulong CLI_CEP_ENTREGA = 1UL << 7;
            public const ulong CLI_EMAIL = 1UL << 8;
            public const ulong CLI_INTEGRACAO = 1UL << 9;
            public const ulong MUN_ID_ENTREGA = 1UL << 10;
            public const ulong CLI_TRANSLADO = 1UL << 11;
            public const ulong CLI_REGIAO_ENTREGA = 1UL << 12;
            public const ulong CLI_EXIGENTE_NA_IMPRESSAO = 1UL << 13;
            public const ulong CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO = 1UL << 14;
            public const ulong CLI_TEMPO_DESCARREGAMENTO_UNITARIO = 1UL << 15;
            public const ulong CLI_PERCENTUAL_JANELA_EMBARQUE = 1UL << 16;
            public const ulong REP_ID = 1UL << 17;
            public const ulong CLI_RAZAO_SOCIAL = 1UL << 18;
            public const ulong CLI_EMAIL_MONITORAMENTO_TRANSPORTE = 1UL << 19;
            public const ulong CLI_CONTATO = 1UL << 20;
            public const ulong CLI_SETOR = 1UL << 21;
            public const ulong SEG_ID = 1UL << 22;
            public const ulong CLI_TIPO = 1UL << 23;
            public const ulong CLI_INTEGRACAO_ERP = 1UL << 24;
            public const ulong CLI_LATITUDE_ENTREGA = 1UL << 25;
            public const ulong CLI_LONGITUDE_ENTREGA = 1UL << 26;
            public const ulong TenantID = 1UL << 27;
            public const ulong Deleted = 1UL << 28;
            public const ulong Changed = 1UL << 29;
            public const ulong UserId = 1UL << 30;
        }

        public partial class ClienteDecorator : IClienteEntity
{

                        private readonly IClienteEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public ClienteDecorator(IClienteEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public ClienteDecorator(
                            IClienteEntity inner,
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
                                    public string CLI_ID
                                    {
                                        get => _inner.CLI_ID;
                                        set
                                        {
                                            if (_inner.CLI_ID != value)
                                            {
                                                _inner.CLI_ID = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_NOME
                                    {
                                        get => _inner.CLI_NOME;
                                        set
                                        {
                                            if (_inner.CLI_NOME != value)
                                            {
                                                _inner.CLI_NOME = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_NOME) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_NOME", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_FONE
                                    {
                                        get => _inner.CLI_FONE;
                                        set
                                        {
                                            if (_inner.CLI_FONE != value)
                                            {
                                                _inner.CLI_FONE = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_FONE) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_FONE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_OBS
                                    {
                                        get => _inner.CLI_OBS;
                                        set
                                        {
                                            if (_inner.CLI_OBS != value)
                                            {
                                                _inner.CLI_OBS = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_OBS) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_OBS", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_ENDERECO_ENTREGA
                                    {
                                        get => _inner.CLI_ENDERECO_ENTREGA;
                                        set
                                        {
                                            if (_inner.CLI_ENDERECO_ENTREGA != value)
                                            {
                                                _inner.CLI_ENDERECO_ENTREGA = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_ENDERECO_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_ENDERECO_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_CPF_CNPJ
                                    {
                                        get => _inner.CLI_CPF_CNPJ;
                                        set
                                        {
                                            if (_inner.CLI_CPF_CNPJ != value)
                                            {
                                                _inner.CLI_CPF_CNPJ = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_CPF_CNPJ) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_CPF_CNPJ", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_BAIRRO_ENTREGA
                                    {
                                        get => _inner.CLI_BAIRRO_ENTREGA;
                                        set
                                        {
                                            if (_inner.CLI_BAIRRO_ENTREGA != value)
                                            {
                                                _inner.CLI_BAIRRO_ENTREGA = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_BAIRRO_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_BAIRRO_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_CEP_ENTREGA
                                    {
                                        get => _inner.CLI_CEP_ENTREGA;
                                        set
                                        {
                                            if (_inner.CLI_CEP_ENTREGA != value)
                                            {
                                                _inner.CLI_CEP_ENTREGA = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_CEP_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_CEP_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_EMAIL
                                    {
                                        get => _inner.CLI_EMAIL;
                                        set
                                        {
                                            if (_inner.CLI_EMAIL != value)
                                            {
                                                _inner.CLI_EMAIL = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_EMAIL) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_EMAIL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_INTEGRACAO
                                    {
                                        get => _inner.CLI_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.CLI_INTEGRACAO != value)
                                            {
                                                _inner.CLI_INTEGRACAO = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MUN_ID_ENTREGA
                                    {
                                        get => _inner.MUN_ID_ENTREGA;
                                        set
                                        {
                                            if (_inner.MUN_ID_ENTREGA != value)
                                            {
                                                _inner.MUN_ID_ENTREGA = value;
                                                if ((_trackingMask & ClienteTrackingFields.MUN_ID_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "MUN_ID_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CLI_TRANSLADO
                                    {
                                        get => _inner.CLI_TRANSLADO;
                                        set
                                        {
                                            if (_inner.CLI_TRANSLADO != value)
                                            {
                                                _inner.CLI_TRANSLADO = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_TRANSLADO) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_TRANSLADO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_REGIAO_ENTREGA
                                    {
                                        get => _inner.CLI_REGIAO_ENTREGA;
                                        set
                                        {
                                            if (_inner.CLI_REGIAO_ENTREGA != value)
                                            {
                                                _inner.CLI_REGIAO_ENTREGA = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_REGIAO_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_REGIAO_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? CLI_EXIGENTE_NA_IMPRESSAO
                                    {
                                        get => _inner.CLI_EXIGENTE_NA_IMPRESSAO;
                                        set
                                        {
                                            if (_inner.CLI_EXIGENTE_NA_IMPRESSAO != value)
                                            {
                                                _inner.CLI_EXIGENTE_NA_IMPRESSAO = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_EXIGENTE_NA_IMPRESSAO) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_EXIGENTE_NA_IMPRESSAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO
                                    {
                                        get => _inner.CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO;
                                        set
                                        {
                                            if (_inner.CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO != value)
                                            {
                                                _inner.CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_TEMPO_MEDIO_ESPERA_DE_DESCARREGAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CLI_TEMPO_DESCARREGAMENTO_UNITARIO
                                    {
                                        get => _inner.CLI_TEMPO_DESCARREGAMENTO_UNITARIO;
                                        set
                                        {
                                            if (_inner.CLI_TEMPO_DESCARREGAMENTO_UNITARIO != value)
                                            {
                                                _inner.CLI_TEMPO_DESCARREGAMENTO_UNITARIO = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_TEMPO_DESCARREGAMENTO_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_TEMPO_DESCARREGAMENTO_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CLI_PERCENTUAL_JANELA_EMBARQUE
                                    {
                                        get => _inner.CLI_PERCENTUAL_JANELA_EMBARQUE;
                                        set
                                        {
                                            if (_inner.CLI_PERCENTUAL_JANELA_EMBARQUE != value)
                                            {
                                                _inner.CLI_PERCENTUAL_JANELA_EMBARQUE = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_PERCENTUAL_JANELA_EMBARQUE) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_PERCENTUAL_JANELA_EMBARQUE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string REP_ID
                                    {
                                        get => _inner.REP_ID;
                                        set
                                        {
                                            if (_inner.REP_ID != value)
                                            {
                                                _inner.REP_ID = value;
                                                if ((_trackingMask & ClienteTrackingFields.REP_ID) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "REP_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_RAZAO_SOCIAL
                                    {
                                        get => _inner.CLI_RAZAO_SOCIAL;
                                        set
                                        {
                                            if (_inner.CLI_RAZAO_SOCIAL != value)
                                            {
                                                _inner.CLI_RAZAO_SOCIAL = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_RAZAO_SOCIAL) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_RAZAO_SOCIAL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_EMAIL_MONITORAMENTO_TRANSPORTE
                                    {
                                        get => _inner.CLI_EMAIL_MONITORAMENTO_TRANSPORTE;
                                        set
                                        {
                                            if (_inner.CLI_EMAIL_MONITORAMENTO_TRANSPORTE != value)
                                            {
                                                _inner.CLI_EMAIL_MONITORAMENTO_TRANSPORTE = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_EMAIL_MONITORAMENTO_TRANSPORTE) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_EMAIL_MONITORAMENTO_TRANSPORTE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_CONTATO
                                    {
                                        get => _inner.CLI_CONTATO;
                                        set
                                        {
                                            if (_inner.CLI_CONTATO != value)
                                            {
                                                _inner.CLI_CONTATO = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_CONTATO) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_CONTATO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_SETOR
                                    {
                                        get => _inner.CLI_SETOR;
                                        set
                                        {
                                            if (_inner.CLI_SETOR != value)
                                            {
                                                _inner.CLI_SETOR = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_SETOR) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_SETOR", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SEG_ID
                                    {
                                        get => _inner.SEG_ID;
                                        set
                                        {
                                            if (_inner.SEG_ID != value)
                                            {
                                                _inner.SEG_ID = value;
                                                if ((_trackingMask & ClienteTrackingFields.SEG_ID) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "SEG_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_TIPO
                                    {
                                        get => _inner.CLI_TIPO;
                                        set
                                        {
                                            if (_inner.CLI_TIPO != value)
                                            {
                                                _inner.CLI_TIPO = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_TIPO) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_TIPO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_INTEGRACAO_ERP
                                    {
                                        get => _inner.CLI_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.CLI_INTEGRACAO_ERP != value)
                                            {
                                                _inner.CLI_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CLI_LATITUDE_ENTREGA
                                    {
                                        get => _inner.CLI_LATITUDE_ENTREGA;
                                        set
                                        {
                                            if (_inner.CLI_LATITUDE_ENTREGA != value)
                                            {
                                                _inner.CLI_LATITUDE_ENTREGA = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_LATITUDE_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_LATITUDE_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal? CLI_LONGITUDE_ENTREGA
                                    {
                                        get => _inner.CLI_LONGITUDE_ENTREGA;
                                        set
                                        {
                                            if (_inner.CLI_LONGITUDE_ENTREGA != value)
                                            {
                                                _inner.CLI_LONGITUDE_ENTREGA = value;
                                                if ((_trackingMask & ClienteTrackingFields.CLI_LONGITUDE_ENTREGA) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "CLI_LONGITUDE_ENTREGA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClienteTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClienteTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClienteTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & ClienteTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("Cliente", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration