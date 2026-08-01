
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IyOutboxEntity
{
    int? Id { get; set; }
    string MessageId { get; set; }
    string Type { get; set; }
    string EntityType { get; set; }
    string EntityId { get; set; }
    string CorrelationId { get; set; }
    string Payload { get; set; }
    int Status { get; set; }
    int TransportType { get; set; }
    string TransportData { get; set; }
    DateTime CreatedAt { get; set; }
    DateTime? SentAt { get; set; }
    int RetryCount { get; set; }
    string LastError { get; set; }
    DateTime? ProcessingAt { get; set; }
    DateTime? NextAttemptAt { get; set; }
    int? SagaId { get; set; }
    int? SagaStepId { get; set; }
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