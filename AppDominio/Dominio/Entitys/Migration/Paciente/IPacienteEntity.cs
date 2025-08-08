
                using System;
                using Dominio.TiposPrimitivos;
                using System.Collections.Generic;
                using System.Linq;
                using System.Text;
                using System.Threading.Tasks;

                namespace Dominio.Entitys
                {
                    public interface IPacienteEntity
{
    int? Id { get; set; }
    string Nome { get; set; }
    string Telefone { get; set; }
    DateTime? DataNascimento { get; set; }
    int? Genero { get; set; }
    string Escolaridade { get; set; }
    string Profissao { get; set; }
    string Endereco { get; set; }
    string NomeResponsavel { get; set; }
    string TelefoneResponsavel { get; set; }
    string PrincipaisQueixas { get; set; }
    string ObservacaoAdicional { get; set; }
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