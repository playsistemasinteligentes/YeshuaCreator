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
                    public partial class PublicacaoDestinoEntity : IPublicacaoDestinoEntity
{
    public string? Id { get; set; }
    public string? IdentidadeId { get; set; }
    public string? VersaoId { get; set; }
    public string? CanalId { get; set; }
    public string? Estado { get; set; }
    public int? Tentativas { get; set; }
    public DateTime? ProximaTentativaUtc { get; set; }
    public string? ReciboExterno { get; set; }
    public string? UrlPublica { get; set; }
    public int? TenantID { get; set; }
    public bool? Deleted { get; set; }
    public DateTime? Changed { get; set; }
    public int? UserId { get; set; }
    public string OperationalEntityId { get; set; }
    public string? CodigoErro { get; set; }
    public string? NaturezaFalha { get; set; }
    public bool? RetryPossivel { get; set; }
    private List<string> _erroMensagem = new List<string>();
 internal PublicacaoDestinoEntity(string? id, string? identidadeid, string? versaoid, string? canalid, string? estado, int? tentativas, DateTime? proximatentativautc, string? reciboexterno, string? urlpublica, string? codigoerro, string? naturezafalha, bool? retrypossivel ){
 Id = id; 
 IdentidadeId = identidadeid; 
 VersaoId = versaoid; 
 CanalId = canalid; 
 Estado = estado; 
 Tentativas = tentativas; 
 ProximaTentativaUtc = proximatentativautc.HasValue && proximatentativautc.Value < (new DateTime(1800, 1, 1)) ? DateTime.Now : proximatentativautc; 
 ReciboExterno = reciboexterno; 
 UrlPublica = urlpublica; 
 CodigoErro = codigoerro; 
 NaturezaFalha = naturezafalha; 
 RetryPossivel = retrypossivel; 
 Deleted = false; 
 Changed = DateTime.Now; 
 OperationalEntityId = Guid.NewGuid().ToString("N"); 
}
public bool isValidData()
{
_erroMensagem = new List<string>();
return _erroMensagem.Count() <= 0;
}

                        public bool isValidInsert() => isValidData();
                        public bool isValidUpdate() => isValidData();
                        public bool isValidDelete() => true;
                        public List<string> getErroMensagens() => _erroMensagem;
                
                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration