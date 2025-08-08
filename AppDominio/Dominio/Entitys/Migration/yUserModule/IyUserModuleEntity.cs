
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IyUserModuleEntity
{
    int? Id { get; set; }
    string ModuleId { get; set; }
    int? UserId { get; set; }
    DateTime? ValidUntil { get; set; }
    int? TenantID { get; set; }
    bool? Deleted { get; set; }
    DateTime? Changed { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration