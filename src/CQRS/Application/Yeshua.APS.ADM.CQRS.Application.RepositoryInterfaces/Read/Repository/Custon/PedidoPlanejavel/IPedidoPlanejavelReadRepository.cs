// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
// </yeshua>

using Repositorio.Outputs;
using System;
using System.Collections.Generic;

namespace IRepository.Read
{
    public partial interface IPedidoPlanejavelReadRepository
    {
        PlanejamentoTransporteContextDTO GetPlanejamentoContext(DateTime embarqueDe, DateTime embarqueAte, int limitePedidos);

        IEnumerable<PlanejamentoTransporteLensGroupDTO> GetPlanejamentoLensGroups(
            DateTime embarqueDe,
            DateTime embarqueAte,
            int limitePedidos,
            IReadOnlyDictionary<string, string> filtros,
            string campoAgrupamento);

        IEnumerable<PedidoPlanejavelDTO> GetPlanejamentoPedidos(
            DateTime embarqueDe,
            DateTime embarqueAte,
            int limitePedidos,
            IReadOnlyDictionary<string, string> filtros);

        IEnumerable<PedidoPlanejavelDTO> GetPlanejamentoPedidosByIds(
            DateTime embarqueDe,
            DateTime embarqueAte,
            int limitePedidos,
            IEnumerable<string> pedidoIds);
    }
}

//Dominio.Schemas.CQRS.SourceCodeAplicationRepositoryInterfacesReadMigration
