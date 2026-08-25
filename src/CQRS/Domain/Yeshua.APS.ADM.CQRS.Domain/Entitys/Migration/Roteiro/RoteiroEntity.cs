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
                    public partial class RoteiroEntity : IRoteiroEntity
{
    public int? Id { get; set; }
    public string MaquinaId { get; set; }
    public string ProdutoId { get; set; }
    public int SequenciaTransformacao { get; set; }
    public string GrupoMaquinaId { get; set; }
    public Decimal? PecasPorPulso { get; set; }
    public Decimal? PrioridadeInformada { get; set; }
    public string Acao { get; set; }
    public Decimal Performance { get; set; }
    public Decimal? TempoSetup { get; set; }
    public Decimal? TempoSetupAjuste { get; set; }
    public int? ProximaSequenciaTransformacao { get; set; }
    public string Status { get; set; }
    public Decimal? HierarquiaSequenciaTransformacao { get; set; }
    public int? AvaliaCusto { get; set; }
    public string Operacoes { get; set; }
    public string ExcecaoOperacoes { get; set; }
    public Decimal? PercentualInicioPassoAnterior { get; set; }
    public string LinhaDireta { get; set; }
    public int? TemplateDeTestesId { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal RoteiroEntity(int? id, string maquinaid, string produtoid, int sequenciatransformacao, string grupomaquinaid, Decimal? pecasporpulso, Decimal? prioridadeinformada, string acao, Decimal performance, Decimal? temposetup, Decimal? temposetupajuste, int? proximasequenciatransformacao, string status, Decimal? hierarquiasequenciatransformacao, int? avaliacusto, string operacoes, string excecaooperacoes, Decimal? percentualiniciopassoanterior, string linhadireta, int? templatedetestesid ){
 Id = id; 
 MaquinaId = maquinaid; 
 ProdutoId = produtoid; 
 SequenciaTransformacao = sequenciatransformacao; 
 GrupoMaquinaId = grupomaquinaid; 
 PecasPorPulso = pecasporpulso; 
 PrioridadeInformada = prioridadeinformada; 
 Acao = acao; 
 Performance = performance; 
 TempoSetup = temposetup; 
 TempoSetupAjuste = temposetupajuste; 
 ProximaSequenciaTransformacao = proximasequenciatransformacao; 
 Status = status; 
 HierarquiaSequenciaTransformacao = hierarquiasequenciatransformacao; 
 AvaliaCusto = avaliacusto; 
 Operacoes = operacoes; 
 ExcecaoOperacoes = excecaooperacoes; 
 PercentualInicioPassoAnterior = percentualiniciopassoanterior; 
 LinhaDireta = linhadireta; 
 TemplateDeTestesId = templatedetestesid; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(MaquinaId))
   this._erroMensagem.Add("Codigo da Maquina deve ser informado.");
   if(string.IsNullOrEmpty(ProdutoId))
   this._erroMensagem.Add("Codigo do Produto deve ser informado.");
   if (SequenciaTransformacao == null)
   this._erroMensagem.Add("Sequencia de Transformacao deve ser informado.");
   if (Performance == null)
   this._erroMensagem.Add("Performance Pulsos por Segundo deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration