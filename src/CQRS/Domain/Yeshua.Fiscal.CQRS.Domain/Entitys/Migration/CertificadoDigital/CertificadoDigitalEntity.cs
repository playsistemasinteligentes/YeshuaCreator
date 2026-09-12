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
                    public partial class CertificadoDigitalEntity : ICertificadoDigitalEntity
{
    public int? Id { get; set; }
    public string Apelido { get; set; }
    public string DocumentoTitular { get; set; }
    public string StorageKey { get; set; }
    public string? Thumbprint { get; set; }
    public DateTime? ValidoDe { get; set; }
    public DateTime? ValidoAte { get; set; }
    public int Ativo { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal CertificadoDigitalEntity(int? id, string apelido, string documentotitular, string storagekey, string? thumbprint, DateTime? validode, DateTime? validoate, int ativo ){
 Id = id; 
 Apelido = apelido; 
 DocumentoTitular = documentotitular; 
 StorageKey = storagekey; 
 Thumbprint = thumbprint; 
 ValidoDe = validode.HasValue && validode.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : validode; 
 ValidoAte = validoate.HasValue && validoate.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : validoate; 
 Ativo = ativo; 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(Apelido))
   this._erroMensagem.Add("Apelido deve ser informado.");
   if(string.IsNullOrEmpty(DocumentoTitular))
   this._erroMensagem.Add("Documento Titular deve ser informado.");
   if(string.IsNullOrEmpty(StorageKey))
   this._erroMensagem.Add("Arquivo deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration