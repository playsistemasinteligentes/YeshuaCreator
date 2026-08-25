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
                    public interface IConsultaPedidoEntity
{
    string PedidoId { get; set; }
    string ClienteId { get; set; }
    string ClienteNome { get; set; }
    string RazaoSocial { get; set; }
    string ProdutoId { get; set; }
    string ProdutoDescricao { get; set; }
    string Status { get; set; }
    string Estagio { get; set; }
    DateTime DataEntregaDe { get; set; }
    DateTime DataEntregaAte { get; set; }
    DateTime? EmbarqueAlvo { get; set; }
    Decimal Quantidade { get; set; }
    Decimal SaldoAProduzir { get; set; }
    Decimal? SaldoAExpedir { get; set; }
    string CorFila { get; set; }
    string PedidoCliente { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration