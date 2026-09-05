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
                    public interface ICTeTentativaEmissaoEntity
{
    int? Id { get; set; }
    int CTeSolicitacaoFiscalId { get; set; }
    string ChaveAcesso { get; set; }
    int? Numero { get; set; }
    int? Serie { get; set; }
    int Tentativa { get; set; }
    string XmlAssinadoStorageKey { get; set; }
    string XmlProcStorageKey { get; set; }
    string XmlHash { get; set; }
    string CodigoRetorno { get; set; }
    string MensagemRetorno { get; set; }
    string ProtocoloAutorizacao { get; set; }
    DateTime? EnviadoEmUtc { get; set; }
    DateTime? AutorizadoEmUtc { get; set; }
    int Status { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    int? UserId { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration