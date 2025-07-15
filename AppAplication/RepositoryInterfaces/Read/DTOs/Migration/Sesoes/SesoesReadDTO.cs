using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public record SesoesDTO
    {
    public int id { get; set; }
    public int pacienteid { get; set; }
    public int profissionalid { get; set; }
    public int servicoid { get; set; }
    public DateTime datainicio { get; set; }
    public DateTime datafim { get; set; }
    public int status { get; set; }
    public int movimentacaofinanceiraid { get; set; }
    public string sinteseprontuario { get; set; }
    public string queixaprincipal { get; set; }
    public string motivoconsultaatual { get; set; }
    public string sintomasrelatados { get; set; }
    public int mudancasdesdeultimasessaao { get; set; }
    public string comportamentoobservado { get; set; }
    public string estadoemocionalgeral { get; set; }
    public string discursopensamentos { get; set; }
    public string tecnicasutilizadas { get; set; }
    public string questionamentosreflexoesabordadas { get; set; }
    public string exerciciostarefassugeridas { get; set; }
    public string diagnoosticohipotesediagnoostica { get; set; }
    public string objetivoscurtoprazo { get; set; }
    public string objetivoslongoprazo { get; set; }
    public string frequenciasugeridasessooes { get; set; }
    public string encaminhamentooutrosprofissionais { get; set; }
    public string informacoesrelevantesfuturasconsultas { get; set; }
    public string feedbackpacientesobreprocessoterapeeutico { get; set; }
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration