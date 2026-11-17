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
                    public interface IChamadoSuporteEntity
{
    string? Id { get; set; }
    string Aplicativo { get; set; }
    string? Modulo { get; set; }
    string? Tela { get; set; }
    string? TituloTela { get; set; }
    string? Rota { get; set; }
    string? Caminho { get; set; }
    string Versao { get; set; }
    string? FusoHorario { get; set; }
    string? MomentoClienteUtc { get; set; }
    string? Assunto { get; set; }
    string? Descricao { get; set; }
    int Status { get; set; }
    DateTime CriadoEmUtc { get; set; }
    DateTime? AbertoEmUtc { get; set; }
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