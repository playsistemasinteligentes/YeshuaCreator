
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IyFileUploadEntity
{
    int? Id { get; set; }
    string IdempotencyKey { get; set; }
    string Type { get; set; }
    int Status { get; set; }
    string FilePath { get; set; }
    long? FileSize { get; set; }
    string ContentType { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? CompletedAt { get; set; }
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