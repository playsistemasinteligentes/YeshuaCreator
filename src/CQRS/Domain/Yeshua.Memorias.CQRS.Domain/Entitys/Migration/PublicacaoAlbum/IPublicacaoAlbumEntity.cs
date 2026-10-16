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
                    public interface IPublicacaoAlbumEntity
{
    int? Id { get; set; }
    int AlbumId { get; set; }
    string CorrelationId { get; set; }
    string? ManifestStorageKey { get; set; }
    string? VideoStorageKey { get; set; }
    string? YouTubeVideoId { get; set; }
    string? YouTubeUrl { get; set; }
    string? ConexaoYouTubeId { get; }
    string? CanalYouTubeId { get; }
    int? YouTubeCredentialTenantId { get; }
    int? CanalStandardId { get; }
    int? PrivacidadeYouTube { get; }
    int? QualidadeVideo { get; }
    int? ModeloVideo { get; }
    int? MusicaId { get; }
    int? VolumeMusica { get; }
    string? Mensagem { get; set; }
    DateTime SolicitadaEmUtc { get; set; }
    DateTime? PublicadaEmUtc { get; set; }
    int Status { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    string OperationalEntityId { get; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration