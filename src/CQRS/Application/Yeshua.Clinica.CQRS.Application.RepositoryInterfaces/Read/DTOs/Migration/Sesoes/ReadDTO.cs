// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration
// </yeshua>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record SesoesDTO
    {
    public int pacienteid { get; set; }
    public DateTime datainicio { get; set; }
    public DateTime datafim { get; set; }
    public int statusagendamento { get; set; }
    public int statusprontuario { get; set; }
    public string prontuario { get; set; } = string.Empty;
    public string queixaprincipal { get; set; } = string.Empty;
    public string registrodocumental { get; set; } = string.Empty;
    public string sintomasrelatados { get; set; } = string.Empty;
    public int mudancasdesdeultimasessaao { get; set; }
    public string comportamentoobservado { get; set; } = string.Empty;
    public string estadoemocionalgeral { get; set; } = string.Empty;
    public string discursopensamentos { get; set; } = string.Empty;
    public string usomedicacao { get; set; } = string.Empty;
    public string tecnicasutilizadas { get; set; } = string.Empty;
    public string questionamentosreflexoesabordadas { get; set; } = string.Empty;
    public string exerciciostarefassugeridas { get; set; } = string.Empty;
    public string diagnoosticohipotesediagnoostica { get; set; } = string.Empty;
    public string objetivoscurtoprazo { get; set; } = string.Empty;
    public string objetivoslongoprazo { get; set; } = string.Empty;
    public string frequenciasugeridasessooes { get; set; } = string.Empty;
    public string encaminhamentooutrosprofissionais { get; set; } = string.Empty;
    public string informacoesrelevantesfuturasconsultas { get; set; } = string.Empty;
    public string feedbackpacientesobreprocessoterapeeutico { get; set; } = string.Empty;
    public int id { get; set; }
    public int servicoid { get; set; }
    public int movimentacaofinanceiraid { get; set; }
    public int profissionalid { get; set; }
    public string operationalentityid { get; set; } = string.Empty;
    public int tenantid { get; set; }
    public bool deleted { get; set; }
    public DateTime changed { get; set; }
    public int userid { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration