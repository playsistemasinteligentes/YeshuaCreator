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
                    public partial class PublicacaoAlbumEntity : IPublicacaoAlbumEntity
{
    public int? Id { get; set; }
    public int AlbumId { get; set; }
    public string CorrelationId { get; set; }
    public string? ManifestStorageKey { get; set; }
    public string? VideoStorageKey { get; set; }
    public string? YouTubeVideoId { get; set; }
    public string? YouTubeUrl { get; set; }
    public string? Mensagem { get; set; }
    public DateTime SolicitadaEmUtc { get; set; }
    public DateTime? PublicadaEmUtc { get; set; }
    public int Status { get; set; }
    public string OperationalEntityId { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal PublicacaoAlbumEntity(int? id, int albumid, string correlationid, string? manifeststoragekey, string? videostoragekey, string? youtubevideoid, string? youtubeurl, string? mensagem, DateTime solicitadaemutc, DateTime? publicadaemutc, int status ){
 Id = id; 
 AlbumId = albumid; 
 CorrelationId = correlationid; 
 ManifestStorageKey = manifeststoragekey; 
 VideoStorageKey = videostoragekey; 
 YouTubeVideoId = youtubevideoid; 
 YouTubeUrl = youtubeurl; 
 Mensagem = mensagem; 
 SolicitadaEmUtc = (solicitadaemutc < (new DateTime(1800, 1, 1))) ? DateTime.Now : solicitadaemutc; 
 PublicadaEmUtc = publicadaemutc.HasValue && publicadaemutc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : publicadaemutc; 
 Status = status; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
 Deleted = false; 
 Changed = DateTime.Now; 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
   if(string.IsNullOrEmpty(CorrelationId))
   this._erroMensagem.Add("CorrelationId deve ser informado.");
   if(SolicitadaEmUtc < (new DateTime(1800, 1, 1)))
   this._erroMensagem.Add("Solicitada em UTC deve ser informado.");
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration