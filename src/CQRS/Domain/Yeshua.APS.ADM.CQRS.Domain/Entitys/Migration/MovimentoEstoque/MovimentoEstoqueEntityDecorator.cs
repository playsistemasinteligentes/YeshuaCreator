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
                    public static class MovimentoEstoqueTrackingFields
        {
            public const ulong Id = 1UL << 0;
            public const ulong ProdutoId = 1UL << 1;
            public const ulong OrderId = 1UL << 2;
            public const ulong Tipo = 1UL << 3;
            public const ulong TurnoId = 1UL << 4;
            public const ulong TurmaId = 1UL << 5;
            public const ulong Quantidade = 1UL << 6;
            public const ulong MOV_PESO_UNITARIO = 1UL << 7;
            public const ulong DataHoraCriacao = 1UL << 8;
            public const ulong DataHoraEmissao = 1UL << 9;
            public const ulong DiaTurma = 1UL << 10;
            public const ulong Lote = 1UL << 11;
            public const ulong SubLote = 1UL << 12;
            public const ulong MaquinaId = 1UL << 13;
            public const ulong USE_ID = 1UL << 14;
            public const ulong Observacao = 1UL << 15;
            public const ulong OcorrenciaId = 1UL << 16;
            public const ulong Armazem = 1UL << 17;
            public const ulong Endereco = 1UL << 18;
            public const ulong Estorno = 1UL << 19;
            public const ulong SequenciaTransformacao = 1UL << 20;
            public const ulong SequenciaRepeticao = 1UL << 21;
            public const ulong ObsOpParcial = 1UL << 22;
            public const ulong OcoIdOpParcial = 1UL << 23;
            public const ulong MOV_ID_INTEGRACAO = 1UL << 24;
            public const ulong MOV_ID_INTEGRACAO_ERP = 1UL << 25;
            public const ulong CAR_ID = 1UL << 26;
            public const ulong MOV_ID_DESTINO = 1UL << 27;
            public const ulong PRO_ID_DESTINO = 1UL << 28;
            public const ulong MOV_LOTE_DESTINO = 1UL << 29;
            public const ulong MOV_SUB_LOTE_DESTINO = 1UL << 30;
            public const ulong MOV_ID_ORIGEM = 1UL << 31;
            public const ulong PRO_ID_ORIGEM = 1UL << 32;
            public const ulong MOV_LOTE_ORIGEM = 1UL << 33;
            public const ulong MOV_SUB_LOTE_ORIGEM = 1UL << 34;
            public const ulong MOV_TYPE = 1UL << 35;
            public const ulong MOV_DOC = 1UL << 36;
            public const ulong MOV_APROVEITAMENTO = 1UL << 37;
            public const ulong MOV_RETIDO = 1UL << 38;
            public const ulong MOV_VINCOS_ONDULADEIRA = 1UL << 39;
            public const ulong BOL_ID = 1UL << 40;
            public const ulong ORD_ID_ORIGEM = 1UL << 41;
            public const ulong COR_SEQUENCIA = 1UL << 42;
            public const ulong VER_ID = 1UL << 43;
            public const ulong MOV_TIPO_CUSTO = 1UL << 44;
            public const ulong MOV_GRUPO_CONTABIL = 1UL << 45;
            public const ulong FOR_ID = 1UL << 46;
            public const ulong CLI_ID = 1UL << 47;
            public const ulong TenantID = 1UL << 48;
            public const ulong Deleted = 1UL << 49;
            public const ulong Changed = 1UL << 50;
            public const ulong UserId = 1UL << 51;
        }

        public partial class MovimentoEstoqueDecorator : IMovimentoEstoqueEntity
{

                        private readonly IMovimentoEstoqueEntity _inner;
                        private readonly Dominio.Interfaces.ILogger _logger;
                        private readonly ulong _trackingMask;
                        private readonly string _trackingTraceId;
                        private readonly string? _trackingOperation;
                        private readonly string? _trackingRecordId;
                        public MovimentoEstoqueDecorator(IMovimentoEstoqueEntity inner, Dominio.Interfaces.ILogger logger)
                            : this(inner, logger, null, 0UL)
                        {
                        }

                        public MovimentoEstoqueDecorator(
                            IMovimentoEstoqueEntity inner,
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
                                    public int Id
                                    {
                                        get => _inner.Id;
                                        set
                                        {
                                            if (_inner.Id != value)
                                            {
                                                _inner.Id = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Id) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Id", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ProdutoId
                                    {
                                        get => _inner.ProdutoId;
                                        set
                                        {
                                            if (_inner.ProdutoId != value)
                                            {
                                                _inner.ProdutoId = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.ProdutoId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "ProdutoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OrderId
                                    {
                                        get => _inner.OrderId;
                                        set
                                        {
                                            if (_inner.OrderId != value)
                                            {
                                                _inner.OrderId = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.OrderId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "OrderId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Tipo
                                    {
                                        get => _inner.Tipo;
                                        set
                                        {
                                            if (_inner.Tipo != value)
                                            {
                                                _inner.Tipo = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Tipo) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Tipo", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TurnoId
                                    {
                                        get => _inner.TurnoId;
                                        set
                                        {
                                            if (_inner.TurnoId != value)
                                            {
                                                _inner.TurnoId = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.TurnoId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "TurnoId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string TurmaId
                                    {
                                        get => _inner.TurmaId;
                                        set
                                        {
                                            if (_inner.TurmaId != value)
                                            {
                                                _inner.TurmaId = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.TurmaId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "TurmaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal Quantidade
                                    {
                                        get => _inner.Quantidade;
                                        set
                                        {
                                            if (_inner.Quantidade != value)
                                            {
                                                _inner.Quantidade = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Quantidade) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Quantidade", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public Decimal MOV_PESO_UNITARIO
                                    {
                                        get => _inner.MOV_PESO_UNITARIO;
                                        set
                                        {
                                            if (_inner.MOV_PESO_UNITARIO != value)
                                            {
                                                _inner.MOV_PESO_UNITARIO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_PESO_UNITARIO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_PESO_UNITARIO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime DataHoraCriacao
                                    {
                                        get => _inner.DataHoraCriacao;
                                        set
                                        {
                                            if (_inner.DataHoraCriacao != value)
                                            {
                                                _inner.DataHoraCriacao = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.DataHoraCriacao) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "DataHoraCriacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public DateTime? DataHoraEmissao
                                    {
                                        get => _inner.DataHoraEmissao;
                                        set
                                        {
                                            if (_inner.DataHoraEmissao != value)
                                            {
                                                _inner.DataHoraEmissao = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.DataHoraEmissao) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "DataHoraEmissao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string DiaTurma
                                    {
                                        get => _inner.DiaTurma;
                                        set
                                        {
                                            if (_inner.DiaTurma != value)
                                            {
                                                _inner.DiaTurma = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.DiaTurma) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "DiaTurma", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Lote
                                    {
                                        get => _inner.Lote;
                                        set
                                        {
                                            if (_inner.Lote != value)
                                            {
                                                _inner.Lote = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Lote) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Lote", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string SubLote
                                    {
                                        get => _inner.SubLote;
                                        set
                                        {
                                            if (_inner.SubLote != value)
                                            {
                                                _inner.SubLote = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.SubLote) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "SubLote", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MaquinaId
                                    {
                                        get => _inner.MaquinaId;
                                        set
                                        {
                                            if (_inner.MaquinaId != value)
                                            {
                                                _inner.MaquinaId = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MaquinaId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MaquinaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? USE_ID
                                    {
                                        get => _inner.USE_ID;
                                        set
                                        {
                                            if (_inner.USE_ID != value)
                                            {
                                                _inner.USE_ID = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.USE_ID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "USE_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Observacao) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Observacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OcorrenciaId
                                    {
                                        get => _inner.OcorrenciaId;
                                        set
                                        {
                                            if (_inner.OcorrenciaId != value)
                                            {
                                                _inner.OcorrenciaId = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.OcorrenciaId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "OcorrenciaId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Armazem
                                    {
                                        get => _inner.Armazem;
                                        set
                                        {
                                            if (_inner.Armazem != value)
                                            {
                                                _inner.Armazem = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Armazem) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Armazem", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Endereco) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Endereco", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string Estorno
                                    {
                                        get => _inner.Estorno;
                                        set
                                        {
                                            if (_inner.Estorno != value)
                                            {
                                                _inner.Estorno = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Estorno) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Estorno", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? SequenciaTransformacao
                                    {
                                        get => _inner.SequenciaTransformacao;
                                        set
                                        {
                                            if (_inner.SequenciaTransformacao != value)
                                            {
                                                _inner.SequenciaTransformacao = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.SequenciaTransformacao) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "SequenciaTransformacao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? SequenciaRepeticao
                                    {
                                        get => _inner.SequenciaRepeticao;
                                        set
                                        {
                                            if (_inner.SequenciaRepeticao != value)
                                            {
                                                _inner.SequenciaRepeticao = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.SequenciaRepeticao) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "SequenciaRepeticao", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ObsOpParcial
                                    {
                                        get => _inner.ObsOpParcial;
                                        set
                                        {
                                            if (_inner.ObsOpParcial != value)
                                            {
                                                _inner.ObsOpParcial = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.ObsOpParcial) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "ObsOpParcial", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string OcoIdOpParcial
                                    {
                                        get => _inner.OcoIdOpParcial;
                                        set
                                        {
                                            if (_inner.OcoIdOpParcial != value)
                                            {
                                                _inner.OcoIdOpParcial = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.OcoIdOpParcial) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "OcoIdOpParcial", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_ID_INTEGRACAO
                                    {
                                        get => _inner.MOV_ID_INTEGRACAO;
                                        set
                                        {
                                            if (_inner.MOV_ID_INTEGRACAO != value)
                                            {
                                                _inner.MOV_ID_INTEGRACAO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_ID_INTEGRACAO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_ID_INTEGRACAO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_ID_INTEGRACAO_ERP
                                    {
                                        get => _inner.MOV_ID_INTEGRACAO_ERP;
                                        set
                                        {
                                            if (_inner.MOV_ID_INTEGRACAO_ERP != value)
                                            {
                                                _inner.MOV_ID_INTEGRACAO_ERP = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_ID_INTEGRACAO_ERP) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_ID_INTEGRACAO_ERP", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CAR_ID
                                    {
                                        get => _inner.CAR_ID;
                                        set
                                        {
                                            if (_inner.CAR_ID != value)
                                            {
                                                _inner.CAR_ID = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.CAR_ID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "CAR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MOV_ID_DESTINO
                                    {
                                        get => _inner.MOV_ID_DESTINO;
                                        set
                                        {
                                            if (_inner.MOV_ID_DESTINO != value)
                                            {
                                                _inner.MOV_ID_DESTINO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_ID_DESTINO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_ID_DESTINO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID_DESTINO
                                    {
                                        get => _inner.PRO_ID_DESTINO;
                                        set
                                        {
                                            if (_inner.PRO_ID_DESTINO != value)
                                            {
                                                _inner.PRO_ID_DESTINO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.PRO_ID_DESTINO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "PRO_ID_DESTINO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_LOTE_DESTINO
                                    {
                                        get => _inner.MOV_LOTE_DESTINO;
                                        set
                                        {
                                            if (_inner.MOV_LOTE_DESTINO != value)
                                            {
                                                _inner.MOV_LOTE_DESTINO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_LOTE_DESTINO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_LOTE_DESTINO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_SUB_LOTE_DESTINO
                                    {
                                        get => _inner.MOV_SUB_LOTE_DESTINO;
                                        set
                                        {
                                            if (_inner.MOV_SUB_LOTE_DESTINO != value)
                                            {
                                                _inner.MOV_SUB_LOTE_DESTINO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_SUB_LOTE_DESTINO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_SUB_LOTE_DESTINO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MOV_ID_ORIGEM
                                    {
                                        get => _inner.MOV_ID_ORIGEM;
                                        set
                                        {
                                            if (_inner.MOV_ID_ORIGEM != value)
                                            {
                                                _inner.MOV_ID_ORIGEM = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_ID_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_ID_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string PRO_ID_ORIGEM
                                    {
                                        get => _inner.PRO_ID_ORIGEM;
                                        set
                                        {
                                            if (_inner.PRO_ID_ORIGEM != value)
                                            {
                                                _inner.PRO_ID_ORIGEM = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.PRO_ID_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "PRO_ID_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_LOTE_ORIGEM
                                    {
                                        get => _inner.MOV_LOTE_ORIGEM;
                                        set
                                        {
                                            if (_inner.MOV_LOTE_ORIGEM != value)
                                            {
                                                _inner.MOV_LOTE_ORIGEM = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_LOTE_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_LOTE_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_SUB_LOTE_ORIGEM
                                    {
                                        get => _inner.MOV_SUB_LOTE_ORIGEM;
                                        set
                                        {
                                            if (_inner.MOV_SUB_LOTE_ORIGEM != value)
                                            {
                                                _inner.MOV_SUB_LOTE_ORIGEM = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_SUB_LOTE_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_SUB_LOTE_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? MOV_TYPE
                                    {
                                        get => _inner.MOV_TYPE;
                                        set
                                        {
                                            if (_inner.MOV_TYPE != value)
                                            {
                                                _inner.MOV_TYPE = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_TYPE) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_TYPE", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_DOC
                                    {
                                        get => _inner.MOV_DOC;
                                        set
                                        {
                                            if (_inner.MOV_DOC != value)
                                            {
                                                _inner.MOV_DOC = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_DOC) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_DOC", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_APROVEITAMENTO
                                    {
                                        get => _inner.MOV_APROVEITAMENTO;
                                        set
                                        {
                                            if (_inner.MOV_APROVEITAMENTO != value)
                                            {
                                                _inner.MOV_APROVEITAMENTO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_APROVEITAMENTO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_APROVEITAMENTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_RETIDO
                                    {
                                        get => _inner.MOV_RETIDO;
                                        set
                                        {
                                            if (_inner.MOV_RETIDO != value)
                                            {
                                                _inner.MOV_RETIDO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_RETIDO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_RETIDO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_VINCOS_ONDULADEIRA
                                    {
                                        get => _inner.MOV_VINCOS_ONDULADEIRA;
                                        set
                                        {
                                            if (_inner.MOV_VINCOS_ONDULADEIRA != value)
                                            {
                                                _inner.MOV_VINCOS_ONDULADEIRA = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_VINCOS_ONDULADEIRA) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_VINCOS_ONDULADEIRA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string BOL_ID
                                    {
                                        get => _inner.BOL_ID;
                                        set
                                        {
                                            if (_inner.BOL_ID != value)
                                            {
                                                _inner.BOL_ID = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.BOL_ID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "BOL_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string ORD_ID_ORIGEM
                                    {
                                        get => _inner.ORD_ID_ORIGEM;
                                        set
                                        {
                                            if (_inner.ORD_ID_ORIGEM != value)
                                            {
                                                _inner.ORD_ID_ORIGEM = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.ORD_ID_ORIGEM) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "ORD_ID_ORIGEM", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? COR_SEQUENCIA
                                    {
                                        get => _inner.COR_SEQUENCIA;
                                        set
                                        {
                                            if (_inner.COR_SEQUENCIA != value)
                                            {
                                                _inner.COR_SEQUENCIA = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.COR_SEQUENCIA) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "COR_SEQUENCIA", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public int? VER_ID
                                    {
                                        get => _inner.VER_ID;
                                        set
                                        {
                                            if (_inner.VER_ID != value)
                                            {
                                                _inner.VER_ID = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.VER_ID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "VER_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_TIPO_CUSTO
                                    {
                                        get => _inner.MOV_TIPO_CUSTO;
                                        set
                                        {
                                            if (_inner.MOV_TIPO_CUSTO != value)
                                            {
                                                _inner.MOV_TIPO_CUSTO = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_TIPO_CUSTO) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_TIPO_CUSTO", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string MOV_GRUPO_CONTABIL
                                    {
                                        get => _inner.MOV_GRUPO_CONTABIL;
                                        set
                                        {
                                            if (_inner.MOV_GRUPO_CONTABIL != value)
                                            {
                                                _inner.MOV_GRUPO_CONTABIL = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.MOV_GRUPO_CONTABIL) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "MOV_GRUPO_CONTABIL", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string FOR_ID
                                    {
                                        get => _inner.FOR_ID;
                                        set
                                        {
                                            if (_inner.FOR_ID != value)
                                            {
                                                _inner.FOR_ID = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.FOR_ID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "FOR_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                                    public string CLI_ID
                                    {
                                        get => _inner.CLI_ID;
                                        set
                                        {
                                            if (_inner.CLI_ID != value)
                                            {
                                                _inner.CLI_ID = value;
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.CLI_ID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "CLI_ID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.TenantID) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "TenantID", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Deleted) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Deleted", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.Changed) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "Changed", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
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
                                                if ((_trackingMask & MovimentoEstoqueTrackingFields.UserId) != 0UL)
                                                    _logger.DomainValueChanged("MovimentoEstoque", "UserId", _trackingTraceId, _trackingOperation, _trackingRecordId, value);
                                            }
                                        }
                                    }

                        public bool isValidInsert() => _inner.isValidInsert();
                        public bool isValidUpdate() => _inner.isValidUpdate();
                        public bool isValidDelete() => _inner.isValidDelete();
                        public List<string> getErroMensagens() => _inner.getErroMensagens();
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration