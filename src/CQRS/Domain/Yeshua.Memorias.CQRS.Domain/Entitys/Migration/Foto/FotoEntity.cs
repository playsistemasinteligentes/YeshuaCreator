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
                    public partial class FotoEntity : IFotoEntity
{
    public int? Id { get; set; }
    public string StorageKey { get; set; }
    public string NomeOriginal { get; set; }
    public string ContentType { get; set; }
    public string? HashArquivo { get; set; }
    public DateTime? CapturadaEmUtc { get; set; }
    public int? Largura { get; set; }
    public int? Altura { get; set; }
    public int Status { get; set; }
    public string OperationalEntityId { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal FotoEntity(int? id, string storagekey, string nomeoriginal, string contenttype, string? hasharquivo, DateTime? capturadaemutc, int? largura, int? altura, int status ){
 Id = id; 
 StorageKey = storagekey; 
 NomeOriginal = nomeoriginal; 
 ContentType = contenttype; 
 HashArquivo = hasharquivo; 
 CapturadaEmUtc = capturadaemutc.HasValue && capturadaemutc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : capturadaemutc; 
 Largura = largura; 
 Altura = altura; 
 Status = status; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(StorageKey))
   this._erroMensagem.Add("Arquivo deve ser informado.");
   if(string.IsNullOrEmpty(NomeOriginal))
   this._erroMensagem.Add("Nome Original deve ser informado.");
   if(string.IsNullOrEmpty(ContentType))
   this._erroMensagem.Add("Tipo do Arquivo deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration