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
                    public partial class ChamadoSuporteEntity : IChamadoSuporteEntity
{
    public string? Id { get; set; }
    public string Aplicativo { get; set; }
    public string? Modulo { get; set; }
    public string? Tela { get; set; }
    public string? TituloTela { get; set; }
    public string? Rota { get; set; }
    public string? Caminho { get; set; }
    public string Versao { get; set; }
    public string? FusoHorario { get; set; }
    public string? MomentoClienteUtc { get; set; }
    public string? Assunto { get; set; }
    public string? Descricao { get; set; }
    public int Status { get; set; }
    public DateTime CriadoEmUtc { get; set; }
    public DateTime? AbertoEmUtc { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal ChamadoSuporteEntity(string? id, string aplicativo, string? modulo, string? tela, string? titulotela, string? rota, string? caminho, string versao, string? fusohorario, string? momentoclienteutc, string? assunto, string? descricao, int status, DateTime criadoemutc, DateTime? abertoemutc ){
 Id = id;
 Aplicativo = aplicativo;
 Modulo = modulo;
 Tela = tela;
 TituloTela = titulotela;
 Rota = rota;
 Caminho = caminho;
 Versao = versao;
 FusoHorario = fusohorario;
 MomentoClienteUtc = momentoclienteutc;
 Assunto = assunto;
 Descricao = descricao;
 Status = status;
 CriadoEmUtc = (criadoemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : criadoemutc;
 AbertoEmUtc = abertoemutc.HasValue && abertoemutc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : abertoemutc;
 Deleted = false;
 Changed = DateTime.Now;
 OperationalEntityId = Guid.NewGuid().ToString("N");
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Aplicativo))
   this._erroMensagem.Add("Aplicativo deve ser informado.");
   if(string.IsNullOrEmpty(Versao))
   this._erroMensagem.Add("Versao instalada deve ser informado.");
   if(CriadoEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Criado em UTC deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration