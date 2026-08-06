using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record MDFeEncerramentoAutorizadosParaEncerramentoDTO
    {
    public int id { get; set; }//01
    public string chaveacesso { get; set; }//01
    public int serie { get; set; }//01
    public int numero { get; set; }//01
    public string ufcarregamento { get; set; }//01
    public string ufdescarregamento { get; set; }//01
    public string placaveiculo { get; set; }//01
    public DateTime emitidoem { get; set; }//01
    public Nullable<DateTime> iniciadoem { get; set; }//01
    public int situacao { get; set; }//01
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration