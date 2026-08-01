
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IyPerfilGrantEntity
{
    int? Id { get; set; }
    int? PerfilId { get; set; }
    string GrantId { get; set; }
    bool? Grant { get; set; }
    bool? Create { get; set; }
    bool? Read { get; set; }
    bool? Update { get; set; }
    bool? Delete { get; set; }
    DateTime? ValidUntil { get; set; }
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