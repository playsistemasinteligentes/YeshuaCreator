using System.Collections.Generic;

namespace Repositorio.Outputs
{
    public partial record ySagaDTO
    {
        public List<ySagaStepDTO> Steps { get; set; } = new();
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadDTOsMigration