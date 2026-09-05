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
                    public partial class CTeParticipanteSnapshotEntity : ICTeParticipanteSnapshotEntity
{
    public int? Id { get; set; }
    public int CTeSolicitacaoFiscalId { get; set; }
    public string Papel { get; set; }
    public string Documento { get; set; }
    public string Nome { get; set; }
    public string InscricaoEstadual { get; set; }
    public string UF { get; set; }
    public string MunicipioCodigoIbge { get; set; }
    public string EnderecoJson { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = null;
 internal CTeParticipanteSnapshotEntity(int? id, int ctesolicitacaofiscalid, string papel, string documento, string nome, string inscricaoestadual, string uf, string municipiocodigoibge, string enderecojson ){
 Id = id; 
 CTeSolicitacaoFiscalId = ctesolicitacaofiscalid; 
 Papel = papel; 
 Documento = documento; 
 Nome = nome; 
 InscricaoEstadual = inscricaoestadual; 
 UF = uf; 
 MunicipioCodigoIbge = municipiocodigoibge; 
 EnderecoJson = enderecojson; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Papel))
   this._erroMensagem.Add("Papel deve ser informado.");
   if(string.IsNullOrEmpty(Documento))
   this._erroMensagem.Add("Documento deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration