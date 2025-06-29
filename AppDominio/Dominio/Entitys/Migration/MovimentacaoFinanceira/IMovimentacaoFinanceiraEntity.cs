
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IMovimentacaoFinanceiraEntity
{
    int? Id { get; set; }
    int? PacienteId { get; set; }
    int? ServicoId { get; set; }
    Decimal Valor { get; set; }
    int TipoMovimentacao { get; set; }
    DateTime DataMovimentacao { get; set; }
    Decimal SaldoAtual { get; set; }
    
                    bool isValidInsert();
                    bool isValidUpdate();
                    bool isValidDelete();
                    List<string> getErroMensagens();
                

                }
            }//Dominio.Schemas.CQRS.SourceCodeEntityMigration