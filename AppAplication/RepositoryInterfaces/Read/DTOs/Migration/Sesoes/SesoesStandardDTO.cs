using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Outputs
{
    public partial record SesoesStandardDTO
    {
    public Nullable<int> id { get; set; }//01
    public DateTime datainicio { get; set; }//01
    public string nome { get; set; }//01
    public Nullable<int> statusagendamento { get; set; }//01
    public Nullable<int> statusprontuario { get; set; }//01
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration