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
                    public partial class RoteiroPedidoEntity : IRoteiroPedidoEntity
{
    public string PedidoId { get; set; }
    public string MaquinaId { get; set; }
    public string ProdutoId { get; set; }
    public int SequenciaTransformacao { get; set; }
    public string StatusCadastro { get; set; }
    public string TipoPlanejamento { get; set; }
    public int CalendarioId { get; set; }
    public Decimal? HierarquiaSequenciaTransformacao { get; set; }
    public int? ProximaSequenciaTransformacao { get; set; }
    public Decimal? Performance { get; set; }
    public Decimal? TempoSetup { get; set; }
    public Decimal? TempoSetupAjuste { get; set; }
    public Decimal? PecasPorPulso { get; set; }
    public Decimal? PrioridadeInformada { get; set; }
    public string Status { get; set; }
    public string Operacoes { get; set; }
    public string ExcecaoOperacoes { get; set; }
    public string LinhaDireta { get; set; }
    public int? AvaliaCusto { get; set; }
    public Decimal? PercentualInicioPassoAnterior { get; set; }
    public Decimal? MaquinaLarguraUtil { get; set; }
    public Decimal? GrupoTipo { get; set; }
    public Decimal GrupoPerformanceMetroLinear { get; set; }
    private List<string> _erroMensagem = null;
 internal RoteiroPedidoEntity(string pedidoid, string maquinaid, string produtoid, int sequenciatransformacao, string statuscadastro, string tipoplanejamento, int calendarioid, Decimal? hierarquiasequenciatransformacao, int? proximasequenciatransformacao, Decimal? performance, Decimal? temposetup, Decimal? temposetupajuste, Decimal? pecasporpulso, Decimal? prioridadeinformada, string status, string operacoes, string excecaooperacoes, string linhadireta, int? avaliacusto, Decimal? percentualiniciopassoanterior, Decimal? maquinalargurautil, Decimal? grupotipo, Decimal grupoperformancemetrolinear ){
 PedidoId = pedidoid; 
 MaquinaId = maquinaid; 
 ProdutoId = produtoid; 
 SequenciaTransformacao = sequenciatransformacao; 
 StatusCadastro = statuscadastro; 
 TipoPlanejamento = tipoplanejamento; 
 CalendarioId = calendarioid; 
 HierarquiaSequenciaTransformacao = hierarquiasequenciatransformacao; 
 ProximaSequenciaTransformacao = proximasequenciatransformacao; 
 Performance = performance; 
 TempoSetup = temposetup; 
 TempoSetupAjuste = temposetupajuste; 
 PecasPorPulso = pecasporpulso; 
 PrioridadeInformada = prioridadeinformada; 
 Status = status; 
 Operacoes = operacoes; 
 ExcecaoOperacoes = excecaooperacoes; 
 LinhaDireta = linhadireta; 
 AvaliaCusto = avaliacusto; 
 PercentualInicioPassoAnterior = percentualiniciopassoanterior; 
 MaquinaLarguraUtil = maquinalargurautil; 
 GrupoTipo = grupotipo; 
 GrupoPerformanceMetroLinear = grupoperformancemetrolinear; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(PedidoId))
   this._erroMensagem.Add("Pedido deve ser informado.");
   if(string.IsNullOrEmpty(MaquinaId))
   this._erroMensagem.Add("Maquina deve ser informado.");
   if(string.IsNullOrEmpty(ProdutoId))
   this._erroMensagem.Add("Produto deve ser informado.");
   if (SequenciaTransformacao == null)
   this._erroMensagem.Add("Sequencia de Transformacao deve ser informado.");
   if(string.IsNullOrEmpty(StatusCadastro))
   this._erroMensagem.Add("Status do Cadastro deve ser informado.");
   if (CalendarioId == null)
   this._erroMensagem.Add("Calendario deve ser informado.");
   if(string.IsNullOrEmpty(Operacoes))
   this._erroMensagem.Add("Operacoes deve ser informado.");
   if(string.IsNullOrEmpty(ExcecaoOperacoes))
   this._erroMensagem.Add("Excecao Operacoes deve ser informado.");
   if(string.IsNullOrEmpty(LinhaDireta))
   this._erroMensagem.Add("Linha Direta deve ser informado.");
   if (GrupoPerformanceMetroLinear == null)
   this._erroMensagem.Add("Performance Metro Linear deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration